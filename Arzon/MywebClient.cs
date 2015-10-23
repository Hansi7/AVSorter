using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Gets
{

    public class MyWebClient : WebClient
    {
        public CookieContainer m_container = new CookieContainer();

        string refrer = string.Empty;
        public string ReferURL
        {
            get
            {

                return this.refrer;
            }
            set
            {
                this.refrer = value;
            }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            if (webRequest is HttpWebRequest)
            {
                (webRequest as HttpWebRequest).CookieContainer = this.m_container;
                if (ReferURL != string.Empty)
                {
                    (webRequest as HttpWebRequest).Referer = ReferURL;
                }
                (webRequest as HttpWebRequest).ContentType = "application/x-www-form-urlencoded";
                (webRequest as HttpWebRequest).ContentType = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
                (webRequest as HttpWebRequest).UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            }
            return webRequest;
        }

        public string GetHTML(Uri uri)
        {
            try
            {
                string kk = Encoding.UTF8.GetString(this.DownloadData(uri));
                return kk;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}