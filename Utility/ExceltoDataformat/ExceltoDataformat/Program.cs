using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            string readfilePath = "";
            string readfilename = System.IO.Directory.GetCurrentDirectory() + "\\table.xlsx";
            string outfilePath = "";

            if (args.Length > 2)
            {
                readfilePath = args[0];
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
                string worksheetname = worksheet.Name;
                Console.WriteLine("===========================================================");
                Console.WriteLine(worksheetname);
                if (worksheetname.Contains("Table"))
                {
                    
                    string column;
                    string type;
                    string data;
                    List<string> columns = new List<string>();
                    List<string> datas = new List<string>();
                    Excel.Range range = worksheet.UsedRange;
                    for (int j = 1; j < range.Columns.Count + 1; j++)
                    {
                        // 칼럼 및 데이터 형식 가져오기
                    }
                    for (int j = 3; j < range.Rows.Count + 1; j++)
                    {
                        // 데이터 한줄
                        for (int k = 1; k < range.Columns.Count + 1; k++)
                        {
                            // 데이터 하나
                            if ((range.Cells[j, k] as Excel.Range).Value2 != null)
                            {
                                
                            }
                           
                        }
                    }
                    //데이터 완성







                    for (int j = 1; j < range.Columns.Count + 1; j++)
                    {
                        column = (range.Cells[1, j] as Excel.Range).Value2.ToString();
                        type = (range.Cells[2, j] as Excel.Range).Value2.ToString();
                        XmlText += string.Format(StringFormat.XmlDataFormat, type, column);
                        columns.Add(column);
                        //Console.WriteLine(column);
                    }
                    string jsondata = "";
                    for(int j = 3;j < range.Rows.Count + 1; j++)
                    {
                        Console.WriteLine("로우갯수");
                        Console.WriteLine(range.Rows.Count);
                        Console.WriteLine("===========================");
                        for(int k = 1; k < range.Columns.Count +1; k++)
                        {
                            if ((range.Cells[j, k] as Excel.Range).Value2 != null)
                            {
                                if (k != 1)
                                {
                                    jsondata += ",\n";
                                }
                                data = (range.Cells[j, k] as Excel.Range).Value2.ToString();
                                Console.Write(data);
                                jsondata += string.Format(StringFormat.JsonDataFormat, columns[k-1], data);
                            }
                            Console.Write("\n");
                        }
                        JsonText += string.Format(StringFormat.JsonFormat, jsondata);
                        jsondata = "";
                        datas.Clear(); ;
                    }
                    WriteJsonFile(outfilePath,worksheetname);
                    WriteXmlFile(outfilePath,worksheetname);
                    
                    
                }
            }

            excel.Quit();
            //Marshal.ReleaseComObject();
        }

        public static void WriteJsonText(List<string> columns,List<string> datas)
        {
            string jsondata = "";
            for(int i = 0; i < datas.Count; i++)
            {
                jsondata += string.Format(StringFormat.JsonDataFormat, columns[i], datas[i]) + "\n";
            }
            JsonText += string.Format(StringFormat.JsonFormat, jsondata) + "\n";

        }

        public static void WriteXmlText(string table, string data)
        {
            
        }
        public static void WriteJsonFile(string outfilepath,string table)
        {
           
            System.IO.File.WriteAllText(outfilepath + table + ".json",JsonText);

            JsonText = "";
        }
        public static void WriteXmlFile(string outfilePath,string table)
        {
            XmlText = string.Format(StringFormat.XmlFormat, table, XmlText);
            System.IO.File.WriteAllText(outfilePath + table + ".xml", XmlText);
            XmlText = "";
        }        

    }
}
