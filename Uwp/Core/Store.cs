namespace Uwp.Core
{
    public class Store
    {
        public IReader DataReader { get; set; }
        public MainPage Page { get; set; }
        public Store(MainPage page, IReader reader)
        {
            Page = page;
            DataReader = reader;
        }
        public void Load()
        {
            DataReader.DoRead();
        }
    }
}
