using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace GooleMapsEmailList
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string readColumn(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            }
            else
            {
                return "blank";
            }
        }

        public void WriteToCell(int i, int j, string content)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = content;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }

        public void WriteToExcel(DataRow dataRow, int id)
        {
            WriteToCell(id + 1, 0, dataRow.getId().ToString());
            WriteToCell(id + 1, 1, dataRow.getName());
            WriteToCell(id + 1, 2, dataRow.getAdress());
            WriteToCell(id + 1, 6, dataRow.getCoordinates());
            WriteToCell(id + 1, 3, dataRow.getWebPage());
            WriteToCell(id + 1, 4, dataRow.getPhone());
            WriteToCell(id + 1, 5, dataRow.getMisc());

        }


    }
}
