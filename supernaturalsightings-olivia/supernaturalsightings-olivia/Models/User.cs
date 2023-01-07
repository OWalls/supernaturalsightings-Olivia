
namespace supernaturalsightings_olivia.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public User(string email, string password, string confirmPassword) 
        { 
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

    }
}
