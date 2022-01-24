using System;

namespace MeetupSantander.API.Domain
{
    public class Weather
    {
        public DateTime Due { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Temperature { get; set; }
    }
}
