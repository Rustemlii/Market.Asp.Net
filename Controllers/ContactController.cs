using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
	public class ContactController : Controller
	{
		private readonly IMessage _message;

		public ContactController(IMessage message)
		{
			_message = message;
		}

		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Index(MessageDTO dto)
		{
			_message.Insert(dto);


			return View();
		}
	}
}
