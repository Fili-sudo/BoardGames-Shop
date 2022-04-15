namespace PlayedWellGames.Api.Dto
{
    public class ProductPutPostDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }
    }
}
