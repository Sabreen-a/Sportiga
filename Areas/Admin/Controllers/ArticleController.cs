using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sportiga.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportiga.Areas.Admin.Controllers
{
    //[Authorize]

    [Area("Admin")]

    public class ArticleController : Controller
    {

        private ApplicationDbContext context;
        public ArticleController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Articles(int id)
        {

            //var articles = context.Articles.Where(d => d.categoryId == id ).Select(s => s);
            var articles = context.Articles.Where(d => d.categoryId == id && d.Status == "approved").Select(s => s);
            return View(articles);
        }
        [HttpGet]
        public IActionResult Write()
        {
            ViewBag.categories = context.Categories;
            return View();
        }
    }
}
