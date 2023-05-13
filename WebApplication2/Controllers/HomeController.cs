using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication2.Context;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReservadoContext _reservadoContext;

        public HomeController(ILogger<HomeController> logger, ReservadoContext reservadoContext)
        {
            _logger = logger;
            _reservadoContext = reservadoContext;

        }

        public IActionResult Index()
        {


            var bussineses = _reservadoContext.Businesses.Include(x=>x.Photos).ToList();
            return View( bussineses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Login()
        {
            return View();

        }


        public IActionResult autocomplete(string name)
        {
            var response = _reservadoContext.Businesses.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

            return Json(response);


        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            var userCheck = _reservadoContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (userCheck != null)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userCheck.id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, userCheck.Name));
                userClaims.Add(new Claim(ClaimTypes.Email, userCheck.Email));
                userClaims.Add(new Claim(ClaimTypes.Surname, userCheck.Surname.ToString()));

                foreach (var item in userCheck.Roles.Split(","))
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, item));
                }
                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                return RedirectToAction("Index", "User");

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            }
            return View();
        }

    }



}
