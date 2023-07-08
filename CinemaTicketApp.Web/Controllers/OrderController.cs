using CinemaTicketApp.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using GemBox.Document;
using CinemaTicketApp.Service.Interface;

namespace CinemaTicketApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            List<Order> orders = this._orderService.getAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid orderId)
        {
            Order order = this._orderService.getOrderDetails(orderId);
            return View(order);
        }
        public FileContentResult CreateInvoice(Guid orderId)
        {
            Order order = this._orderService.getOrderDetails(orderId);

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", order.Id.ToString());
            document.Content.Replace("{{User}}", order.User.UserName);

            StringBuilder sb = new StringBuilder();

            var totalPrice = 0.0;

            foreach (var item in order.ProductsInOrders)
            {
                totalPrice += item.Quantity * item.OrderedProduct.ProductPrice;
                sb.AppendLine(item.OrderedProduct.ProductName + " with quantity of: " + item.Quantity + " and price of: " + item.OrderedProduct.ProductPrice);
            }
            document.Content.Replace("{{ProductList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", totalPrice.ToString());

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());

            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
    }
}
