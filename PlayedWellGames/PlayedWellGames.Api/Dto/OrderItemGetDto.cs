namespace PlayedWellGames.Api.Dto
{
    public class OrderItemGetDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto Product { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not OrderItemGetDto) return false;
            OrderItemGetDto other = (OrderItemGetDto)obj;

            return other.Id == Id && other.Quantity == Quantity && other.ProductId == ProductId
                && other.Product.Equals(Product);
                
        }
    }
}
