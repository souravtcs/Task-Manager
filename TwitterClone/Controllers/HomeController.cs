using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            UserBAL uBal = new UserBAL();
            UserModel loggedinUser = uBal.GetUser(new LoginModel { UserName = login.UserName, Password = login.Password });
            if(loggedinUser!=null && loggedinUser.isActive)
            {                
                Session["User"] = loggedinUser;
                return RedirectToAction("Index", "Tweet");
            }
            else
            {
                ViewBag.Message = "Username or Password is incorrect!!";
                return View();
            }
                
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            UserBAL uBal = new UserBAL();
            bool res = uBal.AddUser(new UserModel
            {
                UserName = user.UserName,
                Password = user.Password,
                DOB = user.DOB,
                Email = user.Email,
                FullName = user.FullName,
                JoinedOn = DateTime.Now,
                isActive = true
            });
            if (res)
                return RedirectToAction("Login", "Home");
            else
                return View();
        }
        public ActionResult SignOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Profile()
        {
            UserBAL uBal = new UserBAL();
            UserViewModel u = new UserViewModel();
            u = uBal.GetAllUser().Where(s => s.UserId == ((UserModel)Session["User"]).UserId).Select(s => new UserViewModel
            {
                UserId = s.UserId,
                UserName = s.UserName,
                Password = s.Password,
                FullName = s.FullName,
                DOB = s.DOB,
                Email = s.Email,
                isActive = s.isActive,
                JoinedOn = s.JoinedOn
            }).FirstOrDefault();
            return View(u);
        }
        [HttpPost]
        public ActionResult Profile(UserViewModel user)
        {
            UserBAL uBal = new UserBAL();
            UserModel u = new UserModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FullName = user.FullName,
                Password = user.Password,
                DOB = user.DOB,
                Email = user.Email
            };
            bool res = uBal.UpdateUser(u);
            return RedirectToAction("Index","Tweet");
        }
    }
}