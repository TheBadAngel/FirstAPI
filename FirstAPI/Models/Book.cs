using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    /// <summary>
    /// Represents a book entity in the application
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book
        /// </summary>
        public int Id { get; set; }
                
        /// <summary>
        /// Gets or sets the title of the book
        /// This field is required
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the author of the book
        /// This field is required
        /// </summary>
        [Required]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the publication year of the book
        /// This field is required
        /// </summary>
        [Required]
        public int Year { get; set; }
        public ICollection<BookReview> Reviews { get; set; }
    }
}
