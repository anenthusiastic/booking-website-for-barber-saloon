using ui.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ui.Models
{
    public class CustomerList
    {
        public List<User> Customers { get; set; }
    }
}