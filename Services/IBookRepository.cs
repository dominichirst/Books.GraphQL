using System.Threading.Tasks;
using System.Collections.Generic;
using Books.GraphQL.Entities;
using System.Linq;

namespace Books.GraphQL.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> AddBookAsync(Book task);
        Task<Book> UpdateBookAsync(Book book);
        Task<Book> DeleteBookAsync(Book book);
        Task<ILookup<int, Book>> GetForAuthors(IEnumerable<int> authorsIds);
    }
}