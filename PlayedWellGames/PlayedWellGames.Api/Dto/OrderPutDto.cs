using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Dto
{
    public class OrderPutDto
    {
        public double Price { get; set; }
        public string ShippingAddress { get; set; }
        public States State { get; set; }
    }
}
