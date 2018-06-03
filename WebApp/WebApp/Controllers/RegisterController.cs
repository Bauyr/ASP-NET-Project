using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        RegistrationEntities dbcontext = new RegistrationEntities();
        // GET: Register
        public ActionResult SetDataInDataBase(LoginPage model)
        {
            LoginPage t = new LoginPage();
            t.Username = model.Username;
            t.Password = model.Password;
            dbcontext.LoginPages.Add(t);
            dbcontext.SaveChanges();
            return View();
        }

        public ActionResult ShowData()
        {
            var item = dbcontext.LoginPages.ToList();
            return View(item);
        }

        public ActionResult DeleteData(int id)
        {
            var item = dbcontext.LoginPages.Where(x => x.Id == id).First();
            dbcontext.LoginPages.Remove(item);
            dbcontext.SaveChanges();
           
            var item2 = dbcontext.LoginPages.ToList();
            return View("ShowData", item2);    
        }

        public ActionResult EditData(int id)
        {
            var item = dbcontext.LoginPages.Where(x => x.Id == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult EditData(LoginPage model)
        {
            var item = dbcontext.LoginPages.Where(x => x.Id == model.Id).First(); ;
            item.Username = model.Username;
            item.Password = model.Password;
            dbcontext.SaveChanges();
            var item2 = dbcontext.LoginPages.ToList();
            return View("ShowData", item2);
            
        }
    }
}