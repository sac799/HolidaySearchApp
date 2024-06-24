using System;
namespace HolidaySearchLibrary.Models
{
    public class HolidaySearchResult
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice { get; set; }
    }

}

