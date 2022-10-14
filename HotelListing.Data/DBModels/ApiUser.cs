using Microsoft.AspNetCore.Identity;

namespace HotelListingEntities.DBModels
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
