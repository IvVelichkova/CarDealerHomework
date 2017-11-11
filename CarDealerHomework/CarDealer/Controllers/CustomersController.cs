namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    using CarDealer.Services.Models;
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }
        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "descending"
                ? OrderedDirection.Descending
                : OrderedDirection.Ascending;

            var customers = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderedDirection = orderDirection
            });
        }
        [Route("{id}")]
        public IActionResult TotalSeals(int id)
        {
            var customer = this.customers.AllCarsByCustommer(id);

            return View(customer);
        }
    }
}
