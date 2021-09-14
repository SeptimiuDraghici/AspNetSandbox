using System.Collections.Generic;
using System.Linq;
using AspNetSandBox.Data;
using AspNetSandBox.Models;

namespace AspNetSandBox.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBookToList(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void DeleteBookById(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Book.ToList();
        }

        public Book GetBookById(int id)
        {
            var book = context.Book
               .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void UpdateBookById(int id, Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }
    }
}
