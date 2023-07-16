using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Security.Claims;

namespace EduHomeUI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutController(AppDbContext context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index(Guid courseId)
        {
            ProductEntity selectedCourse = await GetCourseById(courseId);
            TempData["CourseId"] = courseId;

            return View(selectedCourse);
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
        //public IActionResult OrderConfirmation()
        //{
        //    var service = new SessionService();
        //    Session session = service.Get(TempData["Session"].ToString());
        //    if (session.PaymentStatus == "paid")
        //    {
        //        var transaction = session.PaymentIntentId.ToString();
        //        return View("Success");
        //    }
        //    return View("Login");
        //}
        public async Task<IActionResult> OrderConfirmation()
        {
            if (User.Identity.IsAuthenticated)
            {
                var service = new SessionService();
                Session session = service.Get(TempData["Session"].ToString());

                if (session.PaymentStatus == "paid")
                {
                    var transaction = session.PaymentIntentId.ToString();
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                    Guid courseId = (Guid)TempData["CourseId"];

                    ConfirmedStudents confirmedStudents = new ConfirmedStudents
                    {
                        UserId = Guid.Parse(userId),
                        CourseId = courseId
                    };

                    await _context.ConfirmedStudents.AddAsync(confirmedStudents);
                    await _context.SaveChangesAsync();

                    return View("Success");
                }
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
        public IActionResult Checkout(ProductEntity product)
        {
            var domain = "https://localhost:7224/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "Checkout/OrderConfirmation",
                CancelUrl = domain + "Checkout/Login",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment"
            };

            var sessionListItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(product.Price * product.Quantity),
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Product,
                    }
                },
                Quantity = product.Quantity
            };

            options.LineItems.Add(sessionListItem);

            var service = new SessionService();
            Session session = service.Create(options);
            TempData["Session"] = session.Id;
            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }

    }
}
