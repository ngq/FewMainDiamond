/*********************************************************************************** 
*        Cteate by :   Lfch
*        Date      :2016/9/13 17:23:42 
*        Desc      :文件处理方法
************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FewMain.Common
{
    public static class FileHelper
    {
        /// <summary>
        /// 使用OutputStream.Write分块提供下载文件，参数为文件绝对路径
        /// </summary>
        /// <param name="filePath"></param>
        public static void DownLoadFile(string filePath)
        {
            //指定块大小
            long chunkSize = 204800;//1024*2*100 200kb
            //建立一个200K的缓冲区
            byte[] buffer = new byte[chunkSize];
            //已读的字节数
            long dataToRead = 0;
            FileStream stream = null;
            try
            {
                //打开文件
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                dataToRead = stream.Length;
                //添加Http头
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                string _fileName = HttpUtility.UrlEncode(Path.GetFileName(filePath), Encoding.UTF8);
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + _fileName);
                System.Web.HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());
                while (dataToRead > 0)
                {
                    if (System.Web.HttpContext.Current.Response.IsClientConnected)
                    {
                        int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));//返回实际的流大小
                        System.Web.HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        try
                        {
                            System.Web.HttpContext.Current.Response.Flush();
                        }
                        catch
                        {
                            //防止client失去连接
                            dataToRead = -1;
                        }
                        buffer = new Byte[chunkSize];
                        dataToRead = dataToRead - length;//减去实际传送的长度
                    }
                    else
                    {
                        //防止client失去连接
                        dataToRead = -1;
                    }
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                System.Web.HttpContext.Current.Response.Close();
            }
        }

        /// <summary>
        /// 将文件保存到目录
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="savePath">存储路径:默认已加上网站根目录,upload/images</param>
        public static string saveUploadFile(HttpPostedFileBase file, string savePath)
        {
            return saveUploadFile(file, savePath, "", 0);
        }
        /// <summary>
        /// 将文件保存到目录
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="savePath">存储路径:默认已加上网站根目录,upload/images</param>
        ///<param name="FileName">文件名:img.jpg</param>
        public static string saveUploadFile(HttpPostedFileBase file, string savePath, string FileName)
        {
            return saveUploadFile(file, savePath, FileName, 0);
        }

        /// <summary>
        /// 将文件保存到目录
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="savePath">存储路径:默认已加上网站根目录,upload/images</param>
        /// <param name="fileSize">文件大小（单位是kb，等于0是不检测）</param>
        /// <returns></returns>
        public static string saveUploadFile(HttpPostedFileBase file, string savePath, int fileSize)
        {
            return saveUploadFile(file, savePath, "", fileSize);
        }

        /// <summary>
        /// 将文件保存到指定目录
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="savePath">保存地址</param>
        /// <param name="FileName"></param>
        /// <param name="fileSize">文件大小（单位是kb，等于0是不检测）</param>
        /// <returns></returns>
        public static string saveUploadFile(HttpPostedFileBase file, string savePath, string FileName, int fileSize)
        {
            string filePath = savePath;
            bool _b = true;
            if (fileSize != 0)
            {
                if (file.ContentLength <= fileSize * 1024)
                {
                    _b = true;
                }
                else
                {
                    _b = false;
                }
            }
            if (_b)
            {
                //var avatarName = file.FileName;
                //var avatarExt = Path.GetExtension(avatarName);
                //if (!String.IsNullOrEmpty(avatarExt)
                //                        && (string.IsNullOrEmpty(Extensions) ? true : Extensions.Contains(avatarExt)))
                //{
                try
                {
                    if (FileName.IsNullOrEmpty())
                        FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(file.FileName);
                    
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                  
                    file.SaveAs(filePath + FileName);
                    //LogHelper.Info("上传图片记录03");
                    return "/" + savePath + FileName;
                }
                catch (Exception ex)
                {
                    //LogHelper.Error(ex, "上传图片出错");
                    return "";
                }

                //}
                //else
                //{
                //    return false;
                //}
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 将文件保存到目录(根目录为网站的根目录)
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="savePath">保存地址</param>
        /// <param name="FileName"></param>
        /// <param name="fileSize">文件大小（单位是kb，等于0是不检测）</param>
        /// <returns></returns>
        public static string saveUploadFileInBaseDirectory(HttpPostedFileBase file, string savePath, string FileName, int fileSize)
        {
            string filePath = "";//GloablVars.WebSizeDirectory + savePath + "/";
            bool _b = true;
            if (fileSize != 0)
            {
                if (file.ContentLength <= fileSize * 1024)
                {
                    _b = true;
                }
                else
                {
                    _b = false;
                }
            }
            if (_b)
            {
                //var avatarName = file.FileName;
                //var avatarExt = Path.GetExtension(avatarName);
                //if (!String.IsNullOrEmpty(avatarExt)
                //                        && (string.IsNullOrEmpty(Extensions) ? true : Extensions.Contains(avatarExt)))
                //{
                try
                {
                    if (FileName.IsNullOrEmpty())
                        FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(file.FileName);
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    file.SaveAs(filePath + FileName);
                    return "/" + savePath + FileName;
                }
                catch (Exception ex)
                {
                    //LogHelper.Error(ex, "上传图片出错");
                    return "";
                }

                //}
                //else
                //{
                //    return false;
                //}
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static bool DeleteFile(string Path)
        {
            try
            {
                File.Delete(Path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
