using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CenturyCars.Domain.Entities
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required(ErrorMessage ="please enter Car Manufacturer ")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage ="please enter Car Model ")]
        public string Carmodel { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="please enter your email address")]
        public string SenderEmail { get; set; }

    }
}