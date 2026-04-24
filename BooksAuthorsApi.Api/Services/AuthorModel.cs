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

    public Author? GetAuthorById(int id)
    {
        return GetAuthors().FirstOrDefault(a => a.Id == id);
    }

    public void AddAuthor(Author newAuthor)
    {
        var authors = GetAuthors();

        int newId = authors.Any() ? authors.Max(a => a.Id) + 1 : 1;
        newAuthor.Id = newId;

        authors.Add(newAuthor);

        SaveAuthors(authors); // calls the funciton below, because we need to save the newly added author into our Authors.json
    }

    private void SaveAuthors(List<Author> authors) // to save the authors we are posting
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(authors, options);
        File.WriteAllText(_authorsPath, json);
    }

    public List<Book> GetBooks()
    {
        var json = File.ReadAllText(_booksPath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
    }

    public Book? GetBookById(int id)
    {
        return GetBooks().FirstOrDefault(a => a.Id == id);
    }
}