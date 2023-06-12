using Microsoft.AspNetCore.Mvc;

using TestingMVC.Data;
using TestingMVC.Models;

namespace TestingMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        //[HandleError]
        public IActionResult Index()
        {
            var result = _context.Categories.ToList();
            return View(result);
        }

        //get the data from user to add new category
        public IActionResult Create()
        {
            return View();
        }

        //this will be executed when the form on create view is submitted
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            //server side validation
            if (obj.name == obj.display_order.ToString()) 
            {
                //server side custom error
                ModelState.AddModelError("name", "The name and display order can not be same!");
            }
            //server side validation but bcoz of script ,it will be a client side validation
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public IActionResult Edit(int id)
        {

            if(id == 0 || id == null)
            {
                return NotFound();
            }
            var mycategory = _context.Categories.FirstOrDefault(a => a.Id == id);
            if(mycategory == null)
            {
                return NotFound();
            }
            return View(mycategory);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            //server side validation
            if (obj.name == obj.display_order.ToString())
            {
                //server side custom error
                ModelState.AddModelError("name", "The name and display order can not be same!");
            }
            //server side validation but bcoz of script ,it will be a client side validation
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["Success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var mycategory = _context.Categories.FirstOrDefault(a => a.Id == id);
            if (mycategory == null)
            {
                return NotFound();
            }
            return View(mycategory);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var mycategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if(mycategory == null)
            {
                return NotFound();
            }
                _context.Categories.Remove(mycategory);
                _context.SaveChanges();
            TempData["Success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
           
            

        }
    }
}
