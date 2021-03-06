﻿namespace CarDealer.Services.Implementations
{
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services.Models.Suppliers;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<SupplierModel> All(bool isImporter)
        => this.db
            .Supplaiers
            .Where(s => s.IsImporter)
            .Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name,
                TotalParts = s.Parts.Count
            })
            .ToList();

        
    }
}
