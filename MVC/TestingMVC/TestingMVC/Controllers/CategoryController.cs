﻿using Microsoft.AspNetCore.Mvc;
using TestingMVC.Data;

namespace TestingMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Categories.ToList();
            return View(result);
        }
    }
}
