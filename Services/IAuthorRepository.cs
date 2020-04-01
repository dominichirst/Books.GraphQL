using System.Threading.Tasks;
using System.Collections.Generic;
using Books.GraphQL.Entities;

namespace Books.GraphQL.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Author> DeleteAuthorAsync(Author author);
    }
}