using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Gets.Url_kat_cr cr = new Gets.Url_kat_cr();
            
            Console.WriteLine(cr.gogogo("art"));


            Gets.MyWebClient wc = new Gets.MyWebClient();
            var ddddd = wc.GetHTML(new Uri("http://kat.cr/usearch/art"));

            Console.WriteLine(ddddd);
        }
    }
}
