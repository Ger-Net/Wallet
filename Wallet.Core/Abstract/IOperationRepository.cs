using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Models;

namespace Wallet.Core.Abstract
{
    public interface IOperationRepository
    {
        Task<Guid> Create(Operation operation);
        Task<Guid> Delete(Guid id);
        Task<Operation> Get(Guid id);
        Task<Guid> Update(Guid id, string name, string description, decimal amount, OperationType type);
    }
}
