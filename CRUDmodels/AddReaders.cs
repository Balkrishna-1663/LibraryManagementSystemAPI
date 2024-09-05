using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.CRUDmodels
{
    public class AddReaders
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
