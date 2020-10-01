using System.Collections.Specialized;
using System.Data;
using System.Linq;

namespace AisTools
{
    /// <summary>
    /// Класс для вертикального преобразования таблицы
    /// </summary>
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
    ///         Log.Add(this, ex);
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
    public class DataTableFactory
    {
        private readonly DataTable _destTable;
        private readonly DataTable _sourTable;
        private readonly DataColumnCollection _columns;
        private readonly NameValueCollection _obligatoryCollection;
        private readonly string _columnKey;
        private readonly string _columnValue;
        private readonly string _columnCaption;
        private const string ColumnPrefix = "SWAP";
        /// <summary>
        /// Создает экземпляр 
        /// </summary>
        /// <param name="fieldKey">Название поля ключа, по нему формируется имя колонок</param>
        /// <param name="fieldValue">Название поля содержащего значение</param>
        /// <param name="fieldCaption">Название поля в котором содержится наименование заголовка колонки</param>
        /// <param name="dest">Таблица назначения</param>
        /// <param name="src">Таблица содержащая исходные данные</param>
        /// <param name="oblig">Коллекция пар имя поля в исходной таблице / заголовок - для этого поля</param>
        public DataTableFactory(string fieldKey, string fieldValue, string fieldCaption, DataTable dest, DataTable src, NameValueCollection oblig)
        {
            _columnKey = fieldKey;           //FO_ID
            _columnValue = fieldValue;       //SDR_VALUE
            _columnCaption = fieldCaption;   //FO_NAME
            _destTable = dest;
            _sourTable = src;
            _columns = _destTable.Columns;
            //Обязательные колонки
            _obligatoryCollection = oblig;
            AdditionObligatoryColumns();
        }
        /// <summary>
        /// Добавляет в коллекцию колонок обязательные/статические поля
        /// </summary>
        /// <remarks>Данные поля неизменны для каждой записи. Прим. : Название, Инфо и т.д.</remarks>
        private void AdditionObligatoryColumns()
        {
            for (int i = 0; i < _obligatoryCollection.Count; i++)
            {
                DataColumn dc = new DataColumn(_obligatoryCollection.GetKey(i))
                {
                    Caption = _obligatoryCollection.Get(i)
                };
                _columns.Add(dc);
            }
        }
        /// <summary>
        /// Выполняет отображение строк ключ/значение в столбцы. 
        /// Имя т.е. Caption столбца = это значение ячейки которая задана как ключ.
        /// Заголовки колонок которые отражены имеют прфикс SWAP
        /// </summary>
        public void AxisSwap()
        {
            foreach (DataRow r in _sourTable.Rows)
            {
                string columnName = string.Concat(ColumnPrefix, r[_columnKey]);
                if (!_columns.Contains(columnName))
                {
                    DataColumn dc = new DataColumn
                    {
                        ColumnName = columnName,
                        Caption = r[_columnCaption].ToString()
                    };
                    _columns.Add(dc);
                }
            }
        }
        /// <summary>
        /// Заполняет таблицу с полями SWAP - данными. 
        /// </summary>
        /// <param name="fieldForGroup">Имя поля по котрому записи в исходной таблице группируются.</param>
        public void FillSwapedTable(string fieldForGroup)
        {
            var queryUsersGroup = _sourTable.AsEnumerable().GroupBy(p => p[fieldForGroup]).OrderBy(p => p.Key);

            foreach (var nameGroup in queryUsersGroup)
            {
                DataRow newRow = _destTable.NewRow();
                FillCells(newRow, nameGroup);
                _destTable.Rows.Add(newRow);
            }
        }
        /// <summary>
        /// Заполняет константные поля и SWAP поля.
        /// </summary>
        /// <param name="nRow">Новая строка таблицы назначения</param>
        /// <param name="group">Строки которые сгруппированы для поворота.</param>
        private void FillCells<T>(DataRow nRow, IGrouping<T, DataRow> group)
        {
            DataRow first = group.First();
            foreach (string c in _obligatoryCollection.AllKeys)
                nRow[c] = first[c];
            foreach (DataRow g in group)
                FillOtherCells(nRow, g);
        }
        /// <summary>
        /// Заполнение SWAP колонок
        /// </summary>
        /// <param name="nRow">Новая строка таблицы назначения</param>
        /// <param name="item">Одна строка из группы.</param>
        private void FillOtherCells(DataRow nRow, DataRow item)
        {
            string columnName = string.Concat(ColumnPrefix, item[_columnKey]);
            nRow[columnName] = item[_columnValue];
        }
    }
}
