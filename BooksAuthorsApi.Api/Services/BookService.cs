using BooksAuthorsApi.Api.Models;

namespace BooksAuthorsApi.Api.Services
{
    public class BookService
    {
        private readonly AuthorModel _authorModel;

        public BookService(AuthorModel authorModel)
        {
            _authorModel = authorModel;
        }


        public List<Book> GetAllBooks()
        {
            var books = _authorModel.GetBooks();

            foreach (var book in books)
            {
                book.Author = _authorModel.GetAuthorById(book.AuthorId);
            }

            return books;
        }

        public Book? GetBookById(int id)
        {
            var book = _authorModel.GetBookById(id);

            if (book != null) book.Author = _authorModel.GetAuthorById(book.AuthorId);

            return book;
        }

        public Book AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title)) throw new ArgumentException("Book title cannot be empty");


            var authorExists = _authorModel.GetAuthorById(book.AuthorId);

            if (authorExists == null) throw new ArgumentException($"Cannot add book. Author with ID {book.AuthorId} not found.");

            _authorModel.AddBook(book);
            return book;
        }

        public bool DeleteBook(int id)
        {
            return _authorModel.DeleteBook(id);
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            var author = _authorModel.GetAuthorById(authorId);

            if (author == null) throw new ArgumentException($"Cannnot find Author with ID {authorId}");
            var books = _authorModel.GetBooksByAuthor(authorId);

            foreach (var book in books)
            {
                book.Author = author;
            }

            return books;
        }
    }
}