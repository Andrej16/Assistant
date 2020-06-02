using System.Data;

namespace InvalidPassports.Interfaces
{
    public interface IFileDownLoader
    {
        bool Download(IAddressBuilder builder, string localPath);
    }
    public interface IFileBinder
    {
        DataTable CreateTable(string fileName);
    }
    public interface IFileSaver
    {
        void UpdateFromFile();
    }
    public interface IAddressBuilder
    {
        string Build();
    }
}
