using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CenturyCars.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter Car Manufacturer ")]
        [Display(Name = "Manufacturer")]
        public string Name { get; set; }

        [Display(Name = " Car Model")]
        public string Carmodel { get; set; }


        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }



        [Required(ErrorMessage = "Please enter your city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter your state name")]
        public string state { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please Enter your country name ")]
        public string Country { get; set; }
    }
}