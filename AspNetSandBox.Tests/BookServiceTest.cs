using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void ShouldCorrectlyIncrementIdOfBookTest()
        {
            //Assume

            var bookService = new BooksService();

            //Act

            bookService.AddBookToList(new Book
            {
                Title = "Metro 2035",
                Author = "Dmitry Glukhovsky",
                Language = "English"
            });
            bookService.DeleteBookById(2);
            bookService.AddBookToList(new Book
            {
                Title = "Shining",
                Author = "Stephen King",
                Language = "English"
            });

            //Assert

            Assert.Equal("Shining", bookService.GetBookById(3).Title);
        }

        [Fact]
        public void ShouldUpdateOnlyChangedFieldsOfBookTest()
        {
            //Assume

            var bookService = new BooksService();

            //Act

            bookService.UpdateBookById(1, new Book
            {
                Title = "Metro 2035",
                Author = "Random Author",
                Language = "English"
            });
            bookService.UpdateBookById(0, new Book
            {
                Title = "Shining",
                Author = "Stephen King"
            });

            //Assert

            Assert.Equal("Random Author", bookService.GetBookById(1).Author);
            Assert.Equal("Shining", bookService.GetBookById(0).Title);
            Assert.Equal("Stephen King", bookService.GetBookById(0).Author);
            Assert.Equal("English", bookService.GetBookById(0).Language);
        }
    }
}
