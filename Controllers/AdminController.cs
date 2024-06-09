using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.Controllers
{
	public class AdminController : Controller
	{
		private readonly ICategory _category;
		private readonly IProduct _product;
		private readonly ILogin _login;
		private readonly IRole _role;
		private readonly IMessage _message;
        public AdminController(ICategory category, IProduct product, ILogin login, IRole role,IMessage message)
        {
            _category = category;
            _product = product;
            _login = login;
            _role = role;
			_message = message;
        }






        #region Categories

        public IActionResult Index()
		{
			var values = _category.GetAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult CategoryAdd()
		{
			
			return View();
		}
		[HttpPost]
		public IActionResult CategoryAdd(CategoryDTO category)
		{
			_category.Insert(category);
			return RedirectToAction("Index");
		}
		public IActionResult CategoryDelete(int id)
		{
			_category.Delete(id);
			return RedirectToAction("Index");
		}
        #endregion

        #region Products

		public IActionResult Product()
		{
			var values=_product.GetAllCategory();
			return View(values);
		}
        public IActionResult ProductDelete(int id)
        {
            _product.Delete(id);
            return RedirectToAction("Product");
        }
        [HttpGet]
		public IActionResult ProductAdd(int id)
		{
			ViewBag.ctg = _category.GetAll();
            return View();
		}
		[HttpPost]
		public IActionResult ProductAdd(ProductDTO product)
		{
			
			_product.Insert(product);
			return RedirectToAction("Product");
		}

		[HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            ViewBag.ctg = _category.GetAll();
            var values=_product.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult ProductUpdate(ProductDTO product)
        {
        
            _product.Update(product);
            return RedirectToAction("Product");
        }



		#endregion

		#region AdminLogin

		public IActionResult Users()
		{
			var values=_login.GetAllRole();
			return View(values);
		}

        public IActionResult UsersDelete(int id)
        {
           _login.Delete(id);
            return RedirectToAction("Users");
        }
		[HttpGet]
		public IActionResult UsersUpdate(int id)
		{
			ViewBag.status = _role.GetAll();
			var values=_login.GetByID(id);
			return View(values);
		}
		[HttpPost]
        public IActionResult UsersUpdate(LoginDTO dto)
        {
            _login.Update(dto);
            return RedirectToAction("Users");
        }



        [HttpGet]
        public IActionResult AdminRegister()
        {
			ViewBag.user = _role.GetAll();
            return View();
        }

		[HttpPost]
        public IActionResult AdminRegister(LoginDTO dto)
        {
			_login.Insert(dto);
            return RedirectToAction("Users");
        }


        #endregion

        #region Admin Review
		public IActionResult AdminReview()
		{
			var values=_message.GetAll();
			return View(values);
		}
		public IActionResult AdminReviewDelete(int id)
		{
			_message.Delete(id);
			return RedirectToAction("AdminReview");
		}
		[HttpGet]
		public IActionResult AdminReviewUpdate(int id)
		{
			var values=_message.GetByID(id);
			return View(values);
		}
		public IActionResult AdminReviewUpdate(MessageDTO dto)
		{
			_message.Update(dto);
			return RedirectToAction("AdminReview");
		}

		#endregion
	}
}
