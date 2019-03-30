using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseRentalService.Models
{
    public class CheckCustomer
    {
        [Required(ErrorMessage = "You must write a personal number")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Personal number must be numeric")]
        public string PersonalNumber { get; set; }
        public string Message { get; set; }
    }
}