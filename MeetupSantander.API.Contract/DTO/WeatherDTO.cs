using System;

namespace MeetupSantander.API.Contract.DTO
{
    public class WeatherDTO
    {
        public DateTime Due { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Temperature { get; set; }
    }
}
