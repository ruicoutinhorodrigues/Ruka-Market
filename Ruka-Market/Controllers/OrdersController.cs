using Ruka_Market.Models;
using Ruka_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruka_Market.Controllers
{
    public class OrdersController : Controller
    {
        private Ruka_MarketContext db = new Ruka_MarketContext();

        // GET: Orders
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();

            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();

            var list = db.Customers.ToList();
            ViewBag.CustomerID = new SelectList(list.OrderBy(c => c.Name).ToList(), "CustomerID", "Name");



            return View(orderView);
        }
    }
}