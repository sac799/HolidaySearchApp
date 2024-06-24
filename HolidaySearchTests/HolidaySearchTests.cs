using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HolidaySearchLibrary.HolidaySearchTests
{
    public class HolidaySearchTests
    {
        private List<Flight> LoadFlightsFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        private List<Hotel> LoadHotelsFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Hotel>>(json);
        }

        [Test]
        public void TestCustomer1()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("MAN", "AGP", new DateTime(2023, 7, 1), 7);
            var result = holidaySearch.Results.First();
            Assert.Equals(2, result.Flight.Id);
            Assert.Equals(2, result.Hotel.Id);
        }

        [Test]
        public void TestCustomer2()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("Any", "PMI", new DateTime(2023, 6, 15), 10);
            var result = holidaySearch.Results.First();
            Assert.Equals(6, result.Flight.Id);
            Assert.Equals(5, result.Hotel.Id);
        }

        [Test]
        public void TestCustomer3()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("Any", "LPA", new DateTime(2022, 11, 10), 14);
            var result = holidaySearch.Results.First();
            Assert.Equals(7, result.Flight.Id);
            Assert.Equals(6, result.Hotel.Id);
        }

        [Test]
        public void TestNonExistentDepartureAirport()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("XYZ", "AGP", new DateTime(2023, 7, 1), 7);
            Assert.Equals("",holidaySearch.Results);
        }

        [Test]
        public void TestNonExistentDestinationAirport()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("MAN", "XYZ", new DateTime(2023, 7, 1), 7);
            Assert.Equals("",holidaySearch.Results);
        }

        [Test]
        public void TestDepartureDateOutsideAvailableDates()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("MAN", "AGP", new DateTime(2023, 1, 1), 7);
            Assert.Equals("",holidaySearch.Results);
        }

        [Test]
        public void TestInvalidDurationNoMatchingHotel()
        {
            var flights = LoadFlightsFromJson("flights.json");
            var hotels = LoadHotelsFromJson("hotels.json");

            var holidaySearch = new HolidaySearch(flights, hotels);
            holidaySearch.Search("MAN", "AGP", new DateTime(2023, 7, 1), 14);
            Assert.Equals("",holidaySearch.Results);
        }
    }
}
