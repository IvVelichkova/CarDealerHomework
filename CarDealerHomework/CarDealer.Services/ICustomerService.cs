namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models.Customers;
    using Models;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderedDirection order);

        CustomerIdInfoModel AllCarsByCustommer(int id);


    }
}
