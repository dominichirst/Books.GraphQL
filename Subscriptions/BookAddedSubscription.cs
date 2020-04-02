using GraphQL.Types;
using GraphQL;
using GraphQL.Resolvers;
using Books.GraphQL.Services;
using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL.Subscriptions {
    public class BookAddedSubscription: EventStreamFieldType {
        public BookAddedSubscription(IBookMessageService bookMessageService)
        {
            Name = "bookAdded";
            Type = typeof(BookType);
            Resolver = new FuncFieldResolver<Book>(c => c.Source as Book);
            Subscriber = new EventStreamResolver<Book>(c => bookMessageService.GetBookAddedMessages());
        }
    }
}