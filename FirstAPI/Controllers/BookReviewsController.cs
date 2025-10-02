using FirstAPI.Models;
using FirstAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controllers
{
    /// <summary>
    /// Controller for managing book reviews through the API
    /// </summary>
    [ApiController]
    public class BookReviewsController : Controller
    {
        private readonly IBookReviewRepository _BookReviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookReviewsController"/> class
        /// </summary>
        /// <param name="context">The book review repository</param>
        public BookReviewsController(IBookReviewRepository context)
        {
            _BookReviewRepository = context;
        }

        /// <summary>
        /// Gets all book reviews
        /// </summary>
        /// <returns>A collection of all book reviews</returns>
        /// <response code="200">Returns the collection of book reviews</response>
        /// <response code="404">If no book reviews are found</response>
        [HttpGet("api/bookreviews")]
        public async Task<IActionResult> GetAllBookReviewsAsync()
        {
            var bookReviews = await _BookReviewRepository.GetAllBookReviewAsync();
            if (bookReviews == null || !bookReviews.Any())
            {
                return NotFound();
            }
            return Ok(bookReviews);
        }

        /// <summary>
        /// Gets a specific book review by ID
        /// </summary>
        /// <param name="id">The ID of the book review to retrieve</param>
        /// <returns>The requested book review</returns>
        /// <response code="200">Returns the requested book review</response>
        /// <response code="404">If the book review is not found</response>
        [HttpGet("api/bookreviews/{id}")]
        public async Task<IActionResult> GetBookReviewByIdAsync(int id)
        {
            var bookReview = await _BookReviewRepository.GetBookReviewByIdAsync(id);
            if (bookReview == null)
            {
                return NotFound();
            }
            return Ok(bookReview);
        }

        /// <summary>
        /// Gets all reviews for a specific book
        /// </summary>
        /// <param name="bookId">The ID of the book to get reviews for</param>
        /// <returns>A collection of reviews for the specified book</returns>
        /// <response code="200">Returns the collection of book reviews</response>
        /// <response code="404">If no reviews are found for the specified book</response>
        [HttpGet("api/bookreviews/book/{bookId}")]
        public async Task<IActionResult> GetReviewsByBookIdAsync(int bookId)
        {
            var reviews = await _BookReviewRepository.GetReviewsByBookIdAsync(bookId);
            if (reviews == null || !reviews.Any())
            {
                return NotFound();
            }
            return Ok(reviews);
        }

        /// <summary>
        /// Creates a new book review
        /// </summary>
        /// <param name="bookReview">The book review to create</param>
        /// <returns>The created book review</returns>
        /// <response code="201">Returns the newly created book review</response>
        /// <response code="400">If the book review data is invalid</response>
        [HttpPost("api/bookreviews")]
        public async Task<IActionResult> AddBookReviewAsync([FromBody] BookReview bookReview)
        {
            if (bookReview == null)
            {
                return BadRequest();
            }
            await _BookReviewRepository.AddBookReviewAsync(bookReview);
            return CreatedAtAction(nameof(GetBookReviewByIdAsync), new { id = bookReview.Id }, bookReview);
        }

        /// <summary>
        /// Updates an existing book review
        /// </summary>
        /// <param name="id">The ID of the book review to update</param>
        /// <param name="bookReview">The updated book review data</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the book review was successfully updated</response>
        /// <response code="400">If the book review data is invalid</response>
        /// <response code="404">If the book review is not found</response>
        [HttpPut("api/bookreviews/{id}")]
        public async Task<IActionResult> UpdateBookReviewAsync(int id, [FromBody] BookReview bookReview)
        {
            if (bookReview == null || bookReview.Id != id)
            {
                return BadRequest();
            }
            var existingReview = await _BookReviewRepository.GetBookReviewByIdAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }
            await _BookReviewRepository.UpdateBookReviewAsync(bookReview);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific book review
        /// </summary>
        /// <param name="id">The ID of the book review to delete</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the book review was successfully deleted</response>
        /// <response code="404">If the book review is not found</response>
        [HttpDelete("api/bookreviews/{id}")]
        public async Task<IActionResult> DeleteBookReviewAsync(int id)
        {
            var existingReview = await _BookReviewRepository.GetBookReviewByIdAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }
            await _BookReviewRepository.RemoveBookReviewAsync(existingReview);
            return NoContent();
        }
    }
}