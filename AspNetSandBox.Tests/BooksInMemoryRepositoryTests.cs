using AspNetSandBox.Models;
using AspNetSandBox.Services;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>Tests for BookService methods.</summary>
    public class BooksInMemoryRepositoryTests
    {
        private BooksInMemoryRepository bookService;

        /// <summary>Initializes a new instance of the <see cref="BooksInMemoryRepositoryTests" /> class.</summary>
        public BooksInMemoryRepositoryTests()
        {
            bookService = new BooksInMemoryRepository();
            bookService.ResetData();
        }

        /// <summary>Test that checks if the Id of Book object correctly increments when adding a new book.</summary>
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

        /// <summary>Test that checks if the values of Book object correctly change when updating a book.</summary>
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
