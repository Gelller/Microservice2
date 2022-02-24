using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Model;

namespace Microservice2.Data.Interfaces
{
    public interface IDebitCardRepo
    {
        Task<DebitCard> GetItem(Guid id);
        Task<IEnumerable<DebitCard>> GetItems();
        Task<Guid> Add(DebitCard item);
        Task Update(Guid id, DebitCard item);
        Task Delete(Guid id);
    }
}
