
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class EmployeeDTO
    {

        public int emp_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public string availability { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string status {  get; set; }
    }
}