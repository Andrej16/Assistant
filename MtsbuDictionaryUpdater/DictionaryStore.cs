using Newtonsoft.Json;

namespace MtsbuDictionaryUpdater
{
    public class DictionaryStore<T> where T : class
    {
        public string JsonContent { get; set; }
        public IServiceClient ServiceClient { get; set; }
        public IDictionarySaver Saver { get; set; }
        public DictionaryStore(IServiceClient sc, IDictionarySaver s)
        {
            ServiceClient = sc;
            Saver = s;
        }
        public void Process()
        {
            JsonContent = ServiceClient.GetJson();
            T dictionary = JsonConvert.DeserializeObject<T>(JsonContent);
            Saver.Save(dictionary);
        }
    }
}
