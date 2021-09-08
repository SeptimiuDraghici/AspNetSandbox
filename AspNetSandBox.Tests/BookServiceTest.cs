using Xunit;

namespace AspNetSandBox.Tests
{
    public class BookServiceTest
    {
        private BooksService bookService;

        public BookServiceTest()
        {
            bookService = new BooksService();
            bookService.ResetData();
        }

        [Fact]
        public void ShouldCorrectlyIncrementIdOfBookTest()
        {
            // Assume

            // Act
            bookService.AddBookToList(new Book
            {
                Title = "Metro 2035",
                Author = "Dmitry Glukhovsky",
                Language = "English",
            });
            bookService.DeleteBookById(2);
            bookService.AddBookToList(new Book
            {
                Title = "Shining",
                Author = "Stephen King",
                Language = "English",
            });

            // Assert
            Assert.Equal("Shining", bookService.GetBookById(3).Title);
        }

        [Fact]
        public void ShouldUpdateOnlyChangedFieldsOfBookTest()
        {
            // Assume

            // Act
            bookService.AddBookToList(new Book
            {
                Title = "Metro 2035",
                Author = "Dmitry Glukhovsky",
                Language = "English",
            });
            bookService.UpdateBookById(2, new Book
            {
                Title = "Metro 2035",
                Author = "Random Author",
                Language = "English",
            });
            bookService.UpdateBookById(0, new Book
            {
                Title = "Shining",
                Author = "Stephen King",
            });

            // Assert
            Assert.Equal("Random Author", bookService.GetBookById(2).Author);
            Assert.Equal("Shining", bookService.GetBookById(0).Title);
            Assert.Equal("Stephen King", bookService.GetBookById(0).Author);
            Assert.Equal("English", bookService.GetBookById(0).Language);
        }
    }
}
