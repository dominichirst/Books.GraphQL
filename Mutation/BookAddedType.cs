using GraphQL.Types;

namespace Books.GraphQL.Mutation
{
    public class BookAddedType: InputObjectGraphType
    {
        public BookAddedType()
        {
            Name = "bookAdded";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<IntGraphType>>("authorId");
            Field<StringGraphType>("description");
        }
    }
}