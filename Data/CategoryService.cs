//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Models;
//using MongoDB.Driver;
//using Microsoft.Extensions.Options;

//namespace Data
//{
//    public class CategoryService
//    {
//        private readonly IMongoCollection<Category> _collection;

//        public CategoryService(
//            IOptions<DatabaseSettings> bookStoreDatabaseSettings)
//        {
//            var mongoClient = new MongoClient(
//                bookStoreDatabaseSettings.Value.ConnectionString);

//            var mongoDatabase = mongoClient.GetDatabase(
//                bookStoreDatabaseSettings.Value.DatabaseName);

//            _collection = mongoDatabase.GetCollection<Category>(
//                bookStoreDatabaseSettings.Value.CollectionName);
//        }

//        public async Task<List<Category>> GetAsync() =>
//            await _collection.Find(_ => true).ToListAsync();

//        public async Task<Category?> GetAsync(string id) =>
//            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

//        public async Task CreateAsync(Category newBook) =>
//            await _collection.InsertOneAsync(newBook);

//        public async Task UpdateAsync(string id, Category updatedBook) =>
//            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

//        public async Task RemoveAsync(string id) =>
//            await _collection.DeleteOneAsync(x => x.Id == id);
//    }
//}
