using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Market.Asp.Net.ViewComponents
{
    public class FooterList : ViewComponent
    {
        private readonly ICategory _category;

        public FooterList(ICategory category)
        {
            _category = category;
        }
        public IViewComponentResult Invoke()
        {
            var values = _category.GetAll();
            return View(values);
        }
    }
}
