using Microsoft.EntityFrameworkCore;

// Create the application builder
var builder = WebApplication.CreateBuilder(args);

// Get the connection string from configuration and configure the database context
var connectionString = builder.Configuration.GetConnectionString("FirstAPIDb");
builder.Services.AddDbContext<FirstAPI.Data.BookContext>(options =>
    options.UseSqlServer(connectionString));

// Register the repositorys for dependency injection
builder.Services.AddScoped<FirstAPI.Persistence.IBookRepository, FirstAPI.Persistence.BookRepository>();
builder.Services.AddScoped<FirstAPI.Persistence.IBookReviewRepository, FirstAPI.Persistence.BookReviewRepository>();

// Add controller support for API endpoints
builder.Services.AddControllers();

// Add Swagger/OpenAPI support for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enforce HTTPS redirection
app.UseHttpsRedirection();

// Set up routing
app.UseRouting();

// Enable authentication
app.UseAuthentication();

// Enable authorization
app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

// Start the application
app.Run();
