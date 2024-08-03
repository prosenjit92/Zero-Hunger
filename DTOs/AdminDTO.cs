using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class AdminDTO
    {
        public int admin_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}