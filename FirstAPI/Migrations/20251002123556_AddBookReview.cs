using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBookReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookReviews",
                columns: new[] { "Id", "BookId", "Rating", "ReviewDate", "ReviewText", "ReviewerName" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beautifully written with complex characters, though the pacing felt slow at times.", "Jane Smith" },
                    { 2, 2, 5, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A powerful exploration of racial injustice that remains relevant today.", "Robert Johnson" },
                    { 3, 3, 5, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orwell's dystopian vision is disturbingly prescient. A must-read for everyone.", "Sarah Williams" },
                    { 4, 4, 5, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austen's wit and social commentary shine in this timeless romance.", "Emily Chen" },
                    { 5, 5, 4, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holden Caulfield's voice is authentic and raw, speaking to teenage alienation across generations.", "Michael Brown" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title", "Year" },
                values: new object[,]
                {
                    { 6, "Gabriel García Márquez", "One Hundred Years of Solitude", 1967 },
                    { 7, "Aldous Huxley", "Brave New World", 1932 },
                    { 8, "J.R.R. Tolkien", "The Lord of the Rings", 1954 },
                    { 9, "J.K. Rowling", "Harry Potter and the Philosopher's Stone", 1997 },
                    { 10, "J.R.R. Tolkien", "The Hobbit", 1937 },
                    { 11, "Herman Melville", "Moby-Dick", 1851 },
                    { 12, "Leo Tolstoy", "War and Peace", 1869 },
                    { 13, "Homer", "The Odyssey", -800 },
                    { 14, "Fyodor Dostoevsky", "Crime and Punishment", 1866 },
                    { 15, "Stephen King", "The Shining", 1977 }
                });

            migrationBuilder.InsertData(
                table: "BookReviews",
                columns: new[] { "Id", "BookId", "Rating", "ReviewDate", "ReviewText", "ReviewerName" },
                values: new object[,]
                {
                    { 6, 6, 5, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magical realism at its finest. A multi-generational epic that blends fantasy with history.", "Sofia Rodriguez" },
                    { 7, 7, 4, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huxley's vision of a pleasure-obsessed society feels increasingly relevant.", "Thomas Wilson" },
                    { 8, 8, 5, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The definitive fantasy epic that created a genre. Unmatched in scope and imagination.", "Alex Morgan" },
                    { 9, 9, 5, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The beginning of a magical journey that captivated a generation. Perfect for readers of all ages.", "Lily Zhang" },
                    { 10, 10, 4, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "A charming adventure story that serves as the perfect introduction to Middle-earth.", "David Lee" },
                    { 11, 11, 3, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A monumental work of literature, though the extensive whaling details can be challenging for modern readers.", "Amanda Carter" },
                    { 12, 12, 4, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tolstoy's masterpiece weaves personal stories with historical events to create a panoramic view of Russian society.", "Gregory Patel" },
                    { 13, 13, 5, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The original adventure story that has influenced countless works. Homer's epic remains powerful and engaging.", "Olivia Martinez" },
                    { 14, 14, 4, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "A psychological thriller that delves deep into guilt, redemption, and human nature.", "Nathan Kim" },
                    { 15, 15, 5, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "King's haunted hotel story is terrifying on multiple levels. A masterclass in psychological horror.", "Rachel Thompson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
