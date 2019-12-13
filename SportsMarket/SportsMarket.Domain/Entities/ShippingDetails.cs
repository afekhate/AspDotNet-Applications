using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsMarket.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage="Please enter your city name")]
        public string City { get; set; }

        [Required(ErrorMessage ="Please Enter your state name")]
        public string state { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage ="Please Enter your country name ")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }

    }
}
