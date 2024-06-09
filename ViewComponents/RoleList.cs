using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.ViewComponents
{
	public class RoleList:ViewComponent
	{
		private readonly IRole _role;

		public RoleList(IRole role)
		{
			_role = role;
		}

		public IViewComponentResult Invoke()
		{
			var values = _role.GetAll();
			return View(values);
		}
	}
}
