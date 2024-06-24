using System;
namespace HolidaySearchLibrary.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public int Nights { get; set; }
        public decimal Price { get; set; }
    }

}

