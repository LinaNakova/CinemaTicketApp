using CinemaTicketApp.Domain.Identity;
using System.Collections.Generic;

namespace CinemaTicketApp.Domain.Model
{
    public class ShowOrder
    {
        public string UserId { get; set; }
        public EShopApplicationUser User { get; set; }
        public ICollection<ProductInOrder> ProductsInOrder { get; set; }
    }
}
