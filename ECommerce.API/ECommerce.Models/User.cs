namespace Models
{
    public class User
    {
        public int ID { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; }
        public string Password { get; set; }

        // public User() { }
        public User(string email, string password) {
            this.Email = email;
            this.Password = password;
        }
        public User(string firstName, string lastName, string email, string password) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }
        public User(int id, string firstName, string lastName, string email, string password) {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }
    }
}