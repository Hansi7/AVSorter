using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AVSORTER
{
    public class Tools
    {
        public static string Fcode(string code)
        {
            Regex r1 = new Regex(@"(\d{0,1}[a-zA-Z]{2,5})[- _]{0,1}(\d{2,4})");

            if (r1.Match(code).Value=="")
	        {
                return code;
	        } 
            var c = r1.Match(code).Groups[1].Value;
            var n = r1.Match(code).Groups[2].Value;
            
            return (c + "-" + n).ToUpper();
        }

        public static string ListToString(IEnumerable<string> list)
        {
            if (list.Count()==0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (string item in list)
            {
                sb.Append(item);
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static string RemoveInvalidChars(string Title)
        {
            var ichr = Path.GetInvalidPathChars();
            foreach (var item in ichr)
            {
                Title = Title.Replace(item, '_');
            }
            ichr = Path.GetInvalidFileNameChars();
            foreach (var item in ichr)
            {
                Title = Title.Replace(item, '_');
            }
            return Title;
        }

    }
}
