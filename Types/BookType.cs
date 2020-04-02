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
        public BookType(IAuthorRepository authorRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(b => b.Id);
            Field(b => b.Title);
            Field(b => b.Description);

             Field<AuthorType>("author", resolve: context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Author>(
                    "GetAuthorByAuthorId", authorRepository.GetForBooks);

                return loader.LoadAsync(context.Source.AuthorId);
            });
        }
    }
}