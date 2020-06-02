using System;
using InvalidPassports.Interfaces;

namespace InvalidPassports
{
    public class FileStore
    {
        public IFileDownLoader DownLoader { get; set; }
        public IFileSaver Saver { get; set; }
        public FileStore(IFileDownLoader downLoader, IFileSaver saver)
        {
            DownLoader = downLoader;
            Saver = saver;
        }
        public void Process()
        {
            if (!DownLoader.Download(new EndPointAddessBuilder(AppConfig.BaseAddress), AppConfig.FilePath))
            {
                Console.WriteLine("File downloaded failed");
                return;
            }
            Console.WriteLine("File downloaded successfully");
            Saver.UpdateFromFile();
            Console.WriteLine("Data was saved successfully");
        }

    }
}

