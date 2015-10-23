using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AVSORTER;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            //NewMethod1();

            Gets.HttpHelper help = new Gets.HttpHelper();
            
            
            Console.ReadKey();
        }

        private static void NewMethod1()
        {
            Gets.AVEntertainments ave = new Gets.AVEntertainments();
            var ms = ave.Query("CWP-50");
            //http://www.aventertainments.com/search_Products.aspx?languageID=1&dept_id=29&keyword=cwp-50&searchby=keyword
            Console.WriteLine(ms[0].ToString());
            var mm = ave.GetMovie(ms[0]);
            Console.WriteLine(mm.ToString());
            string ss = ave.GetScreen_shotURL(mm);
            System.Diagnostics.Process.Start(ss);

            Gets.HttpHelper help = new Gets.HttpHelper();
            var s = help.GetStream(ss, help.CookieContainer);
            System.IO.FileStream fs = new System.IO.FileStream("a.jpg", System.IO.FileMode.CreateNew);

            System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile(ss, mm.AVCode + ".jpg");
        }

        private static void NewMethod()
        {
            Gets.HttpHelper help = new Gets.HttpHelper();
            var html = help.GetHtml("http://www.arzon.jp/index.php?action=adult_customer_agecheck&agecheck=1");




            
            Console.WriteLine("OK");


            html = help.GetHtml("http://www.arzon.jp/itemlist.html?t=&m=all&s=&q=ipz");


            //var html = help.GetHtml("http://www.arzon.jp/item_1290945.html");
            System.IO.File.WriteAllText("result.txt", html);
            System.Diagnostics.Process.Start("result.txt");
            Console.ReadKey();
        }
    }
}
