using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Data.Models;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Customers
{
    public class CustomerByIdModel
    {
        // name, bought cars count and total spent money on cars. 
        public string Name { get; set; }

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}
