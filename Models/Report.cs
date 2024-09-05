using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public Book BookName { get; set; }
        public Reader ReaderName { get; set; }
        public DateOnly ReturnDate { get; set; }

    }
}
