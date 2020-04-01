using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Books.GraphQL
{
    public class BooksSchema: Schema
    {
       public BooksSchema(IServiceProvider resolver): base(resolver)
        {
            Query = resolver.GetService<BooksQuery>();
            Mutation = resolver.GetService<BooksMutation>();
            Subscription = resolver.GetService<BooksSubscriptions>();
        }
    }
}