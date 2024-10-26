using Bulky.Models;
using BulkyWeb.DataAcess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
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
            //for retriving data from category table 
           List<Category> objCategorylist = _db.Categories.ToList();
            return View(objCategorylist); 
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //making custon validation, name and display order can't be same
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                //this is custom validation
                //here name is the key of the  where this error message should be shown
                ModelState.AddModelError("name", "The DisplayOrder cannot match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }   
            return View();
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            { 
                return NotFound();
            }
            Category? categoryFromDb1 = _db.Categories.Find(id);//find will work onn primary key of that model
           // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
           // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Name == "scifi"); it works on all varaible 
          //  Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryFromDb1 == null)
            {
                return NotFound();
            }
            return View(categoryFromDb1);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {  

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
              Category? obj = _db.Categories.Find(id);//find will work onn primary key of that model
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);//find will work onn primary key of that model
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index", "Category");

        }
    }
}
