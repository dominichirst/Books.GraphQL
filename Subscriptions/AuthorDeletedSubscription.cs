using GraphQL.Types;
using GraphQL;
using GraphQL.Resolvers;
using Books.GraphQL.Services;
using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL.Subscriptions {
    public class AuthorDeletedSubscription: EventStreamFieldType {
        public AuthorDeletedSubscription(IAuthorMessageService authorMessageService)
        {
            Name = "authorDeleted";
            Type = typeof(AuthorType);
            Resolver = new FuncFieldResolver<Author>(c => c.Source as Author);
            Subscriber = new EventStreamResolver<Author>(c => authorMessageService.GetAuthorDeletedMessages());
        }
    }
}