using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.Controllers
{
    public class AccessCheckerController : Controller
    {
        //Accessible by everyone, even if users are not logged in.
        public IActionResult AllAccess()
        {
            return View();
        }

        //Accessible by logged in users.
        public IActionResult AuthorizedAccess()
        {
            return View();
        }

        //Accessible by users who have user role
        public IActionResult UserAccess()
        {
            return View();
        }

        //Accessible by users who have admin role
        public IActionResult AdminAccess()
        {
            return View();
        }

        //Accessible by Admin users with a claim of create to be True
        public IActionResult Admin_CreateAccess()
        {
            return View();
        }

        //Accessible by Admin user with claim of Create Edit and Delete (AND NOT OR)
        public IActionResult Admin_Create_Edit_DeleteAccess()
        {
            return View();
        }

        //accessible by Admin user with create, edit and delete (AND NOT OR), OR if the user role is superAdmin
        public IActionResult Admin_Create_Edit_DeleteAccess_SuperAdmin()
        {
            return View();
        }
    }
}
