using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvalidPassports.Interfaces;

namespace InvalidPassports
{
    public class DataTableFileBinder : DataTableFileBinderBase, IFileBinder
    {
        public string FileName { get; set; }
        public DataTable CreateTable(string fileName)
        {
            FileName = fileName;
            Make();
            return Table;
        }
        protected override void PrepareTable()
        {
            Table = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NN";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "STATUS";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SERIES";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PASSPNUMBER";
            Table.Columns.Add(column);
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "DATEEDIT";
            Table.Columns.Add(column);
        }
        protected override void FillTable()
        {
            int counter = 0;
            try
            {
                using(StreamReader reader = new StreamReader(FileName))
                {
                    string line = reader.ReadLine();
                    while((line = reader.ReadLine()) != null)
                    {
                        if (counter++ > 100)
                            break;
                        SetColumnValues(line);
                    }                       
                }
            }
            catch(Exception ex)
            {
                Logger.Add(ex);
            }
        }
        private void SetColumnValues(string line)
        {            
            try
            {                
                string[] items = line.Split(new char[] { ';' });
                DataRow row = Table.NewRow();
                row["NN"] = items[0];
                row["STATUS"] = items[1];
                row["SERIES"] = items[2];
                row["PASSPNUMBER"] = items[3];
                row["DATEEDIT"] = DateTime.ParseExact(items[4].Split(new char[] { ' ' })[0], "dd//MM//yyyy", null);
                Table.Rows.Add(row);
            }
            catch(Exception ex)
            {
                Logger.Add(ex);
            }
        }
    }
}

