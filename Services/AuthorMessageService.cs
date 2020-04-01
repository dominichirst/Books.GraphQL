using System.Reactive.Subjects;
using System;
using System.Reactive.Linq;
using System.Collections;

using Books.GraphQL.Entities;
using Books.GraphQL.Types;

namespace Books.GraphQL {
    public class AuthorMessageService: IAuthorMessageService
    {
        private readonly ISubject<Author> _authorAddedMessageStream = new ReplaySubject<Author>(1);
        public Author AddAuthorMessage(Author author) {
            _authorAddedMessageStream.OnNext(author);
            return author;
        }
        public IObservable<Author> GetAuthorAddedMessages() {
            return _authorAddedMessageStream.AsObservable();
        }

    }
}