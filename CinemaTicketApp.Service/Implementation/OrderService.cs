using CinemaTicketApp.Domain.Model;
using CinemaTicketApp.Repository.Interface;
using CinemaTicketApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace CinemaTicketApp.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(Guid model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
