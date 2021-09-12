using Microsoft.AspNetCore.Mvc;
using Sportiga.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportiga.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class Articles : Controller
    {
        private ApplicationDbContext context;
        public Articles(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var articles = context.Articles.Where(d => d.categoryId == id && d.Status == "approved").Select(s => s).ToList();
            return View(articles);
        }
    }
}
