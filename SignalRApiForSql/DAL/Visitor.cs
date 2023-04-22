namespace SignalRApiForSql.DAL
{
    public enum ECity
    {
        Baku = 1,
        Ganja = 2,
        Sheki = 3,
        Sumgait = 4,
        Yardimli = 5
    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
