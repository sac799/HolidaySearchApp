using System;
using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services
{
    public class HolidaySearch
    {
        public List<SearchResult> Results { get; private set; }
        public HolidaySearch(List<Flight> flights, List<Hotel> hotels)
        {

        }

        public void Search(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {

        }

        public class SearchResult
        {
            public Flight Flight { get; set; }
            public Hotel Hotel { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }
}
