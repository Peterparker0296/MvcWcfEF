using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.MyServiceClient ef = new ServiceReference1.MyServiceClient();
        public ActionResult Index()
        {
            List<User> lstRecord = new List<User>();

            var lst = ef.GetAllUser();

            foreach (var item in lst)
            {
                User usr = new User();
                usr.ID = item.ID;
                usr.Name = item.Name;
                usr.Email = item.Email;
                lstRecord.Add(usr);

            }
            return View(lstRecord);

        }
        //-------------------------------------------------------------------------------------------

        public ActionResult Add()
        {

            return View();
        }

        //-------------------------------------------------------------------------------------------

        [HttpPost]

        public ActionResult Add(User md1)
        {
            User usr = new User();
            usr.Name = md1.Name;
            usr.Email = md1.Email;
            ef.AddUser(usr.Name, usr.Email);
            return RedirectToAction("Index", "Home");
        }

        //-------------------------------------------------------------------------------------------

        public ActionResult Delete(int id)
        {
            int retval = ef.DeleteUserById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        //-------------------------------------------------------------------------------------------


        public ActionResult Edit(int id)
        {
            var lst = ef.GetAllUserById(id);
            User usr = new User();
            usr.ID = lst.ID;
            usr.Name = lst.Name;
            usr.Email = lst.Email;
            return View(usr);

        }

        //-------------------------------------------------------------------------------------------

        [HttpPost]
        public ActionResult Edit(User mdl)
        {
            User usr = new User();
            usr.ID = mdl.ID;
            usr.Name = mdl.Name;
            usr.Email = mdl.Email;


            int Retval = ef.UpdateUser(usr.ID, usr.Name, usr.Email);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //-------------------------------------------------------------------------------------------






    }


}