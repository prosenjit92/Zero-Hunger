using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.EF;

namespace Zero_Hunger.DTOs
{
    public class RestaurantDTO
    {
        public RestaurantDTO()
        {

        }

        public int restaurants_id { get; set; }
        public string rest_name { get; set; }
        public string rest_type { get; set; }
        public string res_location { get; set; }
        public string res_phone { get; set; }
        public string res_email { get; set; }
        public string res_username { get; set; }
        public string res_password { get; set; }
    }
}