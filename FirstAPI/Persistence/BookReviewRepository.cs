using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FirstAPI.Persistence
{
    /// <summary>
    /// Repository for managing book review data operations in the database
    /// </summary>
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BookContext _context;

        /// <summary>
        /// Initializes a new instance of the BookReviewRepository class
        /// </summary>
        /// <param name="context">The database context used for book review operations</param>
        public BookReviewRepository(BookContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new book review to the database
        /// </summary>
        /// <param name="bookReview">The book review entity to add</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task AddBookReviewAsync(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a book review from the database
        /// </summary>
        /// <param name="bookReview">The book review entity to remove</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task RemoveBookReviewAsync(BookReview bookReview)
        {
            _context.BookReviews.Remove(bookReview);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing book review in the database
        /// </summary>
        /// <param name="bookReview">The book review entity with updated values</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task UpdateBookReviewAsync(BookReview bookReview)
        {
            _context.BookReviews.Update(bookReview);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a book review by its unique identifier
        /// </summary>
        /// <param name="id">The ID of the book review to retrieve</param>
        /// <returns>The book review if found, otherwise null</returns>
        public async Task<BookReview> GetBookReviewByIdAsync(int id)
        {
            return await _context.BookReviews.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all book reviews from the database
        /// </summary>
        /// <returns>A collection of all book reviews</returns>
        public async Task<IEnumerable<BookReview>> GetAllBookReviewAsync()
        {
            return await _context.BookReviews.ToListAsync();
        }

        /// <summary>
        /// Retrieves all reviews for a specific book by its ID
        /// </summary>
        /// <param name="bookId">The ID of the book to get reviews for</param>
        /// <returns>A collection of reviews for the specified book</returns>
        public async Task<IEnumerable<BookReview>> GetReviewsByBookIdAsync(int bookId)
        {
            return await _context.BookReviews
                .Where(r => r.BookId == bookId)
                .ToListAsync();
        }

        /// <summary>
        /// Checks if a book review with the specified ID exists in the database
        /// </summary>
        /// <param name="id">The ID of the book review to check</param>
        /// <returns>True if the book review exists, otherwise false</returns>
        public async Task<bool> BookReviewExistsAsync(int id)
        {
            return await _context.BookReviews.AnyAsync(e => e.Id == id);
        }   
    }
}
