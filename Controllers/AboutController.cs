using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
