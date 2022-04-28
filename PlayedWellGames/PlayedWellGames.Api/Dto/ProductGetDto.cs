namespace PlayedWellGames.Api.Dto
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not ProductGetDto) return false;
            ProductGetDto other = (ProductGetDto)obj;

            return other.Id == Id && other.ProductName == ProductName && other.Description == Description 
                && other.Price == Price && other.Quantity == Quantity && other.Tags == Tags;
        }
    }
}
