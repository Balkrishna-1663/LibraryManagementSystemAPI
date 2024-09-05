namespace LibraryManagementSystemAPI.CRUDmodels
{
    public class SignInReader
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
