using System.Collections.Generic;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandBox.Controllers
{
    /// <summary>Controller class for managing books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        /// <param name="booksService">The books service.</param>
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        /// <summary>Get all instances of books.</summary>
        /// <returns>Ennumerable of Book objects.</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.GetAllBooks();
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return booksService.GetBookById(id);
        }

        /// <summary>Adds books to List of Book objects.</summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.AddBookToList(value);
        }

        /// <summary>Update values of book with certain id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.UpdateBookById(id, value);
        }

        /// <summary>Removes a book from the List of Book objects.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.DeleteBookById(id);
        }
    }
}
