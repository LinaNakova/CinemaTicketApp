﻿using System;

namespace CinemaTicketApp.Domain.Model
{
    public class ProductInShoppingCarts : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
