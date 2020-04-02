using System.Reactive.Subjects;
using System;
using System.Reactive.Linq;
using System.Collections.Generic;

using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL
{
    public class BookMessageService : IBookMessageService
    {
        private readonly ISubject<Book> _BookAddedMessageStream = new ReplaySubject<Book>(1);
        private readonly ISubject<Book> _BookUpdatedMessageStream = new ReplaySubject<Book>(1);
        private readonly ISubject<Book> _BookDeletedMessageStream = new ReplaySubject<Book>(1);

        public Book AddBookMessage(Book book)
        {
            _BookAddedMessageStream.OnNext(book);
            return book;
        }

        public IObservable<Book> GetBookAddedMessages()
        {
            return _BookAddedMessageStream.AsObservable();
        }

        public Book UpdateBookMessage(Book book)
        {
            _BookUpdatedMessageStream.OnNext(book);
            return book;
        }

        public IObservable<Book> GetBookUpdatedMessages()
        {
            return _BookUpdatedMessageStream.AsObservable();
        }

         public Book DeleteBookMessage(Book book)
        {
            _BookDeletedMessageStream.OnNext(book);
            return book;
        }

        public IObservable<Book> GetBookDeletedMessages()
        {
            return _BookDeletedMessageStream.AsObservable();
        }

    }
}