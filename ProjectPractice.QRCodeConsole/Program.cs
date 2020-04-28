using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;

namespace ProjectPractice.QRCodeConsole
{
    class Program
    {

        #region 二维码生成
        /// <summary>
        /// 二维码生成
        /// </summary>
        /// <param name="data">数据信息</param>
        /// <param name="codeSizeInPixels">尺寸</param>
        /// <returns>返回Bitmap格式的图片</returns>
        static void Main(string[] args)
        {
            if (args.Length < 2) return;

            //var deskTop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //MessageBox.Show(args[0] + "     " + args[1]);
            var bmp = GenByZXingNet(args[0]);
            SaveBmp(args[1], bmp);
        

        }
        #endregion


        #region C#生成二维码-基础版本
        //需要引用ZXing.DLL  可以百度一下  一个很好用的二维码生成程序集《DLL文件啦》
        //使用案例：Bitmap img3 = GenByZXingNet("");
        //使用案例：img3.Save(Server.MapPath(@"\testImg\erweima.png"));
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">二维码信息</param>
        /// <param name="codeSizeInPixels">正方形 边长</param>
        /// <returns>图片</returns>
        public static Bitmap GenByZXingNet(string msg, int codeSizeInPixels = 250)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框1            ZXing.Common.BitMatrix bm = writer.Encode(msg);

            return writer.Write(msg);
        }

        #endregion

        #region 保存图片到指定路径
        private static bool SaveBmp(string path, Bitmap bitmap)
        {
            try
            {
                bitmap.Save($@"{path}.bmp");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + path);
                return false;
                throw;
            }
        }
        #endregion
    }
}
