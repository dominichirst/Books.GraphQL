using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using GraphQL.DataLoader;
using Books.GraphQL.Entities;
using Books.GraphQL.Services;


namespace Books.GraphQL.Types
{
    public class BookType: ObjectGraphType<Book>
    {
        public BookType(IBookRepository bookRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(b => b.Id);
            Field(b => b.Title);
            Field(b => b.Description);
        }
    }
}