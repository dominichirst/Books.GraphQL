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
        Author UpdateAuthorMessage(Author author);
        IObservable<Author> GetAuthorUpdatedMessages();

        Author DeleteAuthorMessage(Author author);
        IObservable<Author> GetAuthorDeletedMessages();

    }
}