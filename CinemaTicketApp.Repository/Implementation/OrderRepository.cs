using CinemaTicketApp.Domain.Model;
using CinemaTicketApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CinemaTicketApp.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.ProductsInOrders)
                .Include("ProductsInOrders.OrderedProduct")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(Guid model)
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.ProductsInOrders)
                .Include("ProductsInOrders.OrderedProduct")
                .SingleOrDefaultAsync(z => z.Id == model).Result;
        }
    }
}
