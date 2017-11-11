using System.Collections.Generic;

namespace CarDealer.Data.Models
{
    public class Part
    {
        //Parts have name, price and quantity
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Supplier Supplaier { get; set; }

        public int SupplaierId { get; set; }

        public List<PartCar> Cars { get; set; } = new List<PartCar>();
    }
}
