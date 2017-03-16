/*********************************************************************************** 
*        Cteate by : lfch   
*        Date      : 2016/11/14 14:16:39 
*        Desc      : 压缩图片
*-----------------------------------------------------------------------------------
*       Changed    : 
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FewMain.Common
{
    public class ImageHelper
    {
        #region ------上传产品图片
        /// <summary>
        /// 上传产品图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static SaveImageModel UploadProductImg(HttpPostedFileBase file)
        {
            SaveImageModel model = new SaveImageModel();
            if (file != null)
            {
                string folder = "";
                string extenName = Path.GetExtension(file.FileName).ToLower();
                string fileName = Guid.NewGuid() + extenName; //DateTime.Now.ToDateTimeStr("yyyyMMddHHmmssfff") + extenName;
                string niangyue = DateTime.Now.ToDateTimeStr("yyyyMMdd") + "/";
                string pro = "";//@"\" + GloablVars.ProImg + @"\";
                string proimgDire ="";//GloablVars.ImageServer + pro;
                string saveFileName = "";

                #region 保存原图 
                folder = proimgDire + @"o\" + niangyue;  //大图
                saveFileName = pro + niangyue + fileName;

                string newfilename = FileHelper.saveUploadFile(file, folder, fileName);
                saveFileName = saveFileName.Replace(@"\\", "/").Replace(@"\", "/");
                model.OImg = saveFileName.TrimStart('/'); ;
                #endregion

                #region 生成压缩图 大图
                string b_folder = proimgDire + @"b\" + niangyue;  //小图
                string b_saveFileName = pro + @"b\" + niangyue + fileName;
                if (!Directory.Exists(b_folder))
                {
                    Directory.CreateDirectory(b_folder);
                }
                MemoryStream bimg = GetReducedImage(1001, 1001, file.InputStream);

                System.Drawing.Image bnewImg = System.Drawing.Image.FromStream(bimg);
                bnewImg.Save(b_folder + fileName);
                bnewImg.Dispose();
                b_saveFileName = b_saveFileName.Replace(@"\\", "/").Replace(@"\", "/");
                model.BImg = b_saveFileName.TrimStart('/');
                #endregion

                #region 生成压缩图 小图
                string s_folder = proimgDire + @"s\" + niangyue;  //小图
                string s_saveFileName = pro + @"s\" + niangyue + fileName;
                if (!Directory.Exists(s_folder))
                {
                    Directory.CreateDirectory(s_folder);
                }
                MemoryStream img = GetReducedImage(350, 350, file.InputStream);

                System.Drawing.Image newImg = System.Drawing.Image.FromStream(img);
                newImg.Save(s_folder + fileName);
                newImg.Dispose();
                s_saveFileName = s_saveFileName.Replace(@"\\", "/").Replace(@"\", "/");
                model.SImg = s_saveFileName.TrimStart('/');
                #endregion
            }

            return model;
        }

        /// <summary>
        /// 上传产品详情图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string UploadProductImgDetail(HttpPostedFileBase file)
        {
            string saveFileName = "";
            if (file != null)
            {
                string folder = "";
                string extenName = Path.GetExtension(file.FileName).ToLower();
                string fileName = Guid.NewGuid() + extenName; //DateTime.Now.ToDateTimeStr("yyyyMMddHHmmssfff") + extenName;
                string niangyue = DateTime.Now.ToDateTimeStr("yyyyMMdd") + "/";
                string info = "";//@"\" + GloablVars.ProInfoImg + @"\"; ;
                string proimgDire ="";//GloablVars.ImageServer + info;

                folder = proimgDire + niangyue;
                saveFileName = info + niangyue + fileName;

                string newfilename = FileHelper.saveUploadFile(file, folder, fileName);
                saveFileName = saveFileName.Replace(@"\\", "/").Replace(@"\", "/").TrimStart('/');
                return saveFileName;
            }

            return saveFileName;
        }
        #endregion

        #region ------压缩图片
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="Width">缩略图的宽度</param>
        /// <param name="Height">缩略图的高度</param>
        /// <param name="imagest">图片流对象</param>
        /// <param name="qualityValue">压缩比例</param>
        /// <returns></returns>
        public static MemoryStream GetReducedImage(int Width, int Height, Stream imagest, long qualityValue = 90L)
        {
            using (var temp = new Bitmap(Width, Height))
            {
                using (var img = Image.FromStream(imagest))
                {
                    using (var g = Graphics.FromImage(temp))
                    {
                        MemoryStream m = new MemoryStream();
                        g.DrawImage(img, new Rectangle() { Height = Height, Width = Width });
                        g.SmoothingMode = SmoothingMode.HighSpeed;
                        EncoderParameter p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityValue);
                        EncoderParameters ps = new EncoderParameters(1);
                        ps.Param[0] = p;
                        ImageCodecInfo ii = GetCodecInfo("image/jpeg");
                        temp.Save(m, ii, ps);
                        return m;
                    }
                }
            }
        }

        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }
        #endregion
    }

    public class SaveImageModel
    {
        /// <summary>
        /// 原图
        /// </summary>
        public string OImg { get; set; }

        /// <summary>
        /// 大图 1001*1001
        /// </summary>
        public string BImg { get; set; }

        /// <summary>
        /// 小图 350*350
        /// </summary>
        public string SImg { get; set; }
    }
}
