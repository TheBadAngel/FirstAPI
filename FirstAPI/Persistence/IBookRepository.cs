using FirstAPI.Models;
using System.Threading.Tasks;

namespace FirstAPI.Persistence
{
    public interface IBookRepository
    {
        /// <summary>
        /// Retrieves all books from the database
        /// </summary>
        /// <returns>A collection of all books</returns>
        Task<IEnumerable<Book>> GetAllBooksAsync();
        
        /// <summary>
        /// Adds a new book to the database
        /// </summary>
        /// <param name="book">The book entity to add</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task AddBookAsync(Book book);
        
        /// <summary>
        /// Removes a book from the database
        /// </summary>
        /// <param name="book">The book entity to remove</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task RemoveBookAsync(Book book);
        
        /// <summary>
        /// Updates an existing book in the database
        /// </summary>
        /// <param name="book">The book entity with updated values</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task UpdateBookAsync(Book book);
        
        /// <summary>
        /// Retrieves a book by its unique identifier
        /// </summary>
        /// <param name="id">The ID of the book to retrieve</param>
        /// <returns>The book if found, otherwise null</returns>
        Task<Book> GetBookByIdAsync(int id);
    }
}