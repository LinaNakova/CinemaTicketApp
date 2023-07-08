using CinemaTicketApp.Domain.DTO;
using CinemaTicketApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CinemaTicketApp.Service.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdeteExistingProduct(Product p);
        AddToShoppingCartDTO GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDTO item, string userID);

        List<Product> filterProducts(DateTime date);
    }
}
