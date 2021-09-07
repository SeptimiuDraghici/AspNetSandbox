using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 0,
                Title = "Metro 2033",
                Author = "Dmitry Glukhovsky",
                Language = "English"
            });

            books.Add(new Book
            {
                Id = 1,
                Title = "Metro 2034",
                Author = "Dmitry Glukhovsky",
                Language = "English"
            });
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void Post(Book value)
        {
            int id = books.Count;
            value.Id = id;
            books.Add(value);
        }

        public void Put(int id, string value)
        {
        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
