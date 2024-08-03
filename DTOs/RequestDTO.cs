using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class RequestDTO
    {
       
        
        public int req_id { get; set; }

        [Required(ErrorMessage = "*Provide Food type")]
        public string food_type { get; set; }



        [Required(ErrorMessage = "*Provide you email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }



        
        public string Phone { get; set; }



        [Required(ErrorMessage = "*Provide Quantity")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid number.")]

        public int quantity { get; set; }



        [Required(ErrorMessage = "*Provide maximum prevention time")]
        [RegularExpression("^(2[1-9]|[3-9][0-9]|[1-9][0-9]{2,})$", ErrorMessage = "Number mush be greater than 20 .")]


        public int max_preservation_time { get; set; }


        public string location { get; set; }

        
        public string status { get; set; }
        public Nullable<int> rest_id { get; set; }
        public Nullable<int> assigned_employee_id { get; set; }

        [Required(ErrorMessage = "*Provide details")]
        public string details_food { get; set; }

        public Nullable<System.DateTime> date_of_order { get; set; }
    }
}