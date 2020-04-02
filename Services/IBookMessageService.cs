using System;
using System.Reactive;
using System.Collections;

using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL {
    public interface IBookMessageService
    {
        Book AddBookMessage(Book book);
        IObservable<Book> GetBookAddedMessages();
        Book UpdateBookMessage(Book book);
        IObservable<Book> GetBookUpdatedMessages();

        Book DeleteBookMessage(Book book);
        IObservable<Book> GetBookDeletedMessages();

    }
}