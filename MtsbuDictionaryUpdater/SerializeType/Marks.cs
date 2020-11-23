using System.Collections.Generic;

namespace MtsbuDictionaryUpdater 
{ 
    class Marks
    {
        public string RequestUID { get; set; }
        public string RequestExecTime { get; set; }
        public List<Mark> DMark { get; set; }

        public Marks()
        {
            DMark = new List<Mark>();
        }
    }

    class Mark
    {
        public string DMarkID { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string IsActive { get; set; }
        public string TypeOp { get; set; }
        public string LastDate { get; set; }
    }
}
