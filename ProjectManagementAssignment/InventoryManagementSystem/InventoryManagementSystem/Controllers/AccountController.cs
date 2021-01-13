using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InventoryManagementSystem.Controllers
{
    
    public class AccountController : Controller
    {
        static new string User = null;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Verify(Login acc)
        {
            LoginEntities db = new LoginEntities();
            if (acc.Email.ToString() == db.Logins.Where(x => x.Email == acc.Email).SingleOrDefault().ToString())
            {
                if (acc.Password.ToString() == db.Logins.Where(x => x.Password == acc.Password).SingleOrDefault().ToString())
                {
                    User = acc.Email;
                    return RedirectToAction("Home");
                }
            }
            return RedirectToAction("Home");
        }
    }
}