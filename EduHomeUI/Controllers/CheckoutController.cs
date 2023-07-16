using EduHome.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace EduHomeUI.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            List<ProductEntity> productList = new List<ProductEntity>();
            productList = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Product= "CSE",
                    Price = 5000,
                    Quantity = 1,
                    ImagePath = "assets/img/course/course1.jpg"
                },
                  new ProductEntity
                {
                    Product= "HTMLCSS",
                    Price = 4650,
                    Quantity = 1,
                    ImagePath = "assets/img/course/course2.jpg"
                },
            };
            return View(productList);
        }
        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());
            if (session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                return View("Success");
            }
            return View("Login");
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Checkout()
        {
            List<ProductEntity> productList = new List<ProductEntity>();
            productList = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Product= "CSE",
                    Price = 5000,
                    Quantity = 1,
                    ImagePath = "assets/img/course/course1.jpg"
                },
                  new ProductEntity
                {
                    Product= "HTMLCSS",
                    Price = 4650,
                    Quantity = 1,
                    ImagePath = "assets/img/course/course2.jpg"
                },
            };
            var domain = "https://localhost:7224/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain +  $"Checkout/OrderConfirmation",
                CancelUrl = domain + "Checkout/Login",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment"
            };
            foreach (var item in productList)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * item.Quantity),
                        Currency = "usd",
                        ProductData= new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.ToString(),
                        }
                    },
                    Quantity = item.Quantity
                };
                options.LineItems.Add(sessionListItem); 
            }
            var service = new SessionService();
            Session session = service.Create(options);
            TempData["Session"] = session.Id;
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);   
        }
    }
}
