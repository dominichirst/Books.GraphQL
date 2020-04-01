using System.ComponentModel.DataAnnotations;

namespace Books.GraphQL.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}