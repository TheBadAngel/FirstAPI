using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FirstAPI.Persistence
{
    /// <summary>
    /// Repository implementation for Book entity operations
    /// Provides database access methods for CRUD operations on books
    /// </summary>
    public class BookRepository : IBookRepository
    {
        // Dependency Injection of BookContext
        private readonly BookContext _context;
        
        /// <summary>
        /// Initializes a new instance of the BookRepository class
        /// </summary>
        /// <param name="context">The database context to be used for book operations</param>
        public BookRepository(BookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new book to the database
        /// </summary>
        /// <param name="book">The book entity to add</param>
        /// <returns>A task representing the asynchronous operation</returns>
       public Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a book from the database
        /// </summary>
        /// <param name="book">The book entity to remove</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task RemoveBookAsync(Book book)
        {
            _context.Books.Remove(book);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing book in the database
        /// </summary>
        /// <param name="book">The book entity with updated values</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            return _context.SaveChangesAsync();
        }
        
        /// <summary>
        /// Retrieves a book by its unique identifier
        /// </summary>
        /// <param name="id">The ID of the book to retrieve</param>
        /// <returns>The book if found, otherwise null</returns>
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        
        /// <summary>
        /// Retrieves all books from the database
        /// </summary>
        /// <returns>A collection of all books</returns>
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
