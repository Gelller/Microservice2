using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Data.Interfaces;
using Microservice2.Ef;
using Microservice2.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservice2.Data.Implementation
{
    public class UsersRepo:IUsersRepo
    {
        private readonly DebitCardDbContext _context;
        public UsersRepo(DebitCardDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetItem(Guid id)
        {
            var result = await _context.Users.FindAsync(id);
            return result;
        }
        public async Task<Guid> Add(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public async Task<IEnumerable<User>> GetItems()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }
        public async Task Update(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Users.FindAsync(id);
            _context.Users.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return
                await _context.Users
                    .Where(x => x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }
    }
}
