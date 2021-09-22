using System.Collections.Generic;
using AspNetSandBox.Models;

namespace AspNetSandBox.Interfaces
{
    /// <summary>Interface for BooksRepository class.</summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Interface for deleting a book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteBookById(int id);

        /// <summary>Interface for fetching all books.</summary>
        /// <returns>IEnumerable of Book Objects.</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>Interface for fetching book with given Id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        Book GetBookById(int id);

        /// <summary>Interface for adding books to List.</summary>
        /// <param name="value">The value.</param>
        void AddBookToList(Book value);

        /// <summary>Interface for updating book with given Id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        void UpdateBookById(int id, Book value);
    }
}