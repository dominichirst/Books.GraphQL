using System.Reactive.Subjects;
using System;
using System.Reactive.Linq;
using System.Collections.Generic;

using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL
{
    public class AuthorMessageService : IAuthorMessageService
    {
        private readonly ISubject<Author> _authorAddedMessageStream = new ReplaySubject<Author>(1);
        private readonly ISubject<Author> _authorUpdatedMessageStream = new ReplaySubject<Author>(1);
        private readonly ISubject<Author> _authorDeletedMessageStream = new ReplaySubject<Author>(1);

                
        public Author AddAuthorMessage(Author author)
        {
            _authorAddedMessageStream.OnNext(author);
            return author;
        }

        public IObservable<Author> GetAuthorAddedMessages()
        {
            return _authorAddedMessageStream.AsObservable();
        }

        public Author UpdateAuthorMessage(Author author)
        {
            _authorUpdatedMessageStream.OnNext(author);
            return author;
        }

        public IObservable<Author> GetAuthorUpdatedMessages()
        {
            return _authorUpdatedMessageStream.AsObservable();
        }

         public Author DeleteAuthorMessage(Author author)
        {
            _authorDeletedMessageStream.OnNext(author);
            return author;
        }

        public IObservable<Author> GetAuthorDeletedMessages()
        {
            return _authorDeletedMessageStream.AsObservable();
        }

    }
}