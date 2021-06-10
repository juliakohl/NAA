using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NAA.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NAA.Controllers
{
    public class AdminController : Controller
    {
        //TODO: Views erstellen!

        private ApplicationDbContext context;
        //really neccesery?
        private NAA.Models.ApplicationDbContext _context;

        public AdminController()
        {
            //is _context neccesery?
            _context = new NAA.Models.ApplicationDbContext();
            context = new ApplicationDbContext();
        }
        
        //GetUsers
        //TODO:view is working, user not displayed
        public ActionResult GetUsers()
        {
            return View(context.Users.ToList());
        }

        //GetRoles

        //GET GetRoles
        public ActionResult GetRoles()
        {
            return View(context.Roles.ToList());
        }

        //AddRole

        //GET AddRole
        public ActionResult AddRole()
        {
            ViewBag.roleList = GetRoles();
            return View(); 
        }

        //Post AddRole
        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            IdentityRole role = new IdentityRole(collection["RoleName"]);
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("GetRoles");
        }

        //GetRolesForUser
        
        //GET GetRolesForUser
        //TODO:Works, look at dropdown//no user, see below
        [HttpGet]
        public ActionResult GetRolesForUser()
        {
            //Prepare User Dropdown
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(
                uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text = uu.UserName
                }).ToList();

            //Place in ViewBag
            ViewBag.Users = userList;
            return View();
        }

        //POST GetRolesForUser
        //TODO: Look at dropdown, maybe because user doenst get recognized
        [HttpPost]
        public ActionResult GetRolesForUser(string username)
        {
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(
                uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();

            //Place in ViewBag
            ViewBag.Users = userList;
            return View();
        }

        //ManageUserRoles

        //GET ManageUserRoles
        public ActionResult ManageUserRoles()
        {
            //Prepare Dropdown for Users
            //userList
            var userList = context.Users.OrderBy(
                u => u.UserName).ToList().Select(
                uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text = uu.UserName
                }).ToList();
            ViewBag.Users = userList; //Place in ViewBag

            //Prepare Dropdown for Roles
            var roleList = context.Roles.OrderBy(
                r => r.Name).ToList().Select(
                rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();

            //Place in ViewBag
            ViewBag.Roles = roleList;

            return View();
        }

        //POST ManageUserRoles
        [HttpPost]
        public ActionResult ManageUserRoles(string userName, string roleName)
        {
            ApplicationUser user = context.Users.Where(
                u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
            var idResult = um.AddToRole(user.Id, roleName);

            //Go Back to where you were

            //Populate roles for the view Dropdown
            //roleList
            var roleList = context.Roles.OrderBy
                (r => r.Name).ToList().Select
                (rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            //prepopulate users for the view Dropdown
            //userList
            var userList = context.Users.OrderBy
                (u => u.UserName).ToList().Select
                (uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Roles = userList;
            return View("ManageUserRoles");
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}