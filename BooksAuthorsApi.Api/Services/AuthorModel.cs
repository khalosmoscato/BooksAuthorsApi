using System.Text.Json;
using BooksAuthorsApi.Api.Models;

namespace BooksAuthorsApi.Api.Services;

public class AuthorModel
{
    private readonly string _authorsPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Authors.json");
    private readonly string _booksPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Books.json");

    public List<Author> GetAuthors()
    {
        var json = File.ReadAllText(_authorsPath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<Author>>(json, options) ?? new List<Author>();
    }

    public List<Book> GetBooks()
    {
        var json = File.ReadAllText(_booksPath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
    }
}