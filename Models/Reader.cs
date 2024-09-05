namespace LibraryManagementSystemAPI.Models
{
    public class Reader
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Book> books { get; set; }
    }


}
