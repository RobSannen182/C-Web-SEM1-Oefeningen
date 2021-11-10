using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.ViewModels
{
    public class CreatedUser
    {
        public DateTime CreationDate { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
