namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using Models;
    using Data;
    using System.Linq;
    using System;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models.Customers;
    using CarDealer.Services.Models.Sales;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public CustomerIdInfoModel AllCarsByCustommer(int id)
        {
            return db.Customers.Where(p => p.Id == id).Select(c => new CustomerIdInfoModel
            {
                
                Name = c.Name,
                IsYoungDriver=c.IsYoungDriver,
                BoughtCars=c.Sales.Select(s=> new SalesModel
                {
                    Price=s.Car.Parts.Sum(p=>p.Part.Price),
                    Discount=s.Discount
                })

            }).FirstOrDefault();

        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderedDirection order)
        {
            var customerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderedDirection.Ascending:
                    customerQuery = customerQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.Name);
                    break;
                case OrderedDirection.Descending:
                    customerQuery = customerQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction {order}");

            }
            return customerQuery
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDribver = c.IsYoungDriver
                })
                .ToList();
        }

       

        
    }
}
