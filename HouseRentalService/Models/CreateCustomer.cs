using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseRentalService.Models
{
    public class CreateCustomer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="You must write a personal number")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Personal number must be numeric")]
        public string PersonalNumber { get; set; }
        [Required(ErrorMessage = "You must write your firstname")]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must write your lastname")]
        [MaxLength(150)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "You must write a mobilenumber")]
        [MaxLength(20)]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "You must write your Email adress")]
        [EmailAddress]
        public string Email { get; set; }
    }
}