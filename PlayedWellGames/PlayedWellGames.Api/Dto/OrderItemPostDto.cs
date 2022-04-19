
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Dto
{
    public class OrderItemPostDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int? OrderId { get; set; }

    }
}
