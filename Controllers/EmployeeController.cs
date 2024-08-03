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
    [Employee_Auth]
    public class EmployeeController : Controller
    {
        
        public ActionResult Employee_Dashboard()
        {
            int emp_id = Convert.ToInt32(Session["emp_id"]);
            var db = new Zero_Hunger_dbEntities2();

            var data =(from s in db.Requests
                       where s.assigned_employee_id == emp_id
                       select s).ToList();

            var list = ConvertTo(data);
            return View(list);
        }



        public ActionResult Collect(int id)
        {

            int employee_id = Convert.ToInt32(Session["emp_id"]);

            var db = new Zero_Hunger_dbEntities2();



            var result = db.employees.SingleOrDefault(b => b.emp_id == employee_id);


            if (result != null)
            {
                result.availability = "available";
                db.SaveChanges();
            }




            var result2 = db.Requests.SingleOrDefault(b => b.req_id == id);

            

            if (result2 != null)
            {
                
                result2.status = "Collected Successfully";
                db.SaveChanges();
            }


            return RedirectToAction("Employee_Dashboard");

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





        /*-------------------------------------------------------------------------------------*/
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