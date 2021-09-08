using System.Collections.Generic;

namespace AspNetSandBox
{
    public interface IBooksService
    {
        void DeleteBookById(int id);

        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void AddBookToList(Book value);

        void UpdateBookById(int id, Book value);
    }
}