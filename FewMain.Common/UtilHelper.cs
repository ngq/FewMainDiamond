using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RapnetDataExport
{
    public class UtilHelper
    {
        static CookieContainer myCookie = new CookieContainer();
        #region ------HTTP POST方式请求数据
        /// <summary>
        /// HTTP POST方式请求数据
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="param">POST的数据</param>
        /// <returns></returns>
        public static string HttpPost(string url, string param)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                //设置关联的Cookie
                request.CookieContainer = myCookie;

                StreamWriter requestStream = null;
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    requestStream = new StreamWriter(request.GetRequestStream());
                    requestStream.Write(param);
                    requestStream.Close();

                    response = request.GetResponse();
                    if (response != null)
                    {

                        HttpWebResponse myHttpWebResponse = (HttpWebResponse)response;

                        //新建一个HttpWebResponse
                        myHttpWebResponse.Cookies = myCookie.GetCookies(request.RequestUri);
                        //myCookie = request.CookieContainer;

                        request.CookieContainer = myCookie;//*

                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                finally
                {
                    request = null;
                    requestStream = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                File.WriteAllText("../log/logError.txt", "Get" + DateTime.Now + "------" + e.Message + " \r\n");
                throw new Exception();
                return "";
            }
        }
        #endregion

        #region ------HTTP GET方式请求数据
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                    File.WriteAllText("../log/logError.txt", "Get" + DateTime.Now + "------" + ex.Message + " \r\n");
                    throw new Exception();
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet2(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string HttpGet3(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet4(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet5(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet6(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet7(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet8(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet9(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string HttpGet10(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/xmld";


                //request.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
                request.Headers["Accept-Language"] = "Mozillazh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3";

                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";  //Accept-Language	
                request.Accept = "*/*";
                request.Timeout = 600000;
                request.AllowAutoRedirect = false;

                request.CookieContainer = myCookie;//*
                WebResponse response = null;
                string responseStr = null;

                try
                {
                    response = request.GetResponse();


                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                finally
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        responseStr = reader.ReadToEnd();
                        reader.Close();

                    }
                    request = null;
                    response = null;
                }

                return responseStr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region ------HTTP GET方式请求数据输出字节
        /// <summary>
        /// HTTP GET方式请求数据.输出字节
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns>输出字节</returns>
        public static Byte[] HttpGet_Byte(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            //WebResponse response = null;
            HttpWebResponse response = null;
            //string responseStr = null;
            byte[] buffer = new byte[1024];
            byte[] buffer1 = new byte[756];
            MemoryStream ms = new MemoryStream();
            if (request != null)
            {
                try
                {
                    response = request.GetResponse() as HttpWebResponse;

                    if (response != null)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream stream = response.GetResponseStream();

                            //long len = response.ContentLength;
                            //long counter = 1024;
                            //long modd = len % counter;

                            //while (len / counter > 1)
                            //{
                            //    len -= counter;
                            //    ms.Write(buffer,0,buffer.Length);
                            //}

                            //stream.Read(buffer,0,(int)modd);
                            //ms.Write(buffer, 0, (int)modd);

                            //while (stream.Read(buffer, 0, buffer.Length) > 0)
                            //{
                            //    ms.Write(buffer, 0, buffer.Length);
                            //}
                        }
                        //  ms.Close();
                        //  stream.Close();

                        //  int length = (int)response.ContentLength;
                        //BinaryReader br = new BinaryReader(stream);
                        //FileStream fs = File.Create("D://test/123.jpg");

                        //fs.Write(br.ReadBytes(length), 0, length);
                        //br.Close();
                        //fs.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    response.Close();
                }
            }
            Byte[] bb = ms.ToArray();
            int l = bb.Length;

            return bb;
        }
        #endregion
    }
}
