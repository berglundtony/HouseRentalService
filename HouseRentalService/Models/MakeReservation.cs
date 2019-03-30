using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseRentalService.Models
{
    public class MakeReservation
    {
        public int ReservationID { get; set; }
        [Display(Name = "HouseType")]
        [Required]
        public Nullable<int> HouseID { get; set; }
        public IEnumerable<SelectListItem> DropdownHouseType { get; set; }
        [Required]
        public Nullable<int> CustomerID { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Personal number")]
        public string PersonalNo { get; set; }
        [Required(ErrorMessage = "You must choose number of days")]
        [Display(Name = "Number of days")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number of days must be numeric")]
        public Nullable<int> NumberOfDays { get; set; }
        [Required]
        [Display(Name = "Rent date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-nn}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
        public string Message { get; set; }
    }
}