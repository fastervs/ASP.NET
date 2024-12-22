using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.DataAccess.Repositories
{
    public class MongoRepository<T>:IRepository<T> 
        where T : BaseEntity
    {
        private readonly DataContextMongo _dataContext;

        public MongoRepository(DataContextMongo dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //var entities = await _dataContext.Set<T>().ToListAsync();
            string entityName=typeof(T).Name;

            var entities = await _dataContext.GetCollection<T>(entityName).Find(_ => true).ToListAsync();

            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            string entityName = typeof(T).Name;
            var entity = await _dataContext.GetCollection<T>(entityName).
                Find(entity => entity.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            string entityName = typeof(T).Name;
            var entities = await _dataContext.GetCollection<T>(entityName).Find(x => ids.Contains(x.Id)).ToListAsync();
            return entities;
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            string entityName = typeof(T).Name;
            return  await _dataContext.GetCollection<T>(entityName).AsQueryable().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            string entityName = typeof(T).Name;
            return await _dataContext.GetCollection<T>(entityName).AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            string entityName = typeof(T).Name;
            await _dataContext.GetCollection<T>(entityName).InsertOneAsync(entity);
            
        }

        public async Task UpdateAsync(T entity)
        {
            string entityName = typeof(T).Name;
            await _dataContext.GetCollection<T>(entityName).
                ReplaceOneAsync(oldentity => oldentity.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            string entityName = typeof(T).Name;
            await _dataContext.GetCollection<T>(entityName).
                DeleteOneAsync(oldentity => oldentity.Id == entity.Id);
        }
    }
}
