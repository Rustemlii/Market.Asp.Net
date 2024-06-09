using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogin _login;
        private readonly IRole _role;

		public RegisterController(ILogin login, IRole role)
		{
			_login = login;
			_role = role;
		}
		[HttpGet]
		public IActionResult Index()
		{
			
			return View();
		}

		[HttpPost]
		public IActionResult Index(LoginDTO dto)
        {
			dto.RoleId = 3;
            _login.Insert(dto);
            return RedirectToAction("Index");
        }
    }
}
