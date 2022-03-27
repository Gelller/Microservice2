using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Authorization;
using Microservice2.UnitOfWorkCon;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.IdentityModel.Protocols;
using Microservice2.MongoDb;

namespace Microservice2.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BookController : Microservice2BaseController
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IMapper mapper, IBookService bookService)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books =await _bookService.GetItems();
            return Ok(books);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _bookService.GetItem(id);       
            return Ok(book);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddToCollection([FromBody] BookDto book)
        {
            var id =  await _bookService.Add(_mapper.Map<Book>(book));
            return Ok(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BookDto book)
        {         
            await _bookService.Update(id, _mapper.Map<Book>(book));
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _bookService.Delete(id);
            return Ok();
        }
    }
}
