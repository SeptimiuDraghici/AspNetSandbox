using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandBox.Models;

namespace AspNetSandBox
{
    /// <summary>BooksService class that contains methods for managing Book objects.</summary>
    public class BooksInMemoryRepository : IBookRepository
    {
        private static int bookIdCounter = 1;
        private List<Book> books;

        /// <summary>Initializes a new instance of the <see cref="BooksInMemoryRepository" /> class.</summary>
        public BooksInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 0,
                Title = "Metro 2033",
                Author = "Dmitry Glukhovsky",
                Language = "English",
            });

            books.Add(new Book
            {
                Id = 1,
                Title = "Metro 2034",
                Author = "Dmitry Glukhovsky",
                Language = "English",
            });
        }

        /// <summary>Resets the bookIdCounter to be used for testing.</summary>
        public void ResetData()
        {
            bookIdCounter = 1;
        }

        /// <summary>Fetches all instances of Book objects in our List.</summary>
        /// <returns>Enumerable of Book objects.</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        /// <summary>Fetches a certain Book object from the List by its Id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        public Book GetBookById(int id)
        {
            try
            {
                return books.Single(_ => _.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting book by given Id! Error: " + ex);
                return null;
            }
        }

        /// <summary>Adds Book object to the List.</summary>
        /// <param name="value">The value.</param>
        public void AddBookToList(Book value)
        {
            value.Id = ++bookIdCounter;
            books.Add(value);
        }

        /// <summary>
        ///   Updates values of book with given Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void UpdateBookById(int id, Book value)
        {
            var newTitle = value.Title;
            var newAuthor = value.Author;
            var newLanguage = value.Language;
            if (newTitle != null)
            {
                books[id].Title = newTitle;
            }

            if (newAuthor != null)
            {
                books[id].Author = newAuthor;
            }

            if (newLanguage != null)
            {
                books[id].Language = newLanguage;
            }
        }

        /// <summary>Removes a Book object with given Id from List.</summary>
        /// <param name="id">The identifier.</param>
        public void DeleteBookById(int id)
        {
            books.Remove(GetBookById(id));
        }
    }
}
