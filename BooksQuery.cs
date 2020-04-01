using GraphQL;
using GraphQL.Types;

using Books.GraphQL.Types;
using Books.GraphQL.Services;

namespace Books.GraphQL
{
    public class BooksQuery : ObjectGraphType
    {
        public BooksQuery(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            Field<ListGraphType<AuthorType>>(
              "authors",
              resolve: context => authorRepository.GetAuthorsAsync());

            Field<AuthorType>(
            "author",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return authorRepository.GetAuthorAsync(id);
            });

            Field<ListGraphType<BookType>>(
               "books",
               resolve: context => bookRepository.GetBooksAsync());

            Field<BookType>(
               "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<int>("id");
                   return bookRepository.GetBookAsync(id);
               });

        }
    }
}