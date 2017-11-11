namespace CarDealer.Web.Models.Customers
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Services.Models.Cars;

    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public  OrderedDirection OrderedDirection { get; set; }
    }
}
