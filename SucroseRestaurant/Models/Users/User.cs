using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Admin.Models.Users
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        

    }
}
