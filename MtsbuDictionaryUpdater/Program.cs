using System;

namespace MtsbuDictionaryUpdater
{
    class Program
    {
        private const string MarksUrl = @"http://soabalancerdev.ingo.office:8011/MTSBU-REST/Dicts/GetMarks/";
        private const string ModelsUrl = @"http://soabalancerdev.ingo.office:8011/MTSBU-REST/Dicts/GetModels/";
        private const string MreoCitiesUrl = @"http://soabalancerdev.ingo.office:8011/MTSBU-REST/Dicts/GetMREOCities/";
        static void Main()
        {
            Console.WriteLine("Start...");
            DictionaryStore<Marks> marksStore = new DictionaryStore<Marks>(new MtsbuServiceClient(MarksUrl), new DtMarksSaver());
            marksStore.Process();
            DictionaryStore<Models> modelsStore = new DictionaryStore<Models>(new MtsbuServiceClient(ModelsUrl), new DtModelsSaver());
            modelsStore.Process();
            DictionaryStore<MreoCities> mreoCitiesStore = new DictionaryStore<MreoCities>(new MtsbuServiceClient(MreoCitiesUrl), new DtMreoCitiesSaver());
            mreoCitiesStore.Process();
            Console.WriteLine("End");
        }
    }
}
