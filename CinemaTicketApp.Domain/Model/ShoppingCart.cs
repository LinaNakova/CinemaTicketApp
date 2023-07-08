using CinemaTicketApp.Domain.Identity;
using System.Collections.Generic;


namespace CinemaTicketApp.Domain.Model
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual CinemaApplicationUser Owner { get; set; }
        public virtual ICollection<ProductInShoppingCarts> ProductsInShoppingCarts { get; set; }
        public ShoppingCart() { }
    }
}
