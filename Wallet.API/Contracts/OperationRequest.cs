using Wallet.Core.Models;

namespace Wallet.API.Contracts
{
    public record OperationRequest(
        string Name, 
        string Desription,
        decimal Amount, 
        OperationType Type);
}
