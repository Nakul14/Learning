using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIForAngularApp.Models;

namespace WebAPIForAngularApp.Controllers
{
    public class HomeController : Controller
    {
        TUKBGFEntities db = new TUKBGFEntities();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public UmUserMaster GetUserByCredentials(string UserId,string Password)
        {
            if(UserId == null || Password == null)
            {
                return null;
            }

           UmUserMaster user = db.UmUserMasters.Where(R => R.UserId == UserId && R.UserPassword == Password).FirstOrDefault();

            if(user!= null)
            {
                user.UserPassword = string.Empty;
            }

            return user;
        }
    }
}
