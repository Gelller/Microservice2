using Microservice2.Domain.Aggregates.DebitCardAggregate;
using Microservice2.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.UnitOfWorkCon
{
    public class UnitOfWork : IDisposable
    {
      //  private readonly DebitCardDbContext _context;
        private readonly DebitCardDbContext _db;
        private DebitCardAggregateRepo _debitCardAggregateRepo;
        public DbContextOptions<DebitCardDbContext> options = new DbContextOptions<DebitCardDbContext>();
        public UnitOfWork()
        {
            _db = new DebitCardDbContext();
        }



        public DebitCardAggregateRepo DebitCard
        {
            get
            {
                if (_debitCardAggregateRepo == null)
                    _debitCardAggregateRepo = new DebitCardAggregateRepo(_db);
                return _debitCardAggregateRepo;
            }
        }



        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
