using Ruka_Market.Helpers;
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

            Session["orderView"] = orderView;

            ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            orderView = Session["orderView"] as OrderView;

            var CustomerID = int.Parse(Request["CustomerID"]);

            if (CustomerID == 0)
            {
                ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");
                ViewBag.Error = "Deve selecionar um cliente";

                return View(orderView);
            }

            var customer = db.Customers.Find(CustomerID);

            if (customer == null)
            {
                ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");
                ViewBag.Error = "O cliente não existe";

                return View(orderView);
            }

            if (orderView.Products.Count == 0)
            {
                ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");
                ViewBag.Error = "Deve escolher os produtos a encomendar";

                return View(orderView);
            }

            int orderID = 0;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        CustomerID = CustomerID,
                        DateOrder = DateTime.Now,
                        OrderStatus = OrderStatus.Created
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = order.OrderID;

                    foreach (var item in orderView.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            Description = item.Description,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            OrderID = orderID,
                            ProductID = item.ProductID
                        };

                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                    }

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = $"Erro: {ex.Message}";
                    ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

                    return View(orderView);
                }
            }


            ViewBag.Message = $"A encomenda: {orderID} foi efetuada com sucesso!";

            ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

            orderView = new OrderView();

            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();

            Session["orderView"] = orderView;

            return View(orderView);

        }

        public ActionResult AddProduct()
        {

            ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;

            var ProductID = int.Parse(Request["ProductID"]);

            //Caso não haja produto escolhido
            if (ProductID == 0)
            {
                ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");
                ViewBag.Error = "Deve selecionar um produto";

                return View(productOrder);
            }

            //Verifica se produto existe
            var Product = db.Products.Find(ProductID);
            if (Product == null)
            {
                ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");
                ViewBag.Error = "Produto não existe";

                return View(productOrder);
            }

            productOrder = orderView.Products.Find(p => p.ProductID == ProductID);

            if (productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Description = Product.Description,
                    Price = Product.Price,
                    ProductID = Product.ProductID,
                    Quantity = float.Parse(Request["Quantity"])
                };

                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }


            ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

            return View("NewOrder", orderView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}