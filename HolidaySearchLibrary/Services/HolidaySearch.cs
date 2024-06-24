using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services
{
    public class HolidaySearch
    {
        public List<SearchResult> Results { get; private set; }

        private List<Flight> _flights;
        private List<Hotel> _hotels;

        public HolidaySearch(List<Flight> flights, List<Hotel> hotels)
        {
            _flights = flights;
            _hotels = hotels;
            Results = new List<SearchResult>();
        }

        public void Search(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            Console.WriteLine("Starting search...");
            Console.WriteLine($"DepartingFrom: {departingFrom}, TravelingTo: {travelingTo}, DepartureDate: {departureDate}, Duration: {duration}");

            var matchingFlights = _flights.Where(f =>
                (departingFrom == "Any" || f.DepartingFrom == departingFrom) &&
                f.TravelingTo == travelingTo &&
                f.DepartureDate.Date == departureDate.Date
            ).ToList();
            Console.WriteLine($"Found {matchingFlights.Count} matching flights");

            var matchingHotels = _hotels.Where(h =>
                h.Location == travelingTo &&
                h.AvailableFrom.Date <= departureDate.Date &&
                h.AvailableTo.Date >= departureDate.Date.AddDays(duration) &&
                h.Nights == duration
            ).ToList();
            Console.WriteLine($"Found {matchingHotels.Count} matching hotels");

            Results = (from flight in matchingFlights
                       from hotel in matchingHotels
                       select new SearchResult
                       {
                           Flight = flight,
                           Hotel = hotel,
                           TotalPrice = flight.Price + hotel.Price
                       }).OrderBy(r => r.TotalPrice).ToList();
            Console.WriteLine($"Found {Results.Count} matching results");
        }
    }

    public class SearchResult
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
