using FirstAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstAPI.Persistence
{
    public interface IBookReviewRepository
    {
        /// <summary>
        /// Retrieves all book reviews from the database
        /// </summary>
        /// <returns>A collection of all book reviews</returns>
        Task<IEnumerable<BookReview>> GetAllBookReviewAsync();

        /// <summary>
        /// Adds a new book review to the database
        /// </summary>
        /// <param name="bookReview">The book review entity to add</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task AddBookReviewAsync(BookReview bookReview);

        /// <summary>
        /// Removes a book review from the database
        /// </summary>
        /// <param name="bookReview">The book review entity to remove</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task RemoveBookReviewAsync(BookReview bookReview);

        /// <summary>
        /// Updates an existing book review in the database
        /// </summary>
        /// <param name="bookReview">The book review entity with updated values</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task UpdateBookReviewAsync(BookReview bookReview);

        /// <summary>
        /// Retrieves a book review by its unique identifier
        /// </summary>
        /// <param name="id">The ID of the book review to retrieve</param>
        /// <returns>The book review if found, otherwise null</returns>
        Task<BookReview> GetBookReviewByIdAsync(int id);

        /// <summary>
        /// Retrieves all reviews for a specific book
        /// </summary>
        /// <param name="bookId">The ID of the book to get reviews for</param>
        /// <returns>A collection of reviews for the specified book</returns>
        Task<IEnumerable<BookReview>> GetReviewsByBookIdAsync(int bookId);

        /// <summary>
        /// Checks if a book review exists by its ID
        /// </summary>
        /// <param name="id">The ID to check</param>
        /// <returns>True if the review exists, otherwise false</returns>
        Task<bool> BookReviewExistsAsync(int id);
    }
}