using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2.Presentation.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
