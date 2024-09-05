namespace LibraryManagementSystemAPI.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Book BookName { get; set; }
        public Reader ReaderName { get; set; }
        public DateOnly ReturnDate { get; set; }

    }
}
