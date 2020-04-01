using GraphQL.Types;

namespace Books.GraphQL.Mutation
{
    public class AuthorUpdatedType: InputObjectGraphType
    {
        public AuthorUpdatedType()
        {
            Name = "authorUpdated";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}