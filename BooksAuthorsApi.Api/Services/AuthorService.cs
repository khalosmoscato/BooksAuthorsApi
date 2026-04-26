using BooksAuthorsApi.Api.Models;
using System.Reflection.Metadata.Ecma335;

namespace BooksAuthorsApi.Api.Services
{
    public class AuthorService
    {
        private readonly AuthorModel _authorModel;

        public AuthorService(AuthorModel authorModel)
        {
            _authorModel = authorModel;
        }

        public List<Author> GetAllAuthors()
        {
            var authors = _authorModel.GetAuthors();

            foreach (var author in authors)
            {
                author.Books = []; // initialize list of books for each author, following the Author class properties
            }

            return authors;
        }

        public Author? GetAuthorById(int id)
        {
            var author = _authorModel.GetAuthorById(id);

            if (author != null) author.Books = [];

            return author;
        }

        public Author AddAuthor(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name)) throw new ArgumentException("Author name cannot be empty");

            _authorModel.AddAuthor(author);
            return author;
        }

        public bool DeleteAuthor(int id)
        {
            return _authorModel.DeleteAuthor(id);
        }
    }
}