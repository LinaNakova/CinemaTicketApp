using CinemaTicketApp.Domain.DTO;
using CinemaTicketApp.Domain.Model;
using CinemaTicketApp.Repository.Interface;
using CinemaTicketApp.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketApp.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCarts> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IRepository<Product> productRepository, ILogger<ProductService> logger, IUserRepository userRepository, IRepository<ProductInShoppingCarts> productInShoppingCartRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _logger = logger;


        }

        public bool AddToShoppingCart(AddToShoppingCartDTO item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserShoppingCart;

            if (item.ProductId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForProduct(item.ProductId);

                if (product != null)
                {
                    ProductInShoppingCarts itemToAdd = new ProductInShoppingCarts
                    {
                        Product = product,
                        ProductId = product.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };
                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Ticket was successfully added into ShoppingCart");
                    return true;
                }
                return false;

            }
            _logger.LogInformation("Something was wrong. ProductId or UserShoppingCard may be unavailable");
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            _logger.LogInformation("A new ticket was created");
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            _logger.LogInformation("DeleteProduct was called");
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> filterProducts(DateTime date)
        {
            return _productRepository.GetAll().Where(z => z.ValidTo.CompareTo(date) > 0).ToList();
        }

        public List<Product> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts was called");
            return this._productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            _logger.LogInformation("GetDetailForProduct was called");
            return this._productRepository.Get(id);

        }

        public AddToShoppingCartDTO GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            AddToShoppingCartDTO model = new AddToShoppingCartDTO
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingProduct(Product p)
        {
            _logger.LogInformation("A ticket was edited and updated");
            this._productRepository.Update(p);
        }
    }
}
