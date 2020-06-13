using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidPassports
{
    public static class AppConfig
    {
        public static string ConnectionString;
        public const string FilePath = @"g:\Download\Хлам\InvalidPassports.csv";
        //public const string BaseAddress = @"https://data.gov.ua/dataset/5e7b4df9-7bf3-4da2-9497-1a0d957fcfbe/resource/733f553d-dece-4c3f-ba42-97937f26b807/download/pgu_29042020.csv";
        public const string BaseAddress = @"https://data.gov.ua/dataset/5e7b4df9-7bf3-4da2-9497-1a0d957fcfbe/resource/733f553d-dece-4c3f-ba42-97937f26b807/download/pgu_";
        private const string _dbWork = @"Data Source=hercules.ingo.office:1521/insbcp.ingo.office;Persist Security Info=True;User ID=Insuradm;Password=AisIngo";
        private const string _dbTest = @"Data Source=dboracledev.ingo.office:1521/insbcp;Persist Security Info=True;User ID=INSURADM;Password=AisIngo";
        static AppConfig()
        {
            ConnectionString = _dbTest;
        }
    }
}
