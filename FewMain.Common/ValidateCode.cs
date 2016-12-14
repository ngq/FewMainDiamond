using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Common
{
    public class ValidateCode
    {
        /// <summary>
        /// 生成验证码。
        /// </summary>
        /// <param name="code">验证码值。</param>
        /// <param name="codeLength">指定长度的验证码。</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns></returns>
        public static byte[] CreateValidateGraphic(out string code, int codeLength, int width, int height, int fontSize)
        {
            String sCode = String.Empty;
            //顏色列表，用於驗證碼、噪線、噪點
            Color[] oColors ={
             Color.Black,
             Color.Red,
             Color.Blue,
             Color.Green,
             Color.Orange,
             Color.Brown,
             Color.Brown,
             Color.DarkBlue
            };
            //字體列表，用於驗證碼
            string[] oFontNames = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            //驗證碼的字元集，去掉了一些容易混淆的字元
            char[] oCharacter = {
       '2','3','4','5','6','8','9',
       'A','B','C','D','E','F','G','H','J','K', 'L','M','N','P','R','S','T','W','X','Y'
      };
            Random oRnd = new Random();
            Bitmap oBmp = null;
            Graphics oGraphics = null;
            int N1 = 0;
            System.Drawing.Point oPoint1 = default(System.Drawing.Point);
            System.Drawing.Point oPoint2 = default(System.Drawing.Point);
            string sFontName = null;
            Font oFont = null;
            Color oColor = default(Color);

            //生成驗證碼字串
            for (N1 = 0; N1 <= codeLength - 1; N1++)
            {
                sCode += oCharacter[oRnd.Next(oCharacter.Length)];
            }

            oBmp = new Bitmap(width, height);
            oGraphics = Graphics.FromImage(oBmp);
            oGraphics.Clear(Color.White);
            try
            {
                for (N1 = 0; N1 <= 4; N1++)
                {
                    //畫噪線
                    oPoint1.X = oRnd.Next(width);
                    oPoint1.Y = oRnd.Next(height);
                    oPoint2.X = oRnd.Next(width);
                    oPoint2.Y = oRnd.Next(height);
                    oColor = oColors[oRnd.Next(oColors.Length)];
                    oGraphics.DrawLine(new Pen(oColor), oPoint1, oPoint2);
                }

                float spaceWith = 0, dotX = 0, dotY = 0;
                if (codeLength != 0)
                {
                    spaceWith = (width - fontSize * codeLength - 10) / codeLength;
                }

                for (N1 = 0; N1 <= sCode.Length - 1; N1++)
                {
                    //畫驗證碼字串
                    sFontName = oFontNames[oRnd.Next(oFontNames.Length)];
                    oFont = new Font(sFontName, fontSize, FontStyle.Italic);
                    oColor = oColors[oRnd.Next(oColors.Length)];

                    dotY = (height - oFont.Height) / 2 + 2;//中心下移2像素
                    dotX = Convert.ToSingle(N1) * fontSize + (N1 + 1) * spaceWith;

                    oGraphics.DrawString(sCode[N1].ToString(), oFont, new SolidBrush(oColor), dotX, dotY);
                }

                for (int i = 0; i <= 30; i++)
                {
                    //畫噪點
                    int x = oRnd.Next(oBmp.Width);
                    int y = oRnd.Next(oBmp.Height);
                    Color clr = oColors[oRnd.Next(oColors.Length)];
                    oBmp.SetPixel(x, y, clr);
                }

                code = sCode;
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                oBmp.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                oGraphics.Dispose();
            }
        }
        /// <summary>
        /// 生成6位数验证码
        /// </summary>
        /// <param name="code">返回生成的验证码数字</param>
        /// <returns>验证码图片</returns>
        public static byte[] CreateValidateGraphic(out string code)
        {
            return CreateValidateGraphic(out code,4,100,40,20);
        }
    }
}
