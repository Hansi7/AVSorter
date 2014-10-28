using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVSORTER
{
    public class Movie
    {
        /// <summary>
        /// 演员
        /// </summary>
        public List<string> Actor { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title 
        { 
            get
            {
                return this._title;
            }
            set
            {
                if (value.Length>200)
                {
                    this._title = value.Substring(0, 200);
                }
                else
                {
                    this._title = value;
                }
            }
        }
        string _title;
        /// <summary>
        /// 封面
        /// </summary>
        public string CoverURL { get; set; }
        /// <summary>
        /// 封面图片文件 
        /// </summary>
        public string CoverFile { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Maker { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Lable { get; set; }
        /// <summary>
        /// 系列
        /// </summary>
        public string Series { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 片长度
        /// </summary>
        public string Minutes { get; set; }
        /// <summary>
        /// 番号
        /// </summary>
        public string AVCode { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; set; }
        public string ItemURL { get; set; }
        
        public bool Censored { get; set; }
        public string VidesFile { get; set; }

//        public override string ToString()
//        {
//            return string.Format(@"Actor:{0}
//Title:{1}
//CoverURL:{2}
//CoverFile:{3}
//Maker:{4}
//Label:{5}
//Series:{6}
//Producer:{7}
//ReleaseDate:{8}
//Minutes:{9}
//Introduction:{10}
//ItemURL:{11}
//CODE:{12}", Tools.ListToString(Actor), Title, CoverURL, CoverFile, Maker, Lable,Series,Producer, ReleaseDate.ToShortDateString(), Minutes, Introduction, ItemURL,AVCode);
            
            


//        }


        public override string ToString()
        {
            return this.AVCode +"\t"+ this.Title;
        }
    }
}
