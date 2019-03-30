using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseRentalService.Models;

namespace HouseRentalService.Functions
{
    public static class FunctionReservation
    {
        public static double? GetTotalPrice(double? housePrice, double? multiplyValue, int? numberOfDays)
        {
            if (multiplyValue == 0)
            {
                return housePrice * numberOfDays;
            }
            else
            {
                return (housePrice * numberOfDays) * multiplyValue;
            }
        }

        public static double? GetDayPrice(double? housePrice, double? multiplyValue)
        {
            if (multiplyValue == 0)
            {
                return housePrice;
            }
            else
            {
                return housePrice * multiplyValue;
            }
        }

        /// <summary>
        /// Dropdownlist ous housetypes for creating reservations 
        /// </summary>
        /// <returns></returns>

        public static IEnumerable<SelectListItem> GetHouses()
        {
            try
            {
                using (var db = new HouseRentalServiceEntities())
                {
                    List<SelectListItem> _houses = db.Houses.Select(x =>
                new SelectListItem
                {
                    Value = x.HouseID.ToString(),
                    Text = x.Type
                }).ToList();

                    return new SelectList(_houses, "Value", "Text");
                }

            }
            catch (Exception ex)
            {
                string exmessage = ex.Message;
                string innerexception = ex.InnerException.ToString();
                return new SelectList("Error:No data", "Value", "Text");
            }
        }

        /// <summary>
        /// Dropdownlist ous housetypes for creating reservations 
        /// </summary>
        /// <returns></returns>

        public static IEnumerable<SelectListItem> GetHouses(int? houseid)
        {
            try
            {
                using (var db = new HouseRentalServiceEntities())
                {
                    List<SelectListItem> _houses = db.Houses.Select(x =>
                    new SelectListItem
                    {
                        Value = x.HouseID.ToString(),
                        Text = x.Type,
                        Selected = x.HouseID == houseid ? true : false
                    }).ToList();

                    return new SelectList(_houses, "Value", "Text");
                }

            }
            catch (Exception ex)
            {
                string exmessage = ex.Message;
                string innerexception = ex.InnerException.ToString();
                return new SelectList("Error:No data", "Value", "Text");
            }
        }

        public static List<ReservationModel> GetDataForReservations()
        {
            List<ReservationModel> _resarvations = new List<ReservationModel>();
            try
            {
                using (var db = new HouseRentalServiceEntities())
                {
                    var _rm = (from x in db.Reservations
                               join r in db.Customers on x.CustomerID equals r.CustomerID
                               join h in db.Houses on x.HouseID equals h.HouseID
                               join p in db.Prices on h.PriceID equals p.PriceID
                               select new
                               {
                                   ResId = x.ReservationID,
                                   HouseType = h.Type,
                                   MultiplyValue = h.MultiplicationValue,
                                   HousePrice = p.BaseDayFee,
                                   Fullname = r.FirstName + " " + r.Lastname,
                                   PersonalNr = r.PersonalNumber,
                                   Telephone = r.MobileNumber,
                                   Email = r.Email,
                                   NumberOfDays = x.NumberOfDays,
                                   Date = x.Date
                               }).ToList();

                    foreach (var i in _rm)
                    {
                        _resarvations.Add(
                            new ReservationModel
                            {
                                ReservationID = i.ResId,
                                HouseType = i.HouseType,
                                MultiplicationValue = i.MultiplyValue,
                                BaseDayFee = i.HousePrice,
                                DayPrice = FunctionReservation.GetDayPrice(i.HousePrice, i.MultiplyValue),
                                TotalPrice = FunctionReservation.GetTotalPrice(i.HousePrice, i.MultiplyValue, i.NumberOfDays),
                                Fullname = i.Fullname,
                                PersonalNo = i.PersonalNr,
                                Telephone = i.Telephone,
                                Email = i.Email,
                                NumberOfDays = i.NumberOfDays,
                                Date = i.Date
                            });
                    }
                    return _resarvations;
                }
            }
            catch (Exception ex)
            {
                string exmessage = ex.Message;

                return null;
            }

        }
        /// <summary>
        /// Data for the Details view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public static ReservationModel GetDetailForReservation(int? id)
        {
            ReservationModel model = new ReservationModel();
            try
            {
                using (var db = new HouseRentalServiceEntities())
                {
                    var result = (from x in db.Reservations
                                  join r in db.Customers on x.CustomerID equals r.CustomerID
                                  join h in db.Houses on x.HouseID equals h.HouseID
                                  join p in db.Prices on h.PriceID equals p.PriceID
                                  select new
                                  {
                                      ResId = x.ReservationID,
                                      HouseType = h.Type,
                                      MultiplyValue = h.MultiplicationValue,
                                      HousePrice = p.BaseDayFee,
                                      Fullname = r.FirstName + " " + r.Lastname,
                                      PersonalNr = r.PersonalNumber,
                                      Telephone = r.MobileNumber,
                                      Email = r.Email,
                                      NumberOfDays = x.NumberOfDays,
                                      Date = x.Date
                                  }).Where(y => y.ResId == id).FirstOrDefault();

                    model.ReservationID = result.ResId;
                    model.HouseType = result.HouseType;
                    model.MultiplicationValue = result.MultiplyValue;
                    model.BaseDayFee = result.HousePrice;
                    model.NumberOfDays = result.NumberOfDays;
                    model.DayPrice = GetDayPrice(model.BaseDayFee, model.MultiplicationValue);
                    model.TotalPrice = GetTotalPrice(model.BaseDayFee, model.MultiplicationValue, model.NumberOfDays);
                    model.Fullname = result.Fullname;
                    model.PersonalNo = result.PersonalNr;
                    model.Telephone = result.Telephone;
                    model.Email = result.Email;
                    model.Date = result.Date;

                    return model;
                }
            }
            catch (Exception ex)
            {
                string exmessage = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// Data for the edit Details view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MakeReservation GetEditDetailForReservation(int? id)
        {
            MakeReservation model = new MakeReservation();
            try
            {
                using (var db = new HouseRentalServiceEntities())
                {
                    var result = (from x in db.Reservations
                                  join r in db.Customers on x.CustomerID equals r.CustomerID
                                  join h in db.Houses on x.HouseID equals h.HouseID
                                  join p in db.Prices on h.PriceID equals p.PriceID
                                  select new
                                  {
                                      ResId = x.ReservationID,
                                      HouseID = h.HouseID,
                                      MultiplyValue = h.MultiplicationValue,
                                      HousePrice = p.BaseDayFee,
                                      Fullname = r.FirstName + " " + r.Lastname,
                                      CustomerID = r.CustomerID,
                                      PersonalNr = r.PersonalNumber,
                                      Telephone = r.MobileNumber,
                                      Email = r.Email,
                                      NumberOfDays = x.NumberOfDays,
                                      Date = x.Date
                                  }).Where(y => y.ResId == id).FirstOrDefault();

                    model.ReservationID = result.ResId;
                    model.HouseID = result.HouseID;
                    model.NumberOfDays = result.NumberOfDays;
                    model.CustomerID = result.CustomerID;
                    model.FullName = result.Fullname;
                    model.PersonalNo = result.PersonalNr;
              
                    model.Date = result.Date;

                    return model;
                }
            }
            catch (Exception ex)
            {

                string exmessage = ex.Message;
         
                return null;
            }

        }
    }
}