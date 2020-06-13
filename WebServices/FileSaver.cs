using InvalidPassports.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace InvalidPassports
{
    public class FileSaver : IFileSaver
    {
        private DatabaseManager _dbManager;
        public FileSaver()
        {
            _dbManager = new DatabaseManager(AppConfig.ConnectionString);
        }
        public void UpdateFromFile()
        {
            int counter = 0;
            try
            {
                using (StreamReader reader = new StreamReader(AppConfig.FilePath))
                {
                    string line = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (counter++ > 100)
                            break;
                        SetColumnValues(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Add(ex);
            }
        }
        private void SetColumnValues(string line)
        {
            try
            {
                string[] items = line.Split(new char[] { ';' });
                string deStr = items[4].Split(new char[] { ' ' })[0];
                DateTime dateEdit = DateTime.ParseExact(deStr, "dd/M/yyyy", null);
                var pars = new Dictionary<string, object>() 
                {
                    { "ioId", DBNull.Value},
                    { "iNN", items[0] },
                    { "iSTATUS", items[1] },
                    { "iSERIES", items[2] },
                    { "iPASSPNUMBER", items[3] },
                    { "iDATEEDIT", dateEdit }
                };
                _dbManager.Update("PkInvalidPassport.Upd", pars);
            }
            catch (Exception ex)
            {
                Logger.Add(ex);
            }
        }
    }
}
