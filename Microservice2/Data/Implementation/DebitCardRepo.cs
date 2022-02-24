using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Data.Interfaces;
using Microservice2.Ef;
using Microservice2.Model;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.IO;
using Npgsql;

namespace Microservice2.Data.Implementation
{
    public class DebitCardRepo : IDebitCardRepo
    {

        private static string ConnectionString = "Server=localhost;Port=5432;Username=postgres;Password=12345;Database=234";
        private readonly DebitCardDbContext _context;
        public DebitCardRepo(DebitCardDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(DebitCard item)
        {
            await using (var connection = new NpgsqlConnection(ConnectionString))
            {            
                connection.Execute(@"INSERT INTO debitcard (Id, Name, Surname, Money) VALUES(@Id, @Name, @Surname, @Money)",
                     new
                     {
                         Id = item.id,
                         Name = item.name,
                         surname = item.surname,
                         money = item.money
                     });
            }
            return item.id;
        }

        public async Task Delete(Guid id)
        {
            await using (var connection = new NpgsqlConnection(ConnectionString))
            {            
                connection.Execute(@"DELETE FROM debitcard WHERE id = @id",
                    new
                    {
                        id=id
                    });
            }       
        }

        public async Task<DebitCard> GetItem(Guid id)
        {
           var result = await _context.DebitCard.FindAsync(id);
           return result; 
        }

        public async Task<IEnumerable<DebitCard>> GetItems()
        {
            await using (var connection = new NpgsqlConnection(ConnectionString))
            {
               return connection.Query<DebitCard>(@"SELECT Id, Name, Surname, Money FROM debitcard").ToList();
            }
        }

        public async Task Update(Guid id, DebitCard item)
        {    
            await using (var connection = new NpgsqlConnection(ConnectionString))
            {             
                connection.Execute(@"UPDATE debitcard SET name=@name, surname=@surname, money=@money WHERE id = @id",
                    new
                    {
                        id = id,
                        name=item.name,
                        surname=item.surname,
                        money=item.money
                    }); 

            }
        }
    }
}
