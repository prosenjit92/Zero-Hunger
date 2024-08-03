using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Autho;
using Zero_Hunger.DTOs;
using Zero_Hunger.EF;
using static System.Collections.Specialized.BitVector32;

namespace Zero_Hunger.Controllers
{
    [Rest_Auth]
    public class RestaurantsController : Controller
    {
        
        public ActionResult login()
        {

           
            return View();
        }

       

        public ActionResult Dashboard() 
        {
            
            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities2();
            var data = (from s in db.Requests
                        where s.rest_id == us_id && (s.status == "pendding" || s.status =="Assigned")
                        select s).ToList();

            var list = ConvertTo(data);

            return View(list); 
        
        }

        [HttpGet]
        public ActionResult Show_all_donation()
        {
            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities2();
            var data = (from s in db.Requests
                        where s.rest_id == us_id
                        select s).ToList();
            var list = ConvertTo(data);
            return View(list);

            
        }



        [HttpGet]
        public ActionResult Request_send() {

            ViewBag.now= DateTime.Now;

            ViewBag.res_idd= Convert.ToInt32(Session["res_id"]);


            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities2();
            var data = (from s in db.Restaurants
                        where s.restaurants_id == us_id
                        select s).FirstOrDefault();

            var list = ConvertTo(data);
            return View(list);

        }


        [HttpPost]
        public ActionResult Request_send(RequestDTO r)
        {
            var db=new Zero_Hunger_dbEntities2();

            var req = ConvertTo(r);

            db.Requests.Add(req);
            db.SaveChanges();

            return RedirectToAction("Dashboard");

        }



        RequestDTO ConvertTo(Request request)
        {
            return new RequestDTO()
            {
                req_id = request.req_id,
                food_type = request.food_type,
                Email = request.Email,
                Phone = request.Phone,
                quantity = (int)request.quantity,
                max_preservation_time = (int)request.max_preservation_time,
                location = request.location,
                status = request.status,
                rest_id = request.rest_id,
                assigned_employee_id = request.assigned_employee_id,
                details_food = request.details_food,
                date_of_order = request.date_of_order


            };
        }

        Request ConvertTo(RequestDTO request)
        {
            return new Request()
            {
                req_id = request.req_id,
                food_type = request.food_type,
                Email = request.Email,
                Phone = request.Phone,
                quantity = request.quantity,
                max_preservation_time = request.max_preservation_time,
                location = request.location,
                status = request.status,
                rest_id = request.rest_id,
                assigned_employee_id = request.assigned_employee_id,
                details_food = request.details_food,
                date_of_order = request.date_of_order


            };
        }

        List<RequestDTO> ConvertTo(List<Request> requests)
        {
            var rq = new List<RequestDTO>();
            foreach (var request in requests)
            {
                rq.Add(ConvertTo(request));
            }
            return rq;

        }



        RestaurantDTO ConvertTo(Restaurant res)
        {

            return new RestaurantDTO()
            {

                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name ?? string.Empty,
                rest_type = res.rest_type ?? string.Empty,
                res_email = res.res_email ?? string.Empty,
                res_location = res.res_location ?? string.Empty,
                res_phone = res.res_phone ?? string.Empty,
                res_username = res.res_username ?? string.Empty,
                res_password = res.res_password ?? string.Empty


            };

        }



        Restaurant ConvertTo(RestaurantDTO res)
        {

            return new Restaurant()
            {
                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name ?? string.Empty,
                rest_type = res.rest_type ?? string.Empty,
                res_email = res.res_email ?? string.Empty,
                res_location = res.res_location ?? string.Empty,
                res_phone = res.res_phone ?? string.Empty,
                res_username = res.res_username ?? string.Empty,
                res_password = res.res_password ?? string.Empty



            };

        }
    }
}