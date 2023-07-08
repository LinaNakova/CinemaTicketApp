using CinemaTicketApp.Domain.Model;
using System.Collections.Generic;

namespace CinemaTicketApp.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<ProductInShoppingCarts> ProductsInShoppingCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
