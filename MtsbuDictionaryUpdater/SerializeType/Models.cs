using System.Collections.Generic;

namespace MtsbuDictionaryUpdater
{
    class Models
    {
        public string RequestUID { get; set; }
        public string RequestExecTime { get; set; }
        public List<Model> DModel { get; set; }
        public Models()
        {
            DModel = new List<Model>();
        }
    }

    class Model
    {
        public string DModelID { get; set; }
        public string Name { get; set; }
        public string DMarkID { get; set; }
        public string NameEn { get; set; }
        public string NameRu { get; set; }
        public string IsActive { get; set; }
        public string TypeOp { get; set; }
        public string LastDate { get; set; }
    }
}
