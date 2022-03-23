using Microservice2.Model;
using Microservice2.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Managers.Interfaces
{
    public interface IUsersManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Create(User user);
        Task Update(Guid id, User user);
        Task Delete(Guid id);
        Task<User> GetUser(LoginRequest request);
    }
}
