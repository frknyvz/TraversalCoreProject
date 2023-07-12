using System;

namespace SignalRApi.DAL
{
    public enum ECity
    {
        Adana = 1,
        Bursa = 2,
        İstanbul = 3,
        Ankara = 4,
        İzmir = 5,
    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
