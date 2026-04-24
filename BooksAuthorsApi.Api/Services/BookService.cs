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
    }
}