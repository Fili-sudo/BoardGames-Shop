using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Dto
{
    public class OrderGetDto
    {
        public int Id { get; set; }
        public States State { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public List<OrderItemGetDto> OrderItems { get; set; }
        public string ShippingAddress { get; set; }
    }
}
