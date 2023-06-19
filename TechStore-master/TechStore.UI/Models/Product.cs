namespace TechStore.UI.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int productId, string make, string model, string characteristics, string description, string price)
        {
            ProductId = productId;
            Make = make;
            Model = model;
            Characteristics = characteristics;
            Description = description;
            Price = price;
        }

        public int ProductId { get; set; }
        //public string ImageUrl { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Characteristics { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
    }


}
