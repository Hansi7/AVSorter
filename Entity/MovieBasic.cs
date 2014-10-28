using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVSORTER
{
    public class MovieBasic
    {
        public string Title { get; set; }
        public string ItemURL { get; set; }
        public string Img_s { get; set; }
        public string Img_s_file { get; set; }
        public List<string> Actor { get; set; }
        public string Label { get; set; }
        public string Maker { get; set; }
        public override string ToString()
        {
            return string.Format("Title:{0}\r\nActor:{1}\r\nURL:{2}\r\nLabel:{3}\r\nMaker:{4}\r\nImg_s:{5}", Title, Actor, ItemURL, Label, Maker,Img_s);
        }
    }
    
}
