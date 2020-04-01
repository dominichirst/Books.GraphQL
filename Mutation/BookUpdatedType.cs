using GraphQL.Types;

namespace Books.GraphQL.Mutation
{
    public class BookUpdatedType: InputObjectGraphType
    {
        public BookUpdatedType()
        {
            Name = "bookUpdated";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<IntGraphType>>("authorId");
            Field<StringGraphType>("description");
        }
    }
}