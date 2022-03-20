using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExceltoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "";
            string readfilename = System.IO.Directory.GetCurrentDirectory() + "\\table.xlsx";
            string writeJsonFileName = "table.json";
            string writeXmlFileName = "table.xml";

            if (args.Length > 1)
            {
                filePath = args[0];
                readfilename = args[1];
            }

            Excel.Application excel = new Excel.Application();
            Workbook workbook = excel.Workbooks.Open(readfilename);
            Worksheet worksheet = null;
            Console.WriteLine(workbook.Name);
            for (int i = 1; i < workbook.Worksheets.Count+1; i++)
            {
                worksheet = workbook.Worksheets.Item[i];
                Console.WriteLine(worksheet.Name);
                if (worksheet.Name.Contains("Table"))
                {
                    WriteJsonFile(worksheet);
                }
            }

            excel.Quit();
        }

        public static void WriteJsonFile(Worksheet worksheet)
        {
            List<string> column = new List<string>();
            Excel.Range range = worksheet.UsedRange;
            for(int i = 1; i < range.Columns.Count+1; i++)
            {
                column.Add((range.Cells[1, i] as Excel.Range).Value2.ToString());
                Console.WriteLine(column[i-1]);
            }
        }

        public void WriteXmlFile()
        {

        }
        

    }
}
