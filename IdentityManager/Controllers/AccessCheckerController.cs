using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Controllers
{
    [Authorize]
    public class AccessCheckerController : Controller
    {
        [AllowAnonymous]
        //Accessible by everyone, even if users are not logged in.
        public IActionResult AllAccess()
        {
            return View();
        }

        [Authorize]
        //Accessible by logged in users.
        public IActionResult AuthorizedAccess()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        //Accessible by users who have user role
        public IActionResult UserAccess()
        {
            return View();
        }

        [Authorize(Roles = "User,Admin")]
        //Accessible by users who have user role
        public IActionResult UserORAdminAccess()
        {
            return View();
        }

        [Authorize(Policy = "UserAndAdmin")]
        //Accessible by users who have user role
        public IActionResult UserANDAdminAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        //Accessible by users who have admin role
        public IActionResult AdminAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin_CreateAccess")]
        //Accessible by Admin users with a claim of create to be True
        public IActionResult Admin_CreateAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin_Create_Edit_DeleteAccess")]
        //Accessible by Admin user with claim of Create Edit and Delete (AND NOT OR)
        public IActionResult Admin_Create_Edit_DeleteAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin_Create_Edit_DeleteAccess_OR_SuperAdmin")]
        //accessible by Admin user with create, edit and delete (AND NOT OR), OR if the user role is superAdmin
        public IActionResult Admin_Create_Edit_DeleteAccess_OR_SuperAdmin()
        {
            return View();
        }

        [Authorize(Policy = "AdminWithMoreThan1000Days")]
        public IActionResult OnlyBhrugen()
        {
            return View();
        }

        [Authorize(Policy = "FirstNameAuth")]
        public IActionResult FirstNameAuth()
        {
            return View();
        }
    }
}
