using LibraryManagementSystemAPI.Models.Data;

namespace LibraryManagementSystemAPI.CRUDmodels
{
    public class AddBook
    {
        public required string Title { get; set; }
        public string? Edition { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
