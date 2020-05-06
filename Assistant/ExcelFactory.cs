using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Assistant
{
    /// <summary>
    /// Класс экспорта таблицы в Excel
    /// </summary>
    /// <remarks>Used FUserRights</remarks>
    /// <example>
    /// private void CreateExlReport(bool deptSign = false)
    /// {
    ///     DataTable expTable = PrepareTable(deptSign);
    ///     ExcelFactory ef = new ExcelFactory(expTable);
    ///
    ///    try
    ///    {
    ///         ShowWait();
    ///         ef.Export();
    ///     }
    ///     catch(Exception ex)
    ///     {
    ///         LogBase.Add(this, ex);
    ///         throw ex;
    ///     }
    ///     finally
    ///     {
    ///         HideWait();
    ///     }
    /// }
    /// private DataTable PrepareTable(bool deptSign)
    /// {
    ///     DataTable sourceTable;
    ///     DataTable destinationTable = new DataTable();
    ///     if (deptSign)
    ///         sourceTable = Query.Data(this, "pack_sub_de_rights.get_rights_from_usrs", new object[] { "p_su_id", UserId });
    ///     else
    ///         sourceTable = Query.Data(this, "pack_sub_de_rights.get_rights", new object[] { "p_su_id", UserId });
    ///     NameValueCollection obligCollect = new NameValueCollection
    ///     {
    ///           { "DEPT_NAME", "Департамент" },
    ///           { "SUB_NAMEFULL", "Имя пользователя" }
    ///     };
    ///     tableFactory = new DataTableFactory("FO_ID", "SDR_VALUE", "FO_NAME", destinationTable, sourceTable, obligCollect);
    ///     tableFactory.AxisSwap();
    ///     tableFactory.FillSwapedTable("SU_ID");
    ///   
    ///     return destinationTable;
    /// }
    /// </example>
    public class ExcelFactory
    {
        private Excel.Application xlApp;
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private DataColumnCollection columns;
        private DataTable source;
        private int startX;
        private int startY;
        private const string columnPrefix = "SWAP";
        /// <summary>
        /// Создает книгу и страницы, если Excel установлен
        /// </summary>
        /// <remarks>
        /// Для отображения заголовков столбцов в таблице для каждой колонки должно быть установлено свовйство Caption.
        /// </remarks>        
        /// <param name="src">Исходная таблица</param>
        public ExcelFactory(DataTable src)
        {
            xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            source = src;
            columns = source.Columns;

            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        }
        /// <summary>
        /// Выполняет экспорт таблицы в Excel документ.
        /// </summary>
        /// <param name="x">Смещение по горизонтали</param>
        /// <param name="y">Смещение по вертикали</param>
        public void Export(int x = 1, int y = 1)
        {
            startX = x;
            startY = y;

            MakeHeader();
            MakeBody();
            FormatReport();
            xlApp.Visible = true;

            ReleaseObject(xlApp);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlWorkSheet);
        }
        /// <summary>
        /// Заключительное форматирование документа
        /// </summary>
        private void FormatReport()
        {
            Excel.Range formatRange = xlWorkSheet.UsedRange;
            Excel.Borders border = formatRange.Borders;

            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous,
                Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
                Excel.XlColorIndex.xlColorIndexAutomatic);

            formatRange.NumberFormat = "@";
            formatRange.Columns.AutoFit();
        }
        /// <summary>
        /// Создание строки заголовка
        /// </summary>
        private void MakeHeader()
        {
            int seed = columns.Count + startX;

            for (int i = 0, col = startX; col < seed; col++, i++)
            {
                if (columns[i].ColumnName.StartsWith(columnPrefix))
                {
                    xlWorkSheet.Cells[startY, col] = columns[i].Caption;
                    xlWorkSheet.Cells[startY, col].Orientation = 90;
                }
                else
                    xlWorkSheet.Cells[startY, col] = columns[i].Caption;

                xlWorkSheet.Cells[startY, col].Font.Bold = true;
                xlWorkSheet.Cells[startY, col].HorizontalAlignment = Excel.Constants.xlCenter;
            }

            startY++;
        }
        /// <summary>
        /// Создание тела таблицы
        /// </summary>
        private void MakeBody()
        {
            DataRow cur;
            int rowPos;
            int colPos;

            for (int r = 0; r < source.Rows.Count; r++)
            {
                cur = source.Rows[r];
                for (int c = 0; c < columns.Count; c++)
                {
                    rowPos = r + startY;
                    colPos = c + startX;

                    xlWorkSheet.Cells[rowPos, colPos] = cur[c] is null ? "-" : cur[c];      //todo ?
                }
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
