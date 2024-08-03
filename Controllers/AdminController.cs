
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Autho;
using Zero_Hunger.DTOs;
using Zero_Hunger.EF;

namespace Zero_Hunger.Controllers
{
    [Admin_Auth]
    public class AdminController : Controller
    {

        public ActionResult Admin_Dashboard()
        {
            Session["order"] = null;
            var db = new Zero_Hunger_dbEntities2();

            var data_ent = db.Requests.ToList();

            var data = ConvertTo(data_ent);

            return View(data);
        }

        public ActionResult show_all()
        {

            var db = new Zero_Hunger_dbEntities2();

            var data_ent = db.employees.ToList();

            var data = ConvertTo(data_ent);

            return View(data);



        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Session["order"] = id;
            var db = new Zero_Hunger_dbEntities2();

            var data = db.employees.ToList();

            var list = ConvertTo(data);

            return View(list);
        }

        public ActionResult Assign(int id)
        {
            int order_id = Convert.ToInt32(Session["order"]);

            var db = new Zero_Hunger_dbEntities2();

            var result = db.employees.SingleOrDefault(b => b.emp_id == id);

            
            if (result != null)
            {
                result.availability = "assigned";
                db.SaveChanges();
            }




            var result2 = db.Requests.SingleOrDefault(b => b.req_id == order_id);

            
            if (result2 != null)
            {
                result2.assigned_employee_id = id;
                result2.status = "Assigned";
                db.SaveChanges();
            }


            return RedirectToAction("Admin_Dashboard");
        }



        AdminDTO ConvertTo(Admin ad)
        {
            return new AdminDTO()
            {
                admin_id = ad.admin_id,
                name = ad.name,
                email = ad.email,
                phone = ad.phone,
                username = ad.username,
                password = ad.password,
                role = ad.role

            };
        }


        Admin ConvertTo(AdminDTO ad)
        {
            return new Admin()
            {
                admin_id = ad.admin_id,
                name = ad.name,
                email = ad.email,
                phone = ad.phone,
                username = ad.username,
                password = ad.password,
                role = ad.role

            };
        }


        RestaurantDTO ConvertTo(Restaurant res)
        {

            return new RestaurantDTO()
            {
                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name,
                rest_type = res.rest_type,
                res_email = res.res_email,
                res_location = res.res_location,
                res_phone = res.res_phone,
                res_username = res.res_username,
                res_password = res.res_password


            };

        }


        Restaurant ConvertTo(RestaurantDTO res)
        {

            return new Restaurant()
            {
                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name,
                rest_type = res.rest_type,
                res_email = res.res_email,
                res_location = res.res_location,
                res_phone = res.res_phone,
                res_username = res.res_username,
                res_password = res.res_password


            };

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



        EmployeeDTO ConvertTo(employee emp)
        {
            return new EmployeeDTO()
            {
                emp_id = emp.emp_id,
                firstName = emp.firstName,
                lastName = emp.lastName,

                email = emp.email,
                phone = emp.phone,

                address = emp.address,

                availability = emp.availability,

                role = emp.role,
                username = emp.username,
                password = emp.password
            };
        }

        employee ConvertTo(EmployeeDTO emp)
        {
            return new employee()
            {
                emp_id = emp.emp_id,
                firstName = emp.firstName,
                lastName = emp.lastName,

                email = emp.email,
                phone = emp.phone,

                address = emp.address,

                availability = emp.availability,

                role = emp.role,
                username = emp.username,
                password = emp.password
            };
        }


        List<EmployeeDTO> ConvertTo(List<employee> employees)
        {
            var emp = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                emp.Add(ConvertTo(employee));
            }

            return emp;
        }





    }
}