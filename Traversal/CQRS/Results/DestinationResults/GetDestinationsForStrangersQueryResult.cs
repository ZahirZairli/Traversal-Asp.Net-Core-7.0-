using EntityLayer.Concrete;

namespace PresentationLayer.CQRS.Results.DestinationResults
{
    public class GetDestinationsForStrangersQueryResult
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string DayNight { get; set; }
        public int Capacity { get; set; }
    }
}
