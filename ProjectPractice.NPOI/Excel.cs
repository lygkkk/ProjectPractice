using System.Data;
using System.IO;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ProjectPractice.Npoi
{
    public class Excel
    {
        //public async Task<DataTable> ReadDataTask(ISheet sheet)
        //{
        //    GetWorkbookTask("", FileAccess.Read, FileAccess.Read)
        //}

        #region 获取工作簿

        public async Task<IWorkbook> GetWorkbookTask(string path, FileMode fileMode, FileAccess fileAccess)
        {
            IWorkbook workbook = null;

            await Task.Run(async () =>
            {
                await using FileStream fileStream = new FileStream(path, fileMode, fileAccess, FileShare.Read);
                workbook = new XSSFWorkbook(fileStream);
            });

            return workbook;
        }

        #endregion
    }
}