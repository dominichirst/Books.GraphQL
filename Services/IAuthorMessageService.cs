using System;
using System.Reactive;
using System.Collections;

using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL {
    public interface IAuthorMessageService
    {
        Author AddAuthorMessage(Author author);
        IObservable<Author> GetAuthorAddedMessages();

    }
}