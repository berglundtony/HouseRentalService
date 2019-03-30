using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseRentalService.Models
{
    public class ReservationModel
    {
        public int ReservationID { get; set; }
        public Nullable<int> HouseID { get; set; }
        public string HouseType { get; set; }
        [Display(Name = "Multiplication no")]
        public Nullable<double> MultiplicationValue { get; set; }
        public Nullable<double> BaseDayFee { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<double> DayPrice { get; set; }
        public Nullable<int> CustomerID { get; set; }
        [Display(Name = "Name")]
        public string Fullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Display(Name = "Personal number")]
        public string PersonalNo { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        [Display(Name = "No of days")]
        public Nullable<int> NumberOfDays { get; set; }
        [Display(Name = "Rent date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
        public List<ReservationModel> _resarvationData { get; set; }
        public string Message { get; set; }

        public ReservationModel()
        {
            this._resarvationData = new List<ReservationModel>();
        }
    }
}
                         
                   