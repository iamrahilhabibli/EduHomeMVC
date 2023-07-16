using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace EduHomeUI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICourseService _courseService;
        public CheckoutController(AppDbContext context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index(Guid courseId)
        {
            List<ProductEntity> productList = new List<ProductEntity>();

            ProductEntity selectedCourse = await GetCourseById(courseId);
            productList.Add(selectedCourse);

            return View(productList);
        }

        private async Task<ProductEntity> GetCourseById(Guid courseId)
        {
            Course selectedCourse = await _courseService.GetCourseByIdCourse(courseId);

            CourseDetails courseDetails = await _context.CourseDetails
                .FirstOrDefaultAsync(cd => cd.CourseId == courseId);

            ProductEntity product = new ProductEntity
            {
                Product = selectedCourse.Name,
                Price = courseDetails.CourseFee,
                Quantity = 1,
                ImagePath = selectedCourse.ImagePath
            };

            return product;
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
