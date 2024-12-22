using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.DataAccess.Data
{
    public class MongoDbInitialiazer:IDbInitializer
    {
        private readonly DataContextMongo _dataContext;

        public MongoDbInitialiazer(DataContextMongo dataContext)
        {
            _dataContext = dataContext;
        }

        public async void InitializeDb()
        {
            var entities = await _dataContext.GetCollection<Preference>("Preference").Find(_ => true).ToListAsync();
            if (!entities.Any()) {
                
                _dataContext.GetCollection<Preference>("Preference").InsertMany(FakeDataFactory.Preferences);
            }

            var customers = await _dataContext.GetCollection<Customer>("Customer").Find(_ => true).ToListAsync();
            if (!customers.Any())
            {
                _dataContext.GetCollection<Customer>("Customer").InsertMany(FakeDataFactory.Customers);
            }
            
        }
    }
}
