//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HouseRentalService
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public int HouseID { get; set; }
        public Nullable<int> PriceID { get; set; }
        public string Type { get; set; }
        public Nullable<double> MultiplicationValue { get; set; }
    
        public virtual Price Price { get; set; }
    }
}
