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
                book.Author = null;
            }

            return books;
        }

        public Book? GetBookById(int id)
        {
            var book = _authorModel.GetBookById(id);

            if (book != null) book.Author = null;

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
    }
}