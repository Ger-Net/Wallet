using System.ComponentModel.DataAnnotations;

namespace Wallet22.MVVM.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Operation>? Operations { get; set; }
        public List<User>? Friends { get; set; }

        public void Init(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
            Operations = new();
            Friends = new();
        }
    }
}
