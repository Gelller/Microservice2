using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Domain.Aggregates;
using Microservice2.Ef;
using Microservice2.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservice2.Domain.Aggregates.DebitCardAggregate
{
    public class DebitCardAggregateRepo : IDebitCardAggregateRepo
    {
        private readonly DebitCardDbContext _context;
        public DebitCardAggregateRepo(DebitCardDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(DebitCard item)
        {
            await _context.DebitCard.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.id;
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.DebitCard.FindAsync(id);
            _context.DebitCard.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<DebitCard> GetItem(Guid id)
        {
            var result = await _context.DebitCard.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<DebitCard>> GetItems()
        {
            var result = await _context.DebitCard.ToListAsync();
            return result;
        }

        public async Task Update(Guid id, DebitCard item)
        {
            var debitCard = DebitCardAggregate.Update(id, item);
            _context.DebitCard.Update(debitCard);
            await _context.SaveChangesAsync();
        }
    }
}
