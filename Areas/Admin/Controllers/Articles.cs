using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportiga.Models;
using Sportiga.ViewModelComponant;
using Sportiga.Data;
using Microsoft.AspNetCore.Authorization;
namespace Sportiga.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class Articles : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManagerr;
        private readonly ApplicationDbContext _Context;

        public Articles(UserManager<ApplicationUser> UserManagerr, ApplicationDbContext Context, UserManager<ApplicationUser> userManagerr)
        {
            _Context = Context;
            _UserManagerr = userManagerr;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.articles = _Context.Articles.Where(d => d.categoryId == id && d.Status == "approved").Select(s => s).ToList();
            ViewBag.Users = _UserManagerr.Users.ToList();
            return View();
        }
    }
}
