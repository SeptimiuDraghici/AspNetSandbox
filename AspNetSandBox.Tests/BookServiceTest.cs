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
        public void ConvertResponseToWeatherForecastTest()
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

            Assert.Equal("Metro 2035", bookService.GetAllBooks(3).Title);
        }
    }
}
