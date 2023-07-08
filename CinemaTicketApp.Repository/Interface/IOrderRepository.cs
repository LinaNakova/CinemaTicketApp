using CinemaTicketApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CinemaTicketApp.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(Guid model);
    }
}
