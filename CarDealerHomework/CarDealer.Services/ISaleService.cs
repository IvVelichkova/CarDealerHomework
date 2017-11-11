namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models.Sales;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailsModel Details(int id);

        IEnumerable<SalesDiscountedListModel> Discounted();

        IEnumerable<SalesDiscountedListModel> Discounted(double percent);

    }
}
