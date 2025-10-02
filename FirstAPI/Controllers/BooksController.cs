using FirstAPI.Models;
using FirstAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
   [ApiController]
    public class BooksController : Controller
    {
        /// <summary>
        /// Repository for accessing book data
        /// </summary>
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Initializes a new instance of the BookController class
        /// </summary>
        /// <param name="bookRepository">The book repository for data operations</param>
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Gets all books from the database
        /// </summary>
        /// <returns>A list of all books or NotFound if no books exist</returns>
        [HttpGet("api/books")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var book = await _bookRepository.GetAllBooksAsync();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Gets a book by its unique identifier
        /// </summary>
        /// <param name="id">The ID of the book to retrieve</param>
        /// <returns>The book if found, or NotFound if no book exists with the specified ID</returns>
        [HttpGet("api/books/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        /// <summary>
        /// Adds a new book to the database
        /// </summary>
        /// <param name="book">The book to be added</param>
        /// <returns>CreatedAtAction result with the new book details</returns>
        [HttpPost("api/books")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.Id = 0; // Ensure the ID is set to 0 for new entries

            await _bookRepository.AddBookAsync(book);
            
            return CreatedAtAction(nameof(GetAllBooksAsync), new { id = book.Id }, book);
        }

        /// <summary>
        /// Deletes a book with the specified ID
        /// </summary>
        /// <param name="id">The ID of the book to delete</param>
        /// <returns>NoContent if successful, NotFound if the book doesn't exist</returns>
        [HttpDelete("api/books/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _bookRepository.RemoveBookAsync(existingBook);
            return NoContent();
        }
        
        /// <summary>
        /// Updates a book with the specified ID
        /// </summary>
        /// <param name="id">The ID of the book to update</param>
        /// <param name="book">The updated book information</param>
        /// <returns>NoContent if successful, NotFound if the book doesn't exist</returns>
        [HttpPut("api/books/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            // Update the existing book's properties
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
            await _bookRepository.UpdateBookAsync(existingBook);
            return NoContent();
        }
    }
}
