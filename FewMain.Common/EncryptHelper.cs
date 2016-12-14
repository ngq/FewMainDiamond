using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Common
{
    /// <summary>
    /// 字符加密处理
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 加密密钥,切记一定不可手动修改这个值
        /// </summary>
        const string key = "FewMain";

        #region MD5加密
        /// <summary>
        /// 获取MD5加密过后的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetMD5(string value)
        {
            //MD5加密
            using (var md5 = MD5.Create())
            {
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                var sb = new StringBuilder();
                foreach (byte b in bs)
                {
                    sb.Append(b.ToString("x2"));
                }
                //所有字符转为大写
                return sb.ToString().ToUpper();
            }
        }
        #endregion

        #region 加密解密
        /// <summary>
        /// 对字符进行加密处理(可解密)
        /// </summary>
        /// <param name="Value">原密码</param>
        /// <returns>返回加密字符</returns>
        public static string Encryption(string Value)
        {
            try
            {
                string pass = Encrypt.EncryptUsingRijndael(Value, key); //SHVENILOOOCT 切记修改
                return pass;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// 对字符进行解密处理
        /// </summary>
        /// <param name="Value">加密字符</param>
        /// <returns>返回密码</returns>
        public static string Decrypt(string Value)
        {
            try
            {
                string pass = Encrypt.DecryptUsingRijndael(Value, key); //SHVENILOOOCT 切记修改
                return pass;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        #endregion 加密解密
    }


    #region   加密解密机制
    class Encrypt
    {
        /// <summary>
        /// 对字符进行解密处理
        /// </summary>
        /// <param name="StringToBeDecrypted"></param>
        /// <param name="KeyString"></param>
        /// <returns></returns>
        public static string DecryptUsingRijndael(string StringToBeDecrypted, string KeyString)
        {
            byte[] buffer = new byte[] { 0x38, 0x4a, 90, 0x24, 0xf8, 0x63, 0x12, 0x90, 170, 0xa3, 0x91, 0x57, 0x36, 0x3d, 0x22, 0xff };
            KeyString = KeyString.PadRight(0x10);
            if (KeyString.Length > 0x10)
            {
                KeyString = KeyString.Remove(15, KeyString.Length - 0x10);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(KeyString);
            RijndaelManaged managed = new RijndaelManaged
            {
                Key = bytes,
                IV = buffer
            };
            byte[] inputBuffer = Convert.FromBase64String(StringToBeDecrypted);
            return Encoding.UTF8.GetString(managed.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }
        /// <summary>
        /// 对字符进行加密处理
        /// </summary>
        /// <param name="StringToBeEncrypted"></param>
        /// <param name="KeyString"></param>
        /// <returns></returns>
        public static string EncryptUsingRijndael(string StringToBeEncrypted, string KeyString)
        {
            byte[] buffer = new byte[] { 0x38, 0x4a, 90, 0x24, 0xf8, 0x63, 0x12, 0x90, 170, 0xa3, 0x91, 0x57, 0x36, 0x3d, 0x22, 0xff };
            KeyString = KeyString.PadRight(0x10);
            if (KeyString.Length > 0x10)
            {
                KeyString = KeyString.Remove(15, KeyString.Length - 0x10);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(KeyString);
            RijndaelManaged managed = new RijndaelManaged
            {
                Key = bytes,
                IV = buffer
            };
            byte[] inputBuffer = Encoding.UTF8.GetBytes(StringToBeEncrypted);
            return Convert.ToBase64String(managed.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }
    }
    #endregion
}
