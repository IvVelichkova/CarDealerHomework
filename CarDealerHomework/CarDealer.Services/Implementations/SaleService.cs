namespace CarDealer.Services.Implementations
{
    using System;
    using CarDealer.Data;
    using System.Collections.Generic;
    using CarDealer.Services.Models.Sales;
    using System.Linq;
    using CarDealer.Services.Models.Cars;

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
                Id = s.Id,
                CustomerName = s.Customer.Name,
                Price = s.Car.Parts.Sum(c => c.Part.Price),
                IsYoungDriver = s.Customer.IsYoungDriver,
                Discount = s.Discount

            }).ToList();

        public SaleDetailsModel Details(int id)
        => this.db.Sales.Where(s => s.Id == id).Select(c => new SaleDetailsModel
        {
            Id = c.Id,
            CustomerName = c.Customer.Name,
            Price = c.Car.Parts.Sum(p => p.Part.Price),
            IsYoungDriver = c.Customer.IsYoungDriver,
            Discount = c.Discount,
            Car = new CarModel
            {
                Make = c.Car.Make,
                Model = c.Car.Model,
                TravelledDistance = c.Car.TravelDistance
            }
        }).FirstOrDefault();

        public IEnumerable<SalesDiscountedListModel> Discounted()
        => this.db.Sales
            .Where(s => s.Discount != 0)
            .Select(n => new SalesDiscountedListModel
            {
                
                CustomerName = n.Customer.Name,
                Car = new CarModel
                {
                    Make = n.Car.Make,
                    Model = n.Car.Model,
                    TravelledDistance = n.Car.TravelDistance
                }
            }).OrderBy(k => k.Car.Make)
            .ToList();

        public IEnumerable<SalesDiscountedListModel> Discounted(double percent)
            =>this.db.Sales
            .Where(s=>s.Discount == percent)
             .Select(n => new SalesDiscountedListModel
            {
                Id=n.Id,
                CustomerName = n.Customer.Name,
                Car = new CarModel
                {
                    Make = n.Car.Make,
                    Model = n.Car.Model,
                    TravelledDistance = n.Car.TravelDistance
                }
            }).OrderBy(k => k.Car.Make)
            .ToList();
    }
}
