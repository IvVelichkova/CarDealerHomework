using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models.Cars;

namespace CarDealer.Services.Models.Sales
{
    public class SalesDiscountedListModel 
    {
        public decimal Price { get; set; }

        public double Discount { get; set; }

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public CarModel Car { get; set; }

    }
}
