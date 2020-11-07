using System.Collections.Generic;
using ui.Identity;
using Microsoft.AspNetCore.Identity;

namespace ui.Models
{
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }

        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }

    }
}