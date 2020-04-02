using System.Threading.Tasks;
using System.Collections.Generic;
using Books.GraphQL.Entities;
using Books.GraphQL.DbContexts;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Books.GraphQL.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksContext _context;

        public AuthorRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> DeleteAuthorAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<IDictionary<int, Author>> GetForBooks(IEnumerable<int> authorsIds)
        {
            var author = await _context.Authors.Where(a => authorsIds.Contains(a.Id)).ToDictionaryAsync(a => a.Id);

            return author;
        }
    }
}