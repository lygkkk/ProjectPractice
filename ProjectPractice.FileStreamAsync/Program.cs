using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;

namespace ProjectPractice.FileStreamAsync
{
    class Program
    {
        private static Task _createExcelTask;
        private static List<string[]> _sourceList;
        private static List<List<string[]>> _resultList;
        private static List<string> _fileNameList;
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\Example1.txt";

     
                foreach (var item in ReadTextFileData(path))
                {
                    Console.WriteLine($"第X行：{item}");
                }
                
            
            
        }

        public static IEnumerable<Task<string>> ReadTextFileData(string path)
        {
            //List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLineAsync();
                    //list.Add(await sr.ReadLineAsync());
                    //return await sr.ReadLineAsync();
                }
            }
            //return list;
        }

        static void WriteExcel(string deskTopPath)
        {
            
            string saveAsPath = $@"{deskTopPath}SKU-To-Excel{DateTime.Now.ToString("yy-MM-dd-hh-mm-ss")}";
            
            Directory.CreateDirectory(saveAsPath);
            int index = 0;
            _resultList.ForEach(e =>
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                for (var index1 = 0; index1 < e.Count; index1++)
                {
                    IRow row = sheet.CreateRow(index1);
                    
                    for (var i = 0; i < e[index1].Length; i++)
                    {
                        ICell cell = row.CreateCell(i);
                        cell.SetCellValue(e[index1][i]);
                    }
                }

                FileStream fileStream = File.Create($@"{saveAsPath}\{_fileNameList[index]}.xlsx");
                workbook.Write(fileStream);
                fileStream.Close();
                index++;
            });

            
        }

        static void DataProcessing()
        {
            _resultList = new List<List<string[]>>();
            List<string[]> tmpList = new List<string[]>();
            _sourceList.ForEach(e =>
            {
                foreach (string item in e)
                {
                    tmpList.Add(item.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }

                _resultList.Add(tmpList);
            });
        }

        static void GetDataSource(string[] filesPath)
        {
            _fileNameList = new List<string>();
            _sourceList = new List<string[]>();
            foreach (string file in filesPath)
            {
                //System.IO.FileStream fileStream = new System.IO.FileStream("", FileMode.OpenOrCreate, FileAccess.Read);
                //StreamReader streamReader = new StreamReader(file, Encoding.Default);
                _fileNameList.Add(Path.GetFileNameWithoutExtension(file));
                _sourceList.Add(File.ReadAllLines(file));
            }
        }

        static Task CreateExcelAsync(string[] filesPath, string saveAsPath)
        {
            return Task.Run(() =>
            {
                foreach (string file in filesPath)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    IWorkbook workbook = new XSSFWorkbook();
                    workbook.CreateSheet("Sheet1");
                    FileStream fileStream = File.Create($@"{saveAsPath}\{fileName}.xlsx");
                    workbook.Write(fileStream);
                    fileStream.Close();
                }
            });
        }
    }
}
