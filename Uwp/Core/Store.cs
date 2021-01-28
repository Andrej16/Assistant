namespace Uwp.Core
{
    public class Store
    {
        public IReader DataReader { get; set; }
        public Store(IReader reader)
        {
            DataReader = reader;
        }
        public void Load()
        {
            DataReader.DoRead();
        }
    }
}
