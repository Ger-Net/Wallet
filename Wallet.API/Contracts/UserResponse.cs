using Wallet.Core.Models;

namespace Wallet.API.Contracts
{
    public record UserResponse(
        Guid Id, 
        string Name, 
        string Email,
        string Password);

}
