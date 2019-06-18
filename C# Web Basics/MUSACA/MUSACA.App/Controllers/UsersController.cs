using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MUSACA.App.ViewModels;
using MUSACA.Models;
using MUSACA.Services;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        //TODO: Check if works
        [Authorize]
        public ActionResult Index()
        {
            var orders = userService.GetUserReceipt(User.Username)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
					Product = o.Product.Name,
                    Quantity = o.Quantity,
                    Price = o.Product.Price
                })
                .ToList(); ;

            var loggedInUser = new LoggedInUserViewModel
            {
                OrderViewModels = orders
            };

            return this.View(loggedInUser, "/../Home/LoggedInUser");
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User userFromDb = this.userService.GetUserByUsernameAndPassword(username, this.HashPassword(password));

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword, string email)
        {
            if (password != confirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email
            };

            this.userService.CreateUser(user);

            return this.Redirect("/Users/Login");
        }


        //TODO: Create it!!!
        //[Authorize]
        //public ActionResult Profile()
        //{
        //    var receipts = this.userService.GetUserReceipt(User.Username);

        //    var profile = new UserProfileViewModel
        //    {
        //        Receipts = receipts
        //    };

        //    return View("/Users/Profile", profile);
        //}

        [Authorize]
        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
