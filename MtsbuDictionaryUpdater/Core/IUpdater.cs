namespace MtsbuDictionaryUpdater
{
    public interface IServiceClient
    {
        string GetJson();
    }
    public interface IDictionarySaver
    {
        void Save<T>(T dictionary);
    }

}
