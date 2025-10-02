using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class BookReview
    {
        /// <summary>
        /// Unique identifier for the book review
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to the Book entity
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Navigation property to the associated Book
        /// </summary>
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        /// <summary>
        /// Name of the reviewer
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ReviewerName { get; set; }

        /// <summary>
        /// Rating given to the book (1-5)
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        /// <summary>
        /// Text content of the review
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string ReviewText { get; set; }

        /// <summary>
        /// Date and time when the review was posted
        /// </summary>
        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}