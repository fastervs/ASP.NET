using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Data
{
    public class EfDbInitializer:IDbInitializer
    {
        private readonly DataContext _dataContext;

        public EfDbInitializer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void InitializeDb()
        {
            /*
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();

            

            _dataContext.AddRange(FakeDataFactory.Roles);
            _dataContext.SaveChanges();

            _dataContext.AddRange(FakeDataFactory.Employees);
            _dataContext.SaveChanges();

            _dataContext.AddRange(FakeDataFactory.Preferences);
            _dataContext.SaveChanges();

            _dataContext.AddRange(FakeDataFactory.Customers);
            _dataContext.SaveChanges();*/

            //_dataContext.AddRange(FakeDataFactory.PromoCodes);
           // _dataContext.SaveChanges();

            //_dataContext.AddRange(FakeDataFactory.PromoCodePreferences);
            //_dataContext.SaveChanges();

            //_dataContext.Employees.First().Role.Add(_dataContext.Roles.First());
            //FakeDataFactory.SetRoles();
            //_dataContext.AddRange(FakeDataFactory.EmployeeRoles);
            //_dataContext.SaveChanges();
        }
    }
}
