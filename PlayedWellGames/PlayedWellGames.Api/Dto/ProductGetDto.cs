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
    }
}
