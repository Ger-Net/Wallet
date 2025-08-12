namespace Wallet.Core.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<OperationEntity> Operations { get; set; } = [];
    }
}
