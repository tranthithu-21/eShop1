namespace eShop.CoreBusiness.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Id
        {
            get => ProductId;
            set => ProductId = value;
        }

        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string ImageLink { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}