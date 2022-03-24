using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExceltoJson
{
    class Program
    {
        public static string JsonText;
        public static string XmlText;
        static void Main(string[] args)
        {
            string filePath = "";
            string readfilename = System.IO.Directory.GetCurrentDirectory() + "\\table.xlsx";
            string outfilePath = "";
            string writeJsonFileName = "table.json";
            string writeXmlFileName = "table.xml";

            if (args.Length > 2)
            {
                filePath = args[0];
                readfilename = args[1];
                outfilePath = args[2];
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
                    string column;
                    string type;
                    List<string> columns = new List<string>();
                    List<string> data = new List<string>();
                    Excel.Range range = worksheet.UsedRange;
                    for (int j = 1; j < range.Columns.Count + 1; j++)
                    {
                        column = (range.Cells[1, i] as Excel.Range).Value2.ToString();
                        type = (range.Cells[2, i] as Excel.Range).Value2.ToString();
                        XmlText += string.Format(StringFormat.XmlDataFormat, type, column);
                        columns.Add(column);
                    }
                    for(int j = 1;j<range.Rows.Count + 1; j++)
                    {
                        for(int k = 1; k<range.Columns.Count +1; k++)
                        {
                            data.Add(range.Cells[j, k]);
                        }
                        WriteJsonText(columns, data);
                    }
                    WriteJsonFile();
                    WriteXmlFile();
                    JsonText = "";
                    XmlText = "";
                }
            }

            excel.Quit();
        }

        public static void WriteJsonText(List<string> columns,List<string> data)
        {
            string jsondata = "";
            for(int i = 0; i < data.Count; i++)
            {
                jsondata += string.Format(StringFormat.JsonDataFormat, columns[i], data[i]) + "\n";
            }
            JsonText += string.Format(StringFormat.JsonFormat, jsondata) + "\n";

        }

        public static void WriteXmlText(string column, string type)
        {
            
        }
        public static void WriteJsonFile()
        {

        }
        public static void WriteXmlFile()
        {

        }        

    }
}
