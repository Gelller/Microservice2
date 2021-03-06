using AutoMapper;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Model;
using Microservice2.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUsersManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userManager.GetItem(id);
            return Ok(user);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddToCollection([FromBody] UserDto user)
        {
            var id = await _userManager.Create(_mapper.Map<User>(user));
            return Ok(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto user)
        {
            await _userManager.Update(id, _mapper.Map<User>(user));
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.Delete(id);
            return Ok();
        }
    }
}
