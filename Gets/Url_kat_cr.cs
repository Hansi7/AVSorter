using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gets
{
    public class Url_kat_cr
    {
        public Url_kat_cr()
        { 
            
        }
        HttpHelper helper = new HttpHelper();


        public string gogogo(string keyword)
        {
            var html =  helper.GetHtml("http://kat.cr/usearch/" + keyword);

            return html;
        }

    }
}
