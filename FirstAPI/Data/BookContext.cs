using Microsoft.EntityFrameworkCore;
using FirstAPI.Models;
using Microsoft.AspNetCore.Razor.Language.Intermediate;


namespace FirstAPI.Data
{
    /// <summary>
    /// Database context class for the Book entity
    /// Manages the connection to the database and defines entity sets
    /// </summary>
    public class BookContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the BookContext class
        /// </summary>
        /// <param name="options">The options to be used by the DbContext</param>
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            // Base constructor handles database configuration
        }

        /// <summary>
        /// Gets or sets the DbSet of Books
        /// This is used to query and save instances of the Book entity
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Configures the model and seeds initial data
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the database with initial book data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Year = 1949 },
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
                new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = 1951 }
            );
        }
    }
}
