using System.Text;

namespace Wallet.Core.Models
{
    public class Operation
    {
        private Operation(string name, string description, decimal amount, Guid userId, OperationType type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Amount = amount;
            UserId = userId;
            Type = type;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Amount { get; }
        public Guid UserId {  get; }
        public OperationType Type { get; }

        public static (Operation Operation, string Error) Create(string name, string description, decimal amount, Guid userId, OperationType type)
        {
            StringBuilder errorStringBuilder = new StringBuilder();


            if (string.IsNullOrEmpty(name))
                errorStringBuilder.Append("Name is empty/n");

            return ((new Operation(name, description, amount, userId, type)), errorStringBuilder.ToString());
        }
    }
    public enum OperationType { Income, Expense }
}
