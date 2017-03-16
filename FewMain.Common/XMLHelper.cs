/*********************************************************************************** 
*        Cteate by : lfch   
*        Date      : 2016/9/28 17:17:15 
*        Desc      : xlm帮助类
*-----------------------------------------------------------------------------------
*       Changed    : 
************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FewMain.Common
{
    /// <summary>
    /// xml帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 创建xml文档
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static bool CreateXML<T>(T obj, string path, Encoding encoding = null)
        {
            bool result = false;

            var xmlSerializer = new XmlSerializer(typeof(T));
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                if (encoding == null)
                    encoding = Encoding.UTF8;
                using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings
                {
                    Indent = true,
                    NewLineChars = "\r\n",
                    Encoding = encoding,
                    IndentChars = "    "
                }))
                {
                    xmlSerializer.Serialize(xmlWriter, obj);
                    xmlWriter.Close();
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取对应路劲的xml信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T GetXMLToObject<T>(string path, Encoding encoding = null)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            string s = File.ReadAllText(path);
            T result;
            if (encoding == null)
                encoding = Encoding.UTF8;
            using (var mStream = new MemoryStream(encoding.GetBytes(s)))
            {

                using (var streamReader = new StreamReader(mStream, encoding))
                {
                    result = (T)xmlSerializer.Deserialize(streamReader);
                }
            }
            return result;
        }
    }
}
