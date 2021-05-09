using BookCatalog.Domain.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Infra.Persistence.Json.Repositories
{
    public abstract class JsonRepository<TEntity> : IJsonRepository<TEntity> where TEntity : IEntity
    {
        readonly string filePath = @".\Infra.Persistence.Json\DataStore\Book.json";



        public async Task<bool> AddAsync(TEntity obj)
        {
            try
            {
                var bookDetails = ReadData;
                bookDetails.Add(obj);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));

                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

        }



        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var bookDetails = ReadData;
                var deletedBook = bookDetails.Where(x => x.id == id).FirstOrDefault();
                bookDetails.Remove(deletedBook);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

        }

        //public void Dispose()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public IQueryable<TEntity> GetAll() => ReadData.AsQueryable();





        public async Task<bool> UpdateAsync(TEntity obj)
        {
            try
            {
                var bookDetails = ReadData;
                var findBook = bookDetails.Where(x => x.id == obj.id);
                bookDetails.Remove(findBook.FirstOrDefault());
                bookDetails.Add(obj);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

        }

        public List<TEntity> ReadData
        {
            get
            {
                var readjson = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<TEntity>>(readjson);
            }
        }

        public async Task<TEntity> GetById(string id) => await Task.FromResult(ReadData.Where(x => x.id == id).FirstOrDefault());






        public async Task<IQueryable<TEntity>> GetAll() => await Task.FromResult(ReadData.AsQueryable<TEntity>());

    }
}
