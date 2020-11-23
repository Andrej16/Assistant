using System.Collections.Generic;

namespace MtsbuDictionaryUpdater
{
    class MreoCities
    {
        public string RequestUID { get; set; }
        public string RequestExecTime { get; set; }
        public List<City> DCity { get; set; }

        public MreoCities()
        {
            DCity = new List<City>();
        }

    }

    public class City
    {
        public string DMREOCityID { get; set; }
        public string Name { get; set; }
        public string KOATUU { get; set; }
        public string ZoneCode { get; set; }
        public string IsActive { get; set; }
        public string TypeOp { get; set; }
        public string LastDate { get; set; }
    }
}
