using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IMessage _message;

		public ReviewController(IMessage message)
		{
			_message = message;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var values = _message.GetAll();
			return View(values);
		}
	}
}
