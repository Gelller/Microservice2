using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microservice2.Data.Interfaces;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Model;
using Microservice2.Model.Dto;

namespace Microservice2.Domain.Managers.Implementation
{
    public class UsersManager:IUsersManager
    {
        private readonly IUsersRepo _userRepo;

        public UsersManager(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }
        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }
        public async Task<Guid> Create(User item)
        {         
            await _userRepo.Add(item);
            return item.Id;
        }
        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }
        public async Task Update(Guid id, User item)
        {
            item.Id = id;
            await _userRepo.Update(item);
        }
        public async Task Delete(Guid id)
        {
            await _userRepo.Delete(id);
        }
        public static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
