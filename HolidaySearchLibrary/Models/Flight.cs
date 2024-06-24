using System;
namespace HolidaySearchLibrary.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}

