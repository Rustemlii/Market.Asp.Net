using Business.Abstract;
using DataAccess.MyContext;
using Market.Asp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Market.Asp.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _product;
        private readonly ICategory _category;
        private readonly AppDbContext _context;

        public HomeController(IProduct product, ICategory category, AppDbContext context)
        {
            _product = product;
            _category = category;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.c = _product.GetAll().Where(x => x.CategoryID == 2);
            var values = _product.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult Page(int id)
        {
            var values = _product.GetAllCategory(id);          
            return View(values);
        }
    
        public IActionResult Search(string search)
        {
            var values=from x in _product.GetAllCategory() select x;
            if (!string.IsNullOrEmpty(search))
            {
                values=values.Where(x=>x.Name.ToLower().Contains(search.ToLower()));
            }
            return View(values);
        }
    }
}
