using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ruka_Market.Models;
using Ruka_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruka_Market.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<UserView>();

            foreach (var user in users)
            {
                var userView = new UserView
                {
                    Email = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };

                usersView.Add(userView);
            }

            return View(usersView);
        }

        //Get: Roles
        public ActionResult Roles(string userID)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var roles = roleManager.Roles.ToList();
            var users = userManager.Users.ToList();

            var user = users.Find(u => u.Id == userID);

            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Role = rolesView
            };

            return View(userView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}