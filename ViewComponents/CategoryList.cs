using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private readonly ICategory _category;
        private readonly ILogin _login;

		public CategoryList(ICategory category, ILogin login)
		{
			_category = category;
			_login = login;
		}

		public IViewComponentResult Invoke()
        {
          // ViewBag.c = _login.GetAll().Where(x=>x.RoleId==1).ToList().First();
            var values = _category.GetAll();
            return View(values);
        }
    }
}
