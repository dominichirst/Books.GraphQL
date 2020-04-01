using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using GraphQL.DataLoader;
using Books.GraphQL.Entities;
using Books.GraphQL.Services;


namespace Books.GraphQL.Types
{
    public class AuthorType : AutoRegisteringObjectGraphType<Author>
    {
        public AuthorType(IBookRepository bookRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Name = "AuthorType";
            
            Field<ListGraphType<BookType>>("books", resolve: context =>
            {
                var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Book>(
                    "GetBooksByAuthorId", bookRepository.GetForAuthors);

                return loader.LoadAsync(context.Source.Id);
            });

        }
    }
}