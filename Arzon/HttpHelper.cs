using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace Gets
{
    public class HttpHelper
    {
        #region 私有变量
        private CookieContainer cc;
        private string contentType = "application/x-www-form-urlencoded";
        private string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
        private Encoding encoding = Encoding.GetEncoding("utf-8");
        private int delay = 3000;
        private int maxTry = 3;
        private int currentTry = 0;
        #endregion

        #region 属性
        /// <summary>
        /// Cookie容器
        /// </summary>
        public CookieContainer CookieContainer
        {
            get
            {
                return cc;
            }
        }

        /// <summary>
        /// 获取网页源码时使用的编码
        /// </summary>
        /// <value></value>
        public Encoding Encoding
        {
            get
            {
                return encoding;
            }
            set
            {
                encoding = value;
            }
        }

        public int NetworkDelay
        {
            get
            {
                return delay;
            }
            set
            {
                delay = value;
            }
        }

        public int MaxTry
        {
            get
            {
                return maxTry;
            }
            set
            {
                maxTry = value;
            }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        public HttpHelper()
        {
            cc = new CookieContainer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="cc">The cc.</param>
        public HttpHelper(CookieContainer cc)
        {
            this.cc = cc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="userAgent">The user agent.</param>
        public HttpHelper(string contentType, string accept, string userAgent)
        {
            this.contentType = contentType;
            this.accept = accept;
            this.userAgent = userAgent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="cc">The cc.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="userAgent">The user agent.</param>
        public HttpHelper(CookieContainer cc, string contentType, string accept, string userAgent)
        {
            this.cc = cc;
            this.contentType = contentType;
            this.accept = accept;
            this.userAgent = userAgent;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <param name="cookieCollection">Cookie集合</param>
        /// <returns></returns>
        public string GetHtml(string url, string postData, bool isPost, CookieContainer cookieContainer)
        {
            if (string.IsNullOrEmpty(postData))
            {
                return GetHtml(url, cookieContainer);
            }

            Thread.Sleep(delay);

            currentTry++;

            try
            {
                byte[] byteRequest = Encoding.Default.GetBytes(postData);

                HttpWebRequest httpWebRequest;
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = isPost ? "POST" : "GET";
                httpWebRequest.ContentLength = byteRequest.Length;

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(byteRequest, 0, byteRequest.Length);
                stream.Close();

                HttpWebResponse httpWebResponse;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                currentTry = 0;
                return html;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, postData, isPost, cookieContainer);
                }

                currentTry = 0;
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieCollection">Cookie集合</param>
        /// <returns></returns>
        public string GetHtml(string url, CookieContainer cookieContainer)
        {
            Thread.Sleep(delay);

            currentTry++;

            try
            {
                HttpWebRequest httpWebRequest;
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                HttpWebResponse httpWebResponse;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                currentTry = 0;
                return html;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry = 0;
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <returns></returns>
        public string GetHtml(string url)
        {
            return GetHtml(url, cc);
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <returns></returns>
        public string GetHtml(string url, string postData, bool isPost)
        {
            return GetHtml(url, postData, isPost, cc);
        }

        /// <summary>
        /// 获取指定页面的Stream
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <param name="cookieCollection">Cookie集合</param>
        /// <returns></returns>
        public Stream GetStream(string url, CookieContainer cookieContainer)
        {
            Thread.Sleep(delay);

            currentTry++;

            try
            {
                HttpWebRequest httpWebRequest;
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                HttpWebResponse httpWebResponse;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                currentTry = 0;
                return responseStream;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry = 0;
                return null;
            }
        }

        #endregion
    }

}