using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandBox.Data;
using AspNetSandBox.DTOs;
using AspNetSandBox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Controllers
{
    /// <summary>Controller class for managing books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        /// <summary>Get all instances of books.</summary>
        /// <returns>Ennumerable of BookDto objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Book> books = repository.GetAllBooks();
            IEnumerable<ReadBookDto> readBooksDto = mapper.Map<IEnumerable<Book>, IEnumerable<ReadBookDto>>(books);
            return Ok(readBooksDto);
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BookDto object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = repository.GetBookById(id);
                ReadBookDto readBookDto = mapper.Map<ReadBookDto>(book);
                return Ok(readBookDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>Adds books to List of Book objects.</summary>
        /// <param name="bookDto">The book.</param>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBookToList(book);
                hubContext.Clients.All.SendAsync("BookCreated", bookDto);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>Update values of book with certain id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookDto">bookDto.</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book;
            if (ModelState.IsValid)
            {
                try
                {
                    book = mapper.Map<Book>(bookDto);
                    repository.UpdateBookById(id, book);
                    hubContext.Clients.All.SendAsync("BookEdited", bookDto);
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
