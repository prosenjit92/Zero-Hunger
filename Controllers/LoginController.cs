using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.EF;

namespace Zero_Hunger.Controllers
{

    
    public class LoginController : Controller
    {
        
        [HttpGet]
        public ActionResult login()
        {
            if(Request.QueryString["id"]==null)
            { return RedirectToAction("Index", "Home"); }
            int id = int.Parse(Request.QueryString["id"]);

            
            ViewBag.id = id;
            return View();
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            Session["log"] = "log";
            
            string username = fc["username"];
            string password = fc["password"];
            string id = fc["id"];

            var db = new Zero_Hunger_dbEntities2();
            if(id=="1")
            {
                var user = (from s in db.Admins
                            where s.username == username && s.password == password
                            select s).FirstOrDefault();


                if (user != null)
                {
                    Session["admin"] = username;
                    Session["admin_id"] = user.admin_id;
                    return RedirectToAction("Admin_Dashboard", "Admin");

                }
                else
                {

                    Session["password"] = "Wrong password";
                    return View();
                }


            }

            else if (id == "2")
            {
                var user = (from s in db.Restaurants
                            where s.res_username == username && s.res_password == password
                            select s).FirstOrDefault();


                if (user != null)
                {
                    Session["restaurant"] = username;
                    Session["res_id"] = user.restaurants_id;
                    return RedirectToAction("Dashboard", "Restaurants");

                }
                else
                {

                    Session["password"] = "Wrong password";
                    return View();
                }

            }

            else if(id == "3") 
            
            {

                var user = (from s in db.employees
                            where s.username == username && s.password == password
                            select s).FirstOrDefault();


                if (user != null)
                {
                    Session["employee"] = username;
                    Session["emp_id"] = user.emp_id;
                    return RedirectToAction("Employee_Dashboard", "Employee");

                }
                else
                {

                    Session["password"] = "Wrong password";
                    return View();
                }


            }
            else { return View(); }
        }


    }
}