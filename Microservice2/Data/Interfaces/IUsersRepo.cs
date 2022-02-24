using Microservice2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Data.Interfaces
{
    public interface IUsersRepo
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Add(User item);
        Task Update(User item);
        Task Delete(Guid id);
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
    }
}
