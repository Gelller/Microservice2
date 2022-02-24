using Microservice2.Model;
using Microservice2.Model.Authentication;
using Microservice2.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Managers.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResponse> Authenticate(User user);
    }
}
