using BengalBooksWeb.Data;
using BengalBooks.Models;
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

        //GET
        public IActionResult Create()
        {
           
            return View();
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","The DisplayOrder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dataFromDb = _db.Categories.Find(id);
            //var dataFromDbFirstOrDefault = _db.Categories.FirstOrDefault(m => m.Id == id);
            //var dataFromDbSingleOrDefault = _db.Categories.SingleOrDefault(m => m.Id == id);

            if (dataFromDb == null)
            {
                return NotFound();
            }

            return View(dataFromDb);
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dataFromDb = _db.Categories.Find(id);

            if (dataFromDb == null)
            {
                return NotFound();
            }

            return View(dataFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
                return NotFound();
            _db.Categories.Remove(obj);
            TempData["success"] = "Category Deleted Successfully.";
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
