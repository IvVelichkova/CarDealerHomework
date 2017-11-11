namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services.Models;
    using Microsoft.AspNetCore.Mvc;
    using CarDealer.Services;
    using Models.Suppliers;

    public class SupplierController : Controller
    {
        private readonly ISupplierService Suppliers;

        private const string SuppliersView = "Suppliers";

        public SupplierController(ISupplierService Suppliers)
        {
            this.Suppliers = Suppliers;
        }

        public IActionResult Local()
           => View(SuppliersView, this.GetSupplierModel(false));

        public IActionResult Importer()
        => View(SuppliersView, this.GetSupplierModel(true));


        public SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";

            var suppliers = this.Suppliers.All(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }

    }
}
