using System.Text;

namespace Wallet.Core.Models
{
    public class User
    {
        private User(string username,string email, string password, List<Operation> operations)
        {
            Id = Guid.NewGuid();
            Name = username;
            Email = email;
            Password = password;
            Operations = operations;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public List<Operation> Operations { get; }
        public static (User User, string Error) CreateUser(string name, string email, string password, List<Operation> operations)
        {
            StringBuilder errorStringBuilder = new StringBuilder();


            if (string.IsNullOrEmpty(name))
                errorStringBuilder.Append("Name is empty/n");
            if (string.IsNullOrEmpty(email))
                errorStringBuilder.Append("Email is empty/n");
            if (string.IsNullOrEmpty(password))
                errorStringBuilder.Append("Password is empty/n");

            return ((new User(name, email, password, operations)),errorStringBuilder.ToString());
        }
    }
}
