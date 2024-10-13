﻿using System;
using System.Collections.Generic;
using System.Linq;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static IEnumerable<Role> Roles => new List<Role>()
        {
            new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Admin",
                Description = "Администратор",

            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "PartnerManager",
                Description = "Партнерский менеджер"
            }
        };

        public static IEnumerable<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                Roles = new List<EmployeeRole>()
                {
                    new EmployeeRole()
                    {
                        RoleId=Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                        EmployeeId=Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f")

                    }
                },
                AppliedPromocodesCount = 5,
                
            },
            new Employee()
            {
                Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                Roles = new List<EmployeeRole>()
                {

                },
                AppliedPromocodesCount = 10
            },
        };

        

        public static IEnumerable<Preference> Preferences => new List<Preference>()
        {
            new Preference()
            {
                Id = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                Name = "Театр",
            },
            new Preference()
            {
                Id = Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                Name = "Семья",
            },
            new Preference()
            {
                Id = Guid.Parse("76324c47-68d2-472d-abb8-33cfa8cc0c84"),
                Name = "Дети",
            }
        };

        public static IEnumerable<Customer> Customers
        {
            get
            {
                var customerId = Guid.Parse("a6c8c6b1-4349-45b0-ab31-244740aaf0f0");
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = customerId,
                        Email = "ivan_sergeev@mail.ru",
                        FirstName = "Иван",
                        LastName = "Петров",
                        Preferences = new List<CustomerPreference>()
                        {
                            new CustomerPreference()
                            {
                                CustomerId=customerId,
                                PreferenceId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")

                            }
                        }
                        //TODO: Добавить предзаполненный список предпочтений
                    }
                };

                return customers;
            }
        }

        public static IEnumerable<PromoCode> PromoCodes
        {
            get
            {
                var promoCodes = new List<PromoCode>()
                {
                    new PromoCode() {
                        Id=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99e"),
                        Code="BlaBla",
                        BeginDate=DateTime.Now,
                        EndDate=DateTime.Now.AddDays(10),
                        PartnerName="Рога и Копыта",
                        PreferenceId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")
                    }
                };

                
                return promoCodes;
            }
        }

        public static IEnumerable<PromoCodePreference> PromoCodePreferences => new List<PromoCodePreference>()
        {
            new PromoCodePreference()
            {
                PreferenceId = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                PromoCodeId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99e")
            }
           
        };
        /*
       public static IEnumerable<EmployeeRole> EmployeeRoles => new List<EmployeeRole>()
       {
           new EmployeeRole()
           {
               EmployeeId=Employees.First().Id,
               RoleId=Roles.First().Id
           }

       };

       public static void SetRoles()
       {

           Employees.First().Role.Add(Roles.FirstOrDefault(x => x.Name == "Admin"));
           Employees.Last().Role.Add(Roles.FirstOrDefault(x => x.Name == "PartnerManager"));
       }*/
    }
}