using CinemaTicketApp.Domain.Model;
using System;
using System.Collections.Generic;

namespace CinemaTicketApp.Service.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();
        Order getOrderDetails(Guid model);
    }
}
