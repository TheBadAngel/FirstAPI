using Microsoft.EntityFrameworkCore;
using FirstAPI.Models;


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
        /// Gets or sets the DbSet of BookReviews
        /// This is used to query and save instances of the BookReview entity
        /// </summary>
        public DbSet<BookReview> BookReviews { get; set; }

        /// <summary>
        /// Configures the model and seeds initial data
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Book and BookReview relationship
            modelBuilder.Entity<Book>()
                .HasMany<BookReview>(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed the database with initial book data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Year = 1949 },
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
                new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = 1951 },
                new Book { Id = 6, Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Year = 1967 },
                new Book { Id = 7, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932 },
                new Book { Id = 8, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Year = 1954 },
                new Book { Id = 9, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Year = 1997 },
                new Book { Id = 10, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
                new Book { Id = 11, Title = "Moby-Dick", Author = "Herman Melville", Year = 1851 },
                new Book { Id = 12, Title = "War and Peace", Author = "Leo Tolstoy", Year = 1869 },
                new Book { Id = 13, Title = "The Odyssey", Author = "Homer", Year = -800 },
                new Book { Id = 14, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Year = 1866 },
                new Book { Id = 15, Title = "The Shining", Author = "Stephen King", Year = 1977 }
            );

            // Seed book reviews for all books
            modelBuilder.Entity<BookReview>().HasData(
                // Book 1: The Great Gatsby
                new BookReview
                {
                    Id = 1,
                    BookId = 1,
                    ReviewerName = "Jane Smith",
                    Rating = 4,
                    ReviewText = "Beautifully written with complex characters, though the pacing felt slow at times.",
                    ReviewDate = new DateTime(2023, 2, 20)
                },
                
                // Book 2: To Kill a Mockingbird
                new BookReview
                {
                    Id = 2,
                    BookId = 2,
                    ReviewerName = "Robert Johnson",
                    Rating = 5,
                    ReviewText = "A powerful exploration of racial injustice that remains relevant today.",
                    ReviewDate = new DateTime(2023, 3, 10)
                },
                
                // Book 3: 1984
                new BookReview
                {
                    Id = 3,
                    BookId = 3,
                    ReviewerName = "Sarah Williams",
                    Rating = 5,
                    ReviewText = "Orwell's dystopian vision is disturbingly prescient. A must-read for everyone.",
                    ReviewDate = new DateTime(2023, 4, 5)
                },
                
                // Book 4: Pride and Prejudice
                new BookReview
                {
                    Id = 4,
                    BookId = 4,
                    ReviewerName = "Emily Chen",
                    Rating = 5,
                    ReviewText = "Austen's wit and social commentary shine in this timeless romance.",
                    ReviewDate = new DateTime(2023, 3, 22)
                },
                
                // Book 5: The Catcher in the Rye
                new BookReview
                {
                    Id = 5,
                    BookId = 5,
                    ReviewerName = "Michael Brown",
                    Rating = 4,
                    ReviewText = "Holden Caulfield's voice is authentic and raw, speaking to teenage alienation across generations.",
                    ReviewDate = new DateTime(2023, 5, 12)
                },
                
                // Book 6: One Hundred Years of Solitude
                new BookReview
                {
                    Id = 6,
                    BookId = 6,
                    ReviewerName = "Sofia Rodriguez",
                    Rating = 5,
                    ReviewText = "Magical realism at its finest. A multi-generational epic that blends fantasy with history.",
                    ReviewDate = new DateTime(2023, 2, 8)
                },
                
                // Book 7: Brave New World
                new BookReview
                {
                    Id = 7,
                    BookId = 7,
                    ReviewerName = "Thomas Wilson",
                    Rating = 4,
                    ReviewText = "Huxley's vision of a pleasure-obsessed society feels increasingly relevant.",
                    ReviewDate = new DateTime(2023, 6, 19)
                },
                
                // Book 8: The Lord of the Rings
                new BookReview
                {
                    Id = 8,
                    BookId = 8,
                    ReviewerName = "Alex Morgan",
                    Rating = 5,
                    ReviewText = "The definitive fantasy epic that created a genre. Unmatched in scope and imagination.",
                    ReviewDate = new DateTime(2023, 4, 30)
                },
                
                // Book 9: Harry Potter and the Philosopher's Stone
                new BookReview
                {
                    Id = 9,
                    BookId = 9,
                    ReviewerName = "Lily Zhang",
                    Rating = 5,
                    ReviewText = "The beginning of a magical journey that captivated a generation. Perfect for readers of all ages.",
                    ReviewDate = new DateTime(2023, 7, 15)
                },
                
                // Book 10: The Hobbit
                new BookReview
                {
                    Id = 10,
                    BookId = 10,
                    ReviewerName = "David Lee",
                    Rating = 4,
                    ReviewText = "A charming adventure story that serves as the perfect introduction to Middle-earth.",
                    ReviewDate = new DateTime(2023, 3, 27)
                },
                
                // Book 11: Moby-Dick
                new BookReview
                {
                    Id = 11,
                    BookId = 11,
                    ReviewerName = "Amanda Carter",
                    Rating = 3,
                    ReviewText = "A monumental work of literature, though the extensive whaling details can be challenging for modern readers.",
                    ReviewDate = new DateTime(2023, 5, 8)
                },
                
                // Book 12: War and Peace
                new BookReview
                {
                    Id = 12,
                    BookId = 12,
                    ReviewerName = "Gregory Patel",
                    Rating = 4,
                    ReviewText = "Tolstoy's masterpiece weaves personal stories with historical events to create a panoramic view of Russian society.",
                    ReviewDate = new DateTime(2023, 6, 12)
                },
                
                // Book 13: The Odyssey
                new BookReview
                {
                    Id = 13,
                    BookId = 13,
                    ReviewerName = "Olivia Martinez",
                    Rating = 5,
                    ReviewText = "The original adventure story that has influenced countless works. Homer's epic remains powerful and engaging.",
                    ReviewDate = new DateTime(2023, 7, 3)
                },
                
                // Book 14: Crime and Punishment
                new BookReview
                {
                    Id = 14,
                    BookId = 14,
                    ReviewerName = "Nathan Kim",
                    Rating = 4,
                    ReviewText = "A psychological thriller that delves deep into guilt, redemption, and human nature.",
                    ReviewDate = new DateTime(2023, 4, 18)
                },
                
                // Book 15: The Shining
                new BookReview
                {
                    Id = 15,
                    BookId = 15,
                    ReviewerName = "Rachel Thompson",
                    Rating = 5,
                    ReviewText = "King's haunted hotel story is terrifying on multiple levels. A masterclass in psychological horror.",
                    ReviewDate = new DateTime(2023, 5, 31)
                }
            );
        }
    }
}
