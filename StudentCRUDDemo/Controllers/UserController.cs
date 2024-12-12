using StudentCRUDDemo.BLL.Services;
using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentCRUDDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private string HashPassword(string password)
        {
            using (var sha256  = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        // GET: User
        public ActionResult CreateUser()
        {
            ViewBag.GenderList = new SelectList(new List<string> { "Male", "Female" });
            ViewBag.RoleList = new SelectList(_userService.GetRoles(), "Id", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                 user.CreatedDt = DateTime.Now;
                 

                if (user.Password != user.Confirm_Password)
                {
                    ModelState.AddModelError("Confirm_Password", "Password and Confirm Password do not match.");
                     
                }
                else
                {
                    user.Confirm_Password = HashPassword(user.Confirm_Password);
                    user.Password = HashPassword(user.Password);
                    _userService.AddUser(user);
                }
                
                return RedirectToAction("Login");
            }
            ViewBag.GenderList = new SelectList(new List<string> { "Male", "Female" });
            ViewBag.RoleList = new SelectList(_userService.GetRoles(), "Id", "RoleName");
            return View(user);
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User login)
        {
            var hashedPassword = HashPassword(login.Password);
            var user = _userService.ValidUser(login.Email, hashedPassword);
                if (user!=null){
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["Role"] = user.RoleId;
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                if(login.Email!=null && login.Password != null)
                {
                    ModelState.AddModelError("", "Invalid User Name or Password ");
                }
                }


                return View(login);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            Session["Role"] = null;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return RedirectToAction("Login");
        }

    }
}