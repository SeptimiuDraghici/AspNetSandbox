﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        static int bookIdCounter = 1;

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

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Single(_ => _.Id == id);
        }

        public void AddBookToList(Book value)
        {
            bookIdCounter++;
            value.Id = bookIdCounter;
            books.Add(value);
        }

        public void UpdateBookById(int id, Book value)
        {
            var newTitle = value.Title;
            var newAuthor = value.Author;
            var newLanguage = value.Language;
            books[id].Id = id;
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

        public void DeleteBookById(int id)
        {
            books.Remove(GetBookById(id));
        }
    }
}
