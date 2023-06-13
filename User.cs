namespace Basic_Authentication
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public User(string firstName, string lastName, string password, string IsAdmin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = firstName.Substring(0, 2) + lastName.Substring(0, 2);
            this.Password = password;
            if (IsAdmin.ToLower() == "yes")
            {
                this.IsAdmin = true;
            } 
            else
            {
                this.IsAdmin = false;
            }
        }

        public User()
        {
        }
    }
}
