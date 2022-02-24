using Microservice2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Managers.Interfaces
{
    public interface IDebitCardManager
    {
        Task<DebitCard> GetItem(Guid id);
        Task<IEnumerable<DebitCard>> GetItems();
        Task<Guid> Add(DebitCard item);
        Task Update(Guid id, DebitCard item);
        Task Delete(Guid id);
    }
}
