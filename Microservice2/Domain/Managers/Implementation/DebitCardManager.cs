using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Data.Implementation;
using Microservice2.Data.Interfaces;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Model;
using Microservice2.Domain.Aggregates.DebitCardAggregate;

namespace Microservice2.Domain.Managers.Implementation
{
    public class DebitCardManager : IDebitCardManager
    {

        private readonly IDebitCardRepo _debitCardRepo;
        private readonly IDebitCardAggregateRepo _debitCardAggregateRepo;

        public DebitCardManager(IDebitCardRepo debitCardRepo, IDebitCardAggregateRepo debitCardAggregateRepo)
        {
            _debitCardAggregateRepo = debitCardAggregateRepo;
            _debitCardRepo = debitCardRepo;
        }

        public async Task<Guid> Add(DebitCard item)
        {
            var debitCard = DebitCardAggregate.Create(item.name, item.surname, item.money);
            await _debitCardAggregateRepo.Add(debitCard);
            return debitCard.id;
        }

        public async Task Delete(Guid id)
        {
            await _debitCardAggregateRepo.Delete(id);
        }

        public async Task<DebitCard> GetItem(Guid id)
        {
            return await _debitCardAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<DebitCard>> GetItems()
        {
           return await _debitCardAggregateRepo.GetItems();
        }

        public async Task Update(Guid id, DebitCard item)
        {
            await _debitCardAggregateRepo.Update(id, item);
        }    
    }
}
