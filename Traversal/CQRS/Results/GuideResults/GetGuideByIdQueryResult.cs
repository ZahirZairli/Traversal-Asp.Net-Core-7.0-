namespace PresentationLayer.CQRS.Results.GuideResults
{
    public class GetGuideByIdQueryResult
    {
        public int GuideId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
