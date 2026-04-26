using Microsoft.AspNetCore.Mvc;
using BooksAuthorsApi.Api.Models;
using BooksAuthorsApi.Api.Services;

namespace BooksAuthorsApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<Book>> GetAll()
    {
        var books = _bookService.GetAllBooks();
        if (books == null) return NotFound();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = _bookService.GetBookById(id);

        if (book == null) return NotFound($"Book with ID {id} not found.");

        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> Create(Book newBook)
    {
        try
        {
            var createdBook = _bookService.AddBook(newBook);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _bookService.DeleteBook(id);

        if (!deleted)
        {
            return NotFound($"Book with ID {id} not found.");
        }

        return NoContent();
    }

    [HttpGet("author/{authorId}")]
    public ActionResult<IEnumerable<Book>> GetByAuthor(int authorId)
    {
        var books = _bookService.GetBooksByAuthor(authorId);
        return Ok(books);
    }
}