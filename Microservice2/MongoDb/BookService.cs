using Microservice2.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Microservice2.MongoDb
{
    public class BookService : IBookService
    {

       private readonly IMongoCollection<Book> _book;
        public BookService(IBookDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _book = database.GetCollection<Book>(settings.BookCollectionName);

        }
        public async Task<Book> GetItem(Guid id)
        {
            var result = await _book.Find<Book>(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Book>> GetItems()
        {       
            List<Book> book = await _book.Find(x => true).ToListAsync();
            return book;
        }

        public async Task<Guid> Add(Book item)
        {
             await _book.InsertOneAsync(item);
            return item.Id;
        }

        public async Task Update(Guid id, Book book)
        {
            var builder = Builders<Book>.Filter;
            var filter = builder.Eq("Id", id);

            var update = Builders<Book>.Update
                .Set(x => x.Name, book.Name)
                .Set(x => x.Price, book.Price);
             await _book.UpdateOneAsync(filter, update);
        }

        public async Task Delete(Guid id)
        {
            await _book.DeleteOneAsync(x => x.Id == id);
        }
    }
}
