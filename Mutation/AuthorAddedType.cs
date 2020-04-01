using GraphQL.Types;

namespace Books.GraphQL.Mutation
{
    public class AuthorAddedType: InputObjectGraphType
    {
        public AuthorAddedType()
        {
            Name = "authorAdded";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}