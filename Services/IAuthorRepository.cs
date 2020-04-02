using System.Threading.Tasks;
using System.Collections.Generic;
using Books.GraphQL.Entities;
using System.Linq;

namespace Books.GraphQL.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Author> DeleteAuthorAsync(Author author);

        Task<IDictionary<int, Author>> GetForBooks(IEnumerable<int> authorIds);
    }
}