using Microsoft.EntityFrameworkCore;
using Books.GraphQL.Entities;

namespace Books.GraphQL.DbContexts {
    public class BooksContext: DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options): base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}