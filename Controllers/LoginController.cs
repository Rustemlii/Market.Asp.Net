using Business.Abstract;
using DataAccess.MyContext;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILogin _login;
		private readonly AppDbContext _context;

		public LoginController(ILogin login, AppDbContext context)
		{
			_login = login;
			_context = context;
		}

		public IActionResult Index(string username,string password)
		{
			var values=_login.GetAll().Where(x=>x.Username == username && x.Password==password).ToList().FirstOrDefault();
			if (values!=null && values.RoleId==1)
			{				
				return RedirectToAction("Index","Admin");
			}
			else if(values!=null && values.RoleId==3)
			{
				return RedirectToAction("Index","Home");
			}
			return View();
		}
	}
}
