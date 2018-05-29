using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        private static UserData userdata;

        static UserController()
        {
            userdata = userdata.GetInstance();
        }

        public IActionResult Index(User user)
        {
            if (user == null) user = new User
            {
                Username = "",
                Password = "",
                Email = "",
                FavColor = ""
            };
            //List<User> users = UserData.GetAll();
            return View(user);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Add(User user, string verify)
        {
            if (user.Password == verify && !String.IsNullOrEmpty(user.Username))
            {
                // return RedirectToAction("Index", user);
                return RedirectToAction("Index", new { Username = user.Username });
            }
            else
            {
                ViewBag.PasswordError = user.Password != verify ? "Your passwords must match" : "";
                ViewBag.UsernameError = String.IsNullOrEmpty(user.Username) ? "You must enter a username" : "";
                return View(user);
            }
        }

        public IActionResult Details(int userId)
        {
            User u = UserData.GetById(userId);

            return View(u);
        }
    }
}