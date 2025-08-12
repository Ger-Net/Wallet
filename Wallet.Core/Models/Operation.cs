using System.Text;

namespace Wallet.Core.Models
{
    public class Operation
    {
        private Operation(string name, string description, decimal amount, User user, OperationType type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Amount = amount;
            UserId = user.Id;
            User = user;
            Type = type;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Amount { get; }
        public Guid UserId {  get; }
        public User User { get; }
        public OperationType Type { get; }

        public static (Operation Operation, string Error) Create(string name, string description, decimal amount, User user, OperationType type)
        {
            StringBuilder errorStringBuilder = new StringBuilder();


            if (string.IsNullOrEmpty(name))
                errorStringBuilder.Append("Name is empty/n");
           

            return ((new Operation(name, description, amount, user, type)), errorStringBuilder.ToString());
        }
    }
    public enum OperationType { Income, Expense }
}
