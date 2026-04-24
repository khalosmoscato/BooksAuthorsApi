namespace BooksAuthorsApi.Api.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty; // Changed from AuthorId to match JSON
    public int Year { get; set; }
}