using LibraryManagementSystemAPI.Models.Data;

namespace LibraryManagementSystemAPI.Models
{
    public class Book
    {
       public int Id { get; set; }
        public required string Title { get; set; }
        public string? Edition { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

    }
}
