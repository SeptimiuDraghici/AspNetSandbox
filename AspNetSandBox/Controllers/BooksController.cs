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
        private readonly ApplicationDbContext _context;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>Get all instances of books.</summary>
        /// <returns>Ennumerable of Book objects.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Book.ToListAsync());
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>Adds books to List of Book objects.</summary>
        /// <param name="book">The book.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>Update values of book with certain id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
