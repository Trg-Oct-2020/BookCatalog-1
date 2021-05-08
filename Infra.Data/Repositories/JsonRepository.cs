using BookCatalog.Domain.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookCatalog.Infra.Data.Repositories
{
    public abstract class JsonRepository<TEntity> : IJsonRepository<TEntity> where TEntity : IEntity
    {
        readonly string filePath = @".\DataStore\Book.json";

        public IQueryable<TEntity> Add(TEntity obj)
        {
            var bookDetails = ReadData;
            bookDetails.Add(obj);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return bookDetails.AsQueryable<TEntity>();
        }

        public string Delete(string id)
        {
            var bookDetails = ReadData;
            var deletedBook = bookDetails.Where(x => x.id == id);
            bookDetails.Remove(deletedBook.FirstOrDefault());
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return id;
        }

        //public void Dispose()
        //{
        //    throw new System.NotImplementedException();
        //}

        public IQueryable<TEntity> GetAll() => ReadData.AsQueryable();

        public IQueryable<TEntity> Update(TEntity obj)
        {
            var bookDetails = ReadData;
            var findBook = bookDetails.Where(x => x.id == obj.id);
            bookDetails.Remove(findBook.FirstOrDefault());
            bookDetails.Add(obj);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return bookDetails.AsQueryable<TEntity>();
        }

        public List<TEntity> ReadData
        {
            get
            {
                var readjson = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<TEntity>>(readjson);
            }
        }
    }
}
