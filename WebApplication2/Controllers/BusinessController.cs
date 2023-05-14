using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BusinessController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ReservadoContext _reservadoContext;

        public BusinessController(ILogger<HomeController> logger, ReservadoContext reservadoContext)
        {
            _logger = logger;
            _reservadoContext = reservadoContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var business = _reservadoContext.Businesses.Include(x => x.Faqs).Include(x => x.Categories).Include(x => x.Photos).Where(x => x.id == id).FirstOrDefault();

            var totalpax = _reservadoContext.Reservations.Where(x => x.Business == business).Sum(x => x.Pax);

            ViewBag.isWaitlist = totalpax < business.Capacity;

          


            return View("Detail", business);
        }

        [HttpPost]
        public IActionResult Booking(Reservation reservation)
        {

            var getBusiness = _reservadoContext.Businesses.Where(x => x.id == Convert.ToInt32(Request.Form["bid"])).FirstOrDefault();
            var defaultUser = _reservadoContext.Users.FirstOrDefault();

            var totalpax = _reservadoContext.Reservations.Where(x => x.Business == getBusiness).Sum(x => x.Pax);

            if (totalpax < getBusiness.Capacity && totalpax + reservation.Pax < getBusiness.Capacity)
            {
                reservation.User = defaultUser;
                reservation.CreateDate = DateTime.Now;
                reservation.Business = getBusiness;

                _reservadoContext.Reservations.Add(reservation);
                _reservadoContext.SaveChanges();
            }
            else if (totalpax + reservation.Pax >= getBusiness.Capacity)
            {

                return Json(new { StatusCode = "400", data = "We don't have enough capacity please change guest count we just have " + (getBusiness.Capacity-totalpax) +" people" });
            }
            else
            {
                return Json(new { StatusCode = "400", data = "Bussines Full or don't have enough capacity" });
               // var error = "asd";
            }



            return Json(new { StatusCode = "200", data = "Confirmed" });

        }
    }
}
