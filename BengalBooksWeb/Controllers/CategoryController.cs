using BengalBooksWeb.Data;
using BengalBooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BengalBooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> data = _db.Categories;
            return View(data);
        }
    }
}
