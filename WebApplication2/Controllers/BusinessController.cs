using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;

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
			var business = _reservadoContext.Businesses.Include(x => x.Faqs).Include(x => x.Categories).Include(x => x.Photos).Where(x=>x.id == id).FirstOrDefault();
			return View(business);
		}
	}
}
