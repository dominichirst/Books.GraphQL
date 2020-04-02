using System.Threading.Tasks;
using System.Collections.Generic;
using Books.GraphQL.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Books.GraphQL.DbContexts;

namespace Books.GraphQL.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext _context;
        public BookRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Book> AddBookAsync(Book task)
        {
            _context.Books.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<ILookup<int, Book>> GetForAuthors(IEnumerable<int> authorsIds)
        {
            var books = await _context.Books.Where(b => authorsIds.Contains(b.AuthorId)).ToListAsync();

            return books.ToLookup(b => b.AuthorId);
        }
    }
}