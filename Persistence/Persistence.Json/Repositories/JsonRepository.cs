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
        readonly string filePath = @".\Persistence\Persistence.Json\DataStore\Book.json";



        public async Task<bool> AddAsync(TEntity obj)
        {
            try
            {
                ReadData.Add(obj);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(ReadData));

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
                ReadData.Remove(ReadData.Where(x => x.id == id).FirstOrDefault());
                File.WriteAllText(filePath, JsonConvert.SerializeObject(ReadData));
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
                ReadData.Remove(ReadData.Where(x => x.id == obj.id).FirstOrDefault());
                ReadData.Add(obj);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(ReadData));
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
                return JsonConvert.DeserializeObject<List<TEntity>>(File.ReadAllText(filePath));
            }
        }

        public async Task<TEntity> GetById(string id) => await Task.FromResult(ReadData.Where(x => x.id == id).FirstOrDefault());






        public async Task<IQueryable<TEntity>> GetAll() => await Task.FromResult(ReadData.AsQueryable<TEntity>());

    }
}
