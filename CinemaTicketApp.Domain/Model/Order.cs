using CinemaTicketApp.Domain.Identity;
using System.Collections.Generic;

namespace CinemaTicketApp.Domain.Model
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public CinemaApplicationUser User { get; set; }

        public virtual ICollection<ProductInOrder> ProductsInOrders { get; set; }
    }
}
