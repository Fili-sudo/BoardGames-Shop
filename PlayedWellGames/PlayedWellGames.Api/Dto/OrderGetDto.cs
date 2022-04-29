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

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not OrderGetDto) return false;
            OrderGetDto other = (OrderGetDto)obj;

            bool result = true;

            var array = OrderItems.ToArray();
            var otherArray = other.OrderItems.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                result = result && otherArray[i].Equals(array[i]);
                if (result == false) break;
            }

            return other.Id == Id && other.State == State && other.Price == Price && other.UserId == UserId
                && other.ShippingAddress == ShippingAddress && result;

        }
    }
}
