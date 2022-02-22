using Microservice2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Aggregates.DebitCardAggregate
{
    public interface IDebitCardAggregateRepo
    {
        Task<IEnumerable<DebitCard>> GetItems();
        Task Update(Guid id, DebitCard item);
        Task Delete(Guid id);
        Task<DebitCard> GetItem(Guid id);
        Task<Guid> Add(DebitCard item);
    }
}
