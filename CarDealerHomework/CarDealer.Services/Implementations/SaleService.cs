namespace CarDealer.Services.Implementations
{
    using System;
    using CarDealer.Data;
    using System.Collections.Generic;
    using CarDealer.Services.Models.Sales;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleListModel> All()
       => this.db
            .Sales
            .Select(s => new SaleListModel
            {
                CustomerName = s.Customer.Name,
                Price = s.Car.Parts.Sum(c => c.Part.Price),
                IsYoungDriver = s.Customer.IsYoungDriver,
                Discount = s.Discount
               
            }).ToList();
    }
}
