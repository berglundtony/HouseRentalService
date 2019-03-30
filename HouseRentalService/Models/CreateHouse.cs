using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseRentalService.Models
{
    public class CreateHouse
    {
        public Nullable<int> PriceID { get; set; }
        public Nullable<double> BaseDayFee { get; set; }
        public string Type { get; set; }
        public Nullable<float> MultiplicationValue { get; set; }
    }

    public class Price
    {
        public Nullable<int> PriceID { get; set; }
        public string BaseDayFee { get; set; }
    }
}