using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseRentalService.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "You must enter a valid Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You must enter a valid Password")]
        public string Password { get; set; }
    }
}