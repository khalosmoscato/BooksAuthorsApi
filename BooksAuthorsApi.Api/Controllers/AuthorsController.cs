using Microsoft.AspNetCore.Mvc;
using BooksAuthorsApi.Api.Models;
using BooksAuthorsApi.Api.Services;

namespace BooksAuthorsApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _authorService;

    public AuthorsController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public ActionResult<List<Author>> GetAll()
    {
        var authors = _authorService.GetAllAuthors();
        if (authors == null) return NotFound();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public ActionResult<Author> GetById(int id)
    {
        var author = _authorService.GetAuthorById(id);

        if (author == null) return NotFound($"Author with ID {id} not found.");

        return Ok(author);
    }
}