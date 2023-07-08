using CinemaTicketApp.Domain.DTO;
using System;

namespace CinemaTicketApp.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string usedId, Guid id);
        bool orderNow(string userId);
    }
}
