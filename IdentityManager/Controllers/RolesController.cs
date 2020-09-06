using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using IdentityManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RolesController(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                //update
                var objFromDb = _db.Roles.FirstOrDefault(u => u.Id == id);
                return View(objFromDb);
            }
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole roleObj)
        {
            if(await _roleManager.RoleExistsAsync(roleObj.Name))
            {
                //error
            }
            if (string.IsNullOrEmpty(roleObj.Id))
            {
                //create
                await _roleManager.CreateAsync(new IdentityRole() { Name = roleObj.Name });
            }
            else
            {
                //update
                var objRoleFromDb = _db.Roles.FirstOrDefault(u => u.Id == roleObj.Id);
                objRoleFromDb.Name = roleObj.Name;
                objRoleFromDb.NormalizedName = roleObj.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(objRoleFromDb);

            }
            return RedirectToAction(nameof(Index));

        }

    }
}
