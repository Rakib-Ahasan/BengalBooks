using BengalBooks.DataAccess.Repository.IRepository;
using BengalBooksWeb.Data;
using BengalBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BengalBooksWeb.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> data = _unitOfWork.Category.GetAll();
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
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var dataFromDb = _db..Find(id);
            var dataFromDbFirstOrDefault = _unitOfWork.Category.GetFirstOrDefault(m => m.Id == id);
            //var dataFromDbSingleOrDefault = _db.Categories.SingleOrDefault(m => m.Id == id);

            if (dataFromDbFirstOrDefault == null)
            {
                return NotFound();
            }

            return View(dataFromDbFirstOrDefault);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            var dataFromDb = _unitOfWork.Category.GetFirstOrDefault(m => m.Id == id);

            if (dataFromDb == null)
            {
                return NotFound();
            }

            return View(dataFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(m => m.Id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Category.Remove(obj);
            TempData["success"] = "Category Deleted Successfully.";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
