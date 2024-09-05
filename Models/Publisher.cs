namespace LibraryManagementSystemAPI.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string bookName { get; set; } 
        public DateOnly dateOfPublish { get; set; }
        public int Year { get; set; }
     
    }
}
