using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string publisherName { get; set; }
        public ICollection<Book> bookName { get; set; } 
        public DateOnly dateOfPublish { get; set; }
        public int Year { get; set; }
    }
}
