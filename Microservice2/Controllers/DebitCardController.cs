﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Model;
using Microservice2.Model.Dto;
using AutoMapper;
using Microservice2.Domain.Managers.Interfaces;
using Microservice2.Domain.Managers.Implementation;

namespace Microservice2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitCardController : ControllerBase
    {

        private readonly IDebitCardManager _debitCardManager;
        private readonly IMapper _mapper;
        private readonly ILogger<DebitCardController> _logger;

        public DebitCardController(ILogger<DebitCardController> logger, IDebitCardManager debitCardManager, IMapper mapper)
        {
            _debitCardManager = debitCardManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetDebitCards")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _debitCardManager.GetItems();
            return Ok(result);
        }

        [HttpGet("GetDebitCard/{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _debitCardManager.GetItem(id);
            return Ok(result);
        }

        [HttpPost("AddDebitCard")]
        public async Task<IActionResult> AddToCollection([FromBody] DebitCardDto debitCard)
        {
            var id = await _debitCardManager.Add(_mapper.Map<DebitCard>(debitCard));
            return Ok(id);
        }

        [HttpPut("UpdateDebitCard/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DebitCardDto debitCard)
        {
            await _debitCardManager.Update(id, _mapper.Map<DebitCard>(debitCard));
            return Ok();
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _debitCardManager.Delete(id);
            return Ok();
        }
    }
}
