
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;

namespace MemeRSity.Models
{
    public class UserApp : IdentityUser
    {
        [PersonalData] public int Year { get; set; }
        [PersonalData] public string Country { get; set; }
       
    }
}
