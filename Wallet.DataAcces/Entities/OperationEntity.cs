using Wallet.Core.Models;

namespace Wallet.Persistence.Entities
{
    public class OperationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public OperationType Type { get; set; }
    }
}