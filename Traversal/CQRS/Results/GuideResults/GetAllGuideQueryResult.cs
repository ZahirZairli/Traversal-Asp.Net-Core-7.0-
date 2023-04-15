namespace PresentationLayer.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int GuideId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
