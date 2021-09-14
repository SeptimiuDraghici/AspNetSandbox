using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandBox.Data;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Controllers
{
    /// <summary>Controller class for managing books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>Get all instances of books.</summary>
        /// <returns>Ennumerable of Book objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAllBooks());
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>Adds books to List of Book objects.</summary>
        /// <param name="book">The book.</param>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBookToList(book);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>Update values of book with certain id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.UpdateBookById(id, book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return Ok(book);
            }

            return BadRequest();
        }

        /// <summary>Removes a book from the List of Book objects.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteBookById(id);
            return Ok();
        }
    }
}
