using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace AisTools
{
    public partial class PrintUtils : IDisposable
    {
        private Document doc2;
        private Table tbl;
        private dynamic app, doc, find;
        public int? AgreementId;
        public int? AthId;
        public int? AthId2;
        public System.Data.DataTable dt;
        public bool needToSaveAttach = false;
        public void ReplaceN(string from, object o)
        {
            Replace(from, AsCur(o));
        }
        /// <param name="wdReplaceOne">Specifies how many replacements are to be made: one, all, or none, default all.</param>
        public void Replace(string from, string to, short wdReplace = 2)
        {
            if (from.Trim() == "@")
                return;

            find.ClearFormatting();
            find.Text = from;
            find.Replacement.ClearFormatting();
            if (!string.IsNullOrEmpty(to) && (to.Length > 255))
            {
                int n = 250;
                if (to[249] == '^')
                    n = 251;
                find.Replacement.Text = to.Substring(0, n) + "@@@";
                find.Execute(Replace: wdReplace);
                Replace("@@@", to.Substring(n));
            }
            else
            {
                if (string.IsNullOrEmpty(to))
                    find.Replacement.Text = "";
                else
                    find.Replacement.Text = to.Replace(" 0:00:00", "");
                find.Execute(Replace: wdReplace);
            }
            if (from == "@DogNum")
                for (int i = 1; i <= doc.Sections.Count; i++)
                {
                    dynamic f2 = doc.Sections[i].Footers[1].Range.Find;
                    f2.Text = from;
                    f2.Replacement.Text = to;
                    f2.Wrap = 1;
                    f2.Execute(Replace: wdReplace);
                }
        }
        public string AsCur(object o)
        {
            if (o == DBNull.Value)
                return "0,0";
            else
                return Convert.ToDecimal(o).ToString("N2");
        }
        public void ReplaceData(DataView tbl, bool AsCurrency = false, bool xls = false, bool nullReplace = true, bool namedRange = false)
        {
            bool fl = false;
            if (tbl.Count > 0)
                foreach (DataRowView dr in tbl)
                {

                    foreach (DataColumn dc in tbl.Table.Columns)
                        if (dc.Ordinal > 0)
                        {
                            object o = dr.Row[dc];
                            if (AsCurrency && (dc.DataType == typeof(decimal)))
                                o = AsCur(o);
                            if (nullReplace || fl || !(o is DBNull))
                                if (namedRange)
                                    SetRangeValue(dc.ColumnName, o.ToString());
                                else if (xls)
                                    ReplaceXLS("@" + dc.ColumnName, o.ToString());
                                else
                                    Replace("@" + dc.ColumnName, o.ToString());
                        }
                    fl = true;
                }
            else if (nullReplace)
                foreach (DataColumn dc in tbl.Table.Columns)
                    if (namedRange)
                        SetRangeValue(dc.ColumnName, "");
                    else if (xls)
                        ReplaceXLS("@" + dc.ColumnName, "");
                    else
                        Replace("@" + dc.ColumnName, "");
        }
        public void OpenDoc(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;
            //app = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
            app = new Word.Application();
            doc = app.Documents.Add(filePath);
            find = app.Selection.Find;
        }
        public void ReplaceXLS(string from, string to)
        {
            if (from.Trim() == "@")
                return;
            if (!string.IsNullOrEmpty(to) && (to.Length > 255))
            {
                int n = 250;
                string toN;
                if (to[249] == '^')
                    n = 251;
                toN = to.Substring(0, n) + "@@@";
                find.UsedRange.Replace(from, toN.Replace(" 0:00:00", ""));
                ReplaceXLS("@@@", to.Substring(n));
            }
            else
            {
                find.UsedRange.Replace(from, to?.Replace(" 0:00:00", ""));
            }
        }
        public void SetRangeBold(int LRow, int LColumn, int RRow, int RColumn)
        {
            find.Range[find.Cells[LRow, LColumn], find.Cells[RRow, RColumn]].Font.Bold = true;
        }
        public void SetRangeBold(string UpperLeft, string BottomRight)
        {
            find.Range[UpperLeft, BottomRight].Font.Bold = true;
        }
        public void SetRangeItalic(int LRow, int LColumn, int RRow, int RColumn)
        {
            find.Range[find.Cells[LRow, LColumn], find.Cells[RRow, RColumn]].Font.Italic = true;
        }
        public void SetRangeItalic(string UpperLeft, string BottomRight)
        {
            find.Range[UpperLeft, BottomRight].Font.Italic = true;
        }
        public void OpenXLS(string filePath)
        {
            //app = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            app = new Excel.Application();
            app.DisplayAlerts = false;
            doc = app.WorkBooks.Open(filePath);
            SelectSheet(1);
        }
        public void CreateXLS()
        {
            //app = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            app = new Excel.Application();
            app.DisplayAlerts = false;
            doc = app.WorkBooks.Add();
            SelectSheet(1);
        }
        public void SelectSheet(int num)
        {
            try
            {
                find = doc.WorkSheets[num];
            }
            catch
            {

            }
        }
        public int CountSheets()
        {
            return doc.WorkSheets.Count();
        }
        public void RemoveSheet(int num)
        {
            doc.WorkSheets[num].Delete();
        }
        public void XlAddRow(int row)
        {
            find.Range["A" + row].EntireRow.Insert(-4121, 1);
        }
        public void SetRangeBorder(int LRow, int LColumn, int RRow, int RColumn, object LineStyle, object Weight, object[] Lines)
        {
            try
            {
                dynamic exRange = find.Range[find.Cells[LRow, LColumn], find.Cells[RRow, RColumn]];
                for (int i = 0; i < Lines.Length; i++)
                {
                    exRange.Borders[Lines[i]].LineStyle = LineStyle;
                    exRange.Borders[Lines[i]].Weight = Weight;
                }
            }
            catch
            {
            }
        }
        public void SetRangeBorder(string UpperLeft, string BottomRight, object LineStyle, object Weight, object[] Lines)
        {
            try
            {
                dynamic exRange = find.Range[UpperLeft, BottomRight];
                for (int i = 0; i < Lines.Length; i++)
                {
                    exRange.Borders[Lines[i]].LineStyle = LineStyle;
                    exRange.Borders[Lines[i]].Weight = Weight;
                }
            }
            catch
            {
            }
        }
        public int GetPosGrid()
        {
            int pos = 0;

            do
            {
                ++pos;
            }
            while (find.Range["A" + pos].Borders.LineStyle < 0);

            return pos;
        }
        public void SetMergeRange(int LRow, int LColumn, int RRow, int RColumn)
        {
            find.Range[find.Cells[LRow, LColumn], find.Cells[RRow, RColumn]].MergeCells = true;
        }
        public void SetWrapRange(int LRow, int LColumn, int RRow, int RColumn)
        {
            find.Range[find.Cells[LRow, LColumn], find.Cells[RRow, RColumn]].WrapText = true;
        }
        public void SetColumnWidth(int Column, int ColumnWidth)
        {
            find.Cells[Column].ColumnWidth = ColumnWidth;
        }
        public void SetRangeValue(string range, object value, int align = 0)
        {
            try
            {
                find.Range[range].NumberFormat = "@";
                find.Range[range].Value2 = value;
                if (align != 0)
                    find.Range[range].HorizontalAlignment = align;
            }
            catch
            {
            }
        }
        public void SetRangeValue(int Row, int Column, object value, object align = null)
        {
            try
            {
                find.Cells[Row, Column].NumberFormat = "@";
                find.Cells[Row, Column].Value2 = value;
                if (align != null)
                    find.Cells[Row, Column].HorizontalAlignment = align;
            }
            catch
            {
            }
        }
        public object GetRangeValue(string range)
        {
            try
            {
                return find.Range[range].Value2;
            }
            catch
            {
                return null;
            }
        }
        public int GetRangeCol(string range)
        {
            try
            {
                return find.Range[range].Column;
            }
            catch
            {
                return 0;
            }
        }
        public int GetRangeRow(string range)
        {
            try
            {
                return find.Range[range].Row;
            }
            catch
            {
                return 0;
            }
        }
        public object GetRangeValue(int Row, int Column)
        {
            try
            {
                return find.Cells[Row, Column].Value2;
            }
            catch
            {
                return null;
            }
        }
        public void SetNRangeValue(string range, object value)
        {
            dynamic d = find.Range[range];
            d.Value = value;
            //d.HorizontalAlignment = xlOrientation.xlRight;
            //d.NumberFormat = "#" + Config.GroupSeparator + "##0" + Config.DecimalSeparator + "00";
        }
        public void SetNRangeValue(int Row, int Column, object value)
        {
            try
            {
                dynamic d = find.Cells[Row, Column];
                d.Value = value;
                //d.HorizontalAlignment = Word.XlOrientation.xlRight;
                //d.NumberFormat = "#" + Config.GroupSeparator + "##0" + Config.DecimalSeparator + "00";
            }
            catch
            {
            }
        }
        public void SetFormula(string range, string value)
        {
            find.Range[range].HorizontalAlignment = -4152;
            find.Range[range].FormulaLocal = value;
        }
        public static string Unlocked(string path, string ext)
        {
            int i = 0;
            bool fl;
            string s;
            do
            {
                s = path.Replace('.', '_').Replace('/', '_') + i + ext;
                fl = false;
                if (File.Exists(s))
                    try
                    {
                        using (var f = File.Open(s, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            f.WriteByte(1);
                            f.Close();
                        }
                    }
                    catch
                    {
                        i++;
                        fl = true;
                    }
            }
            while (fl);
            return s;
        }
        public static void SaveFile(object sender, byte[] buf, ref string fname)
        {
            //fname = AisFile.SaveIncrement(sender, fname, buf);
        }
        public void OpenNativeDocument(string fname)
        {
            //if (richEdit == null)
            //    richEdit = new RichEditControl();
            //richEdit.LoadDocument(fname);
            //doc2 = richEdit.Document;
        }
        public void ReplaceNative(string what, string val)
        {
            string to = "";
            if (!string.IsNullOrEmpty(val))
                to = val.Replace(" 0:00:00", "");

            //doc2.ReplaceAll(what, to, SearchOptions.None);
            // doc2.ReplaceAll("@" + what, to, SearchOptions.None);
        }
        public void TableNative(int table, DataView dv, bool SumCell = true, bool AddRowDown = true, bool RowItogo = false)
        {
            tbl = doc2.Tables[table];
            int j = 0;
            decimal sum = 0;
            //TableRow row = null;

            //foreach (DataRowView dr in dv)
            //{
            //    j++;
            //    if (!AddRowDown)
            //        row = tbl.Rows.InsertBefore(j);
            //    else
            //    {
            //        if (tbl.Rows.Count - (RowItogo ? 1 : 0) == j)
            //            row = tbl.Rows.InsertAfter(j - 1);
            //        else
            //            row = tbl.Rows[j];
            //    }
            //    TableCell cell = row.FirstCell;

            //    for (int i = 0; i < row.Cells.Count; i++)
            //    {
            //        doc2.InsertSingleLineText(cell.Range.Start, dr[i].ToString());
            //        if (SumCell)
            //            if (i == 1)
            //                sum += Global.AsDecimalTrue(dr[i]);

            //        cell = cell.Next;
            //    }
            //}
            //if (SumCell)
            //{
            //    row = tbl.Rows[tbl.Rows.Count - 1];
            //    doc2.InsertSingleLineText(row.Cells[1].Range.Start, sum.ToString());
            //}
        }
        public void ReplaceNativeData(DataView tbl, bool AsCurrency = false)
        {

            if (tbl.Count > 0)
                foreach (DataRowView dr in tbl)
                {
                    foreach (DataColumn dc in tbl.Table.Columns)
                    {
                        object o = dr.Row[dc];
                        if (AsCurrency && dc.DataType == typeof(decimal))
                            o = AsCur(o);
                        ReplaceNative("@" + dc.ColumnName, o.ToString());
                    }
                }

        }
        public void SaveWordDocument(string destinationFile)
        {
            string df = Unlocked(destinationFile.Substring(0, destinationFile.Length - 4), ".pdf");
            //df = AisFile.GetIncrementName(null, df);
            doc.SaveAs(df, 17);
            doc.Saved = true;
            doc.Close(0);
            doc = null;
            app.Quit();
            app = null;
            //CoreTool.MemoryClean(this);
            //AddToAttach(AthId, df);
            //using (Process p = new Process() { StartInfo = new ProcessStartInfo(df) })
            //    p.Start();
        }
        //public void ShowPreviewPdf(string caption, FBaseForm frm, IFormParamBase param)
        //{
        //    FBaseForm f = FormManager.GetForm(EForm.FPrintPreviewPdf, FormManager.MainForm, param, caller: frm);
        //    f.Index = frm.Id.AsInt();
        //    f.Text = caption;
        //}
        //public void SaveWordDocumentPdf(string destinationFile, string caption, FBaseForm frm)
        //{
        //    if (doc == null)
        //        return;
        //    string df = Unlocked(destinationFile.Substring(0, destinationFile.Length - 4), ".pdf");
        //    df = AisFile.GetIncrementName(frm, df);
        //    doc.SaveAs(df, 17);
        //    doc.Saved = true;
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    AddToAttach(AthId, df);
        //    FormParamPrintPreview param = new FormParamPrintPreview();
        //    param.FileName = df;
        //    ShowPreviewPdf(caption, frm, param);
        //}
        //public void SaveWordDocumentDoc(string destinationFile, string caption, FBaseForm frm)
        //{
        //    string df = Unlocked(destinationFile.Substring(0, destinationFile.Length - 4), ".doc");
        //    df = AisFile.GetIncrementName(frm, df);
        //    doc.SaveAs(df);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    AddToAttach(AthId, df);
        //    FormParamPrintPreview param = new FormParamPrintPreview();
        //    param.FileName = df;
        //    ShowPreviewPdf(caption, frm, param);
        //}
        //public void SaveExcelDocumentPdf(string destinationFile, string caption, FBaseForm frm)
        //{
        //    destinationFile = AisFile.GetIncrementName(frm, destinationFile);
        //    doc.ExportAsFixedFormat(0, destinationFile);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    AddToAttach(AthId2, destinationFile);
        //    xlspdf = destinationFile;
        //    FormParamPrintPreview param = new FormParamPrintPreview();
        //    param.FileName = destinationFile;
        //    ShowPreviewPdf(caption, frm, param);
        //}
        //public void SaveWordDocument2(string destinationFile)
        //{
        //    string df = Unlocked(destinationFile.Substring(0, destinationFile.Length - 4), ".doc");
        //    doc.SaveAs(df);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    AddToAttach(AthId, df);
        //    using (Process p = new Process() { StartInfo = new ProcessStartInfo(df) })
        //        p.Start();
        //}
        //public void SaveDocument(string destinationFile)
        //{
        //    doc.SaveAs(destinationFile);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //}
        //public string this[string index]
        //{
        //    set => SetRangeValue(index, value);
        //}
        //public void PrintExcelDocument(string destinationFile, bool term, int? numPages)
        //{
        //    if (term || numPages == 1)
        //    {
        //        destinationFile = AisFile.GetIncrementName(this, destinationFile);
        //        doc.SaveAs(destinationFile);
        //        doc.Close(0);
        //        doc = null;
        //        app.Quit();
        //        app = null;
        //        CoreTool.MemoryClean(this);
        //        using (Process p = new Process())
        //        {
        //            p.StartInfo = new ProcessStartInfo($"{destinationFile}");
        //            p.Start();
        //        }
        //    }
        //    else
        //    {

        //        app.Visible = true;
        //        numPages = numPages == -1 ? 1 : numPages;
        //        app.Dialogs[Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogPrint].Show(Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            numPages,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing,
        //            Type.Missing);
        //        //doc.PrintPreview(true);

        //    }
        //}
        //public string xlspdf;
        //public void SaveExcelDocument(string destinationFile)
        //{
        //    doc.ExportAsFixedFormat(0, destinationFile);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    AddToAttach(AthId2, destinationFile);
        //    xlspdf = destinationFile;
        //    using (Process p = new Process() { StartInfo = new ProcessStartInfo(destinationFile) })
        //        p.Start();
        //}
        //public void SaveExcel(string destinationFile)
        //{
        //    doc.SaveAs(destinationFile);
        //    doc.Close(0);
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //    using (Process p = new Process() { StartInfo = new ProcessStartInfo(destinationFile) })
        //        p.Start();
        //}
        //public static void PrintWordDocument(string path, bool WhithPreview = false)
        //{
        //    //dynamic app = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
        //    dynamic app = new Word.Application();
        //    dynamic doc = app.Documents.Add(path);
        //    dynamic printDialog = app.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint];
        //    if (WhithPreview) printDialog.Show();
        //    else doc.PrintOut();
        //    doc.Close();
        //    app.Quit();
        //    CoreTool.MemoryClean(null);
        //}
        //public void QuickPrintDocument(string destinationFile, bool WhithPreview = false)
        //{
        //    string df = Unlocked(destinationFile.Substring(0, destinationFile.Length - 4), ".doc");

        //    void SaveInPdfToAttach()
        //    {
        //        doc.SaveAs(Path.ChangeExtension(df, ".pdf"), 17);
        //        doc.Saved = true;
        //        doc.Close();
        //        AddToAttach(AthId, Path.ChangeExtension(df, ".pdf"));
        //    }

        //    doc.SaveAs(df);
        //    dynamic printDialog = app.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint];
        //    if (WhithPreview)
        //    {
        //        app.ActiveWindow.SetFocus();
        //        app.ActiveWindow.Activate();
        //        if (printDialog.Show() == -1)
        //        {
        //            SaveInPdfToAttach();
        //        }
        //        else doc.Close();
        //    }
        //    else
        //    {
        //        doc.PrintOut();
        //        SaveInPdfToAttach();
        //    }
        //    doc = null;
        //    app.Quit();
        //    app = null;
        //    CoreTool.MemoryClean(this);
        //}
        public void Close()
        {
            try
            {
                doc?.Close(0);
            }
            catch //(Exception ex)
            {
                //Log.Add(this, ex);
            }
            try
            {
                app?.Quit();
            }
            catch// (Exception ex)
            {
                //Log.Add(this, ex);
            }
        }
        public void Dispose()
        {
            Close();
        }
    }
}
