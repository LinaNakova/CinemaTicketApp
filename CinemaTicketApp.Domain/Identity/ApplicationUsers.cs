using CinemaTicketApp.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaTicketApp.Domain.Identity
{
    public class CinemaApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
