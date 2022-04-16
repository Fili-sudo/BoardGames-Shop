using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Dto
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
