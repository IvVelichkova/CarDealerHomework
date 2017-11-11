using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models.Cars;

namespace CarDealer.Services.Models.Sales
{
    public class SaleDetailsModel : SaleListModel
    {
       public CarModel Car { get; set; }
    }
}
