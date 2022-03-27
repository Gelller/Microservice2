using Microservice2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.MongoDb
{
    public interface IBookService
    {
        Task<Book> GetItem(Guid id);
        Task<IEnumerable<Book>> GetItems();
        Task<Guid> Add(Book item);
        Task Update(Guid id, Book item);
        Task Delete(Guid id);
    }
}
