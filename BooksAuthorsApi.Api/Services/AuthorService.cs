using BooksAuthorsApi.Api.Models;

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
    }
}