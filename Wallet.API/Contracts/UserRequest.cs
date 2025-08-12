using Wallet.Core.Models;

namespace Wallet.API.Contracts
{
    public record UserRequest(
        string Name,
        string Email,
        string Password);
}
