using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CenturyCars.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }

        [Display(Name = " Car Model")]
        [Required (ErrorMessage = "please enter car model")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "please upload car image")]
        [Display(Name ="Car Image")]
        public string ImagePath { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Year of Production")]
        public string Year { get; set; }

        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}