using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        static async Task Main(string[] args)
        {

            Console.WriteLine("****************************************");
            Console.WriteLine("*请把要转成excel的SKU文件夹放到桌面。");
            Console.WriteLine("*如果已经放好请按任意键继续。");
            Console.ReadKey(true);
            Console.WriteLine("*请输入文件夹的名称。");
            string folderName = Console.ReadLine()?.Trim();

            string deskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";
            while (string.IsNullOrEmpty(folderName))
            {
                folderName = Console.ReadLine()?.Trim();
            }

            while (!Directory.Exists($@"{deskTopPath}{folderName}"))
            {
                Console.WriteLine("*文件夹的名称输入有误,请确认后再重新输入。");
                folderName = Console.ReadLine()?.Trim();
            }

            string[] filesPath = Directory.GetFiles(deskTopPath + folderName);


            GetDataSource(filesPath);
            DataProcessing();
            WriteExcel(deskTopPath);

            Console.WriteLine("*****转换结束*****");
            Console.WriteLine("*请到桌面去查看。*");
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
