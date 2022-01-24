namespace MeetupSantander.API.Data.Entities
{
    public class BeerTemperature
    {
        public int Id { get; set; }
        public decimal TemperatureMin { get; set; }
        public decimal TemperatureMax { get; set; }
        public decimal BeersPerPerson { get; set; }
        public int BeersPerBox { get; set; }
    }
}
