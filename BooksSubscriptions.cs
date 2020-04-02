using System;
using GraphQL.Types;
using Books.GraphQL.Services;
using Books.GraphQL.Entities;
using Books.GraphQL.Subscriptions;
using Microsoft.Extensions.DependencyInjection;

namespace Books.GraphQL {
    public class BooksSubscriptions: ObjectGraphType {
        public BooksSubscriptions(IServiceProvider resolver)
        {
            Name = "Subscription";
            AddField(resolver.GetService<AuthorAddedSubscription>());
            AddField(resolver.GetService<AuthorUpdatedSubscription>());
            AddField(resolver.GetService<AuthorDeletedSubscription>());
            AddField(resolver.GetService<BookAddedSubscription>());
            AddField(resolver.GetService<BookUpdatedSubscription>());
            AddField(resolver.GetService<BookDeletedSubscription>());
        }
    }
}