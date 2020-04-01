using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQL;

using Books.GraphQL.Types;
using Books.GraphQL.Services;
using Books.GraphQL.Entities;
using Books.GraphQL.Mutation;

namespace Books.GraphQL
{
    public class BooksMutation : ObjectGraphType
    {
        public BooksMutation(IBookRepository bookRepository, IAuthorRepository authorRepository, IAuthorMessageService authorMessageService)
        {
            FieldAsync<BookType>(
               "createBook",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookAddedType>> { Name = "book" }),
               resolve: async context =>
               {
                   var book = context.GetArgument<Book>("book");
                   return await context.TryAsyncResolve(async c => await bookRepository.AddBookAsync(book));
               });

             FieldAsync<BookType>(
               "updateBook",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookUpdatedType>> { Name = "book" }),
               resolve: async context =>
               {
                   var book = context.GetArgument<Book>("book");
                   return await context.TryAsyncResolve(async c => await bookRepository.UpdateBookAsync(book));
               });

            FieldAsync<BookType>(
              "deleteBook",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
              resolve: async context =>
              {
                  var id = context.GetArgument<int>("id");
                  var book = await bookRepository.GetBookAsync(id);
                  return await context.TryAsyncResolve(async c => await bookRepository.DeleteBookAsync(book));
              });
            
             FieldAsync<AuthorType>(
               "createAuthor",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorAddedType>> { Name = "author" }),
               resolve: async context =>
               {
                   var author = context.GetArgument<Author>("author");
                   await authorRepository.AddAuthorAsync(author);
                   authorMessageService.AddAuthorMessage(author);
                   return author;
               });

             FieldAsync<AuthorType>(
               "updateAuthor",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookUpdatedType>> { Name = "author" }),
               resolve: async context =>
               {
                   var author = context.GetArgument<Author>("author");
                   return await context.TryAsyncResolve(async c => await authorRepository.UpdateAuthorAsync(author));
               });


            FieldAsync<AuthorType>(
              "deleteAuthor",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
              resolve: async context =>
              {
                  var id = context.GetArgument<int>("id");
                  var author = await authorRepository.GetAuthorAsync(id);
                  return await context.TryAsyncResolve(async c => await authorRepository.DeleteAuthorAsync(author));
              });
        }
    }
}