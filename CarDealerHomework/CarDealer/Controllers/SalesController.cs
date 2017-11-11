namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Extensions;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [Route("")]
        public IActionResult All()
        => View(this.sales.All());

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.sales.Details(id));


        [Route("discounted")]
        public IActionResult Discounted()
            => this.ViewOrNotFound(this.sales.Discounted());

        [Route("discounted/{percent}")]
        public IActionResult DiscountedByPredent(double percent)
            => this.ViewOrNotFound(this.sales.Discounted(percent));
    }
}
