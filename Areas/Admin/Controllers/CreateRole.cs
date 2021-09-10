using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportiga.Models;
using Sportiga.ViewModelComponant;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreateRole : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _UserManagerr;
       

        public CreateRole(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> UserManagerr)
        {
            _roleManager =roleManager;
            _UserManagerr =UserManagerr;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
       
        public async Task <IActionResult> Create(ProjectRole role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExists)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }

        [HttpGet]

        public IActionResult AssignRoleToUser()
        {
            ViewBag.Users = _UserManagerr.Users.ToList();

            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        public async Task<IActionResult> SaveRole(UserRoleModel userModel)
        {
            ApplicationUser user = await _UserManagerr.FindByNameAsync(userModel.UserId);
           var  role = await _roleManager.FindByNameAsync(userModel.RoleId);
          
          await  _UserManagerr.AddToRoleAsync(user,role.ToString());

            return RedirectToAction("Index", "Home");
        }

    }
}
