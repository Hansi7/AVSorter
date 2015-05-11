using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVSORTER;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gets
{
    public class Arzon : AVSORTER.IGetable, ICloneable
    {
        Uri uri;
        MyWebClient wc;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IsInit">决定是否初始化Cookie,初始化Cookie需要耗费时间并且需要联网，或者根据需要手动调用CookiesInit()方法</param>
        public Arzon(bool IsInit)
        {
            wc = new MyWebClient();
            if (IsInit)
            {
                CookiesInit();
            }
        }

        public void CookiesInit()
        {
            const string url = @"http://www.arzon.jp/index.php?action=adult_customer_agecheck&agecheck=1";//&redirect=http%3A%2F%2Fwww.arzon.jp%2F";
            uri = new Uri(url);
            wc.DownloadDataCompleted += wc_DownloadDataCompleted;
            wc.DownloadDataAsync(uri, "init");
        }

        public event EventHandler InitCompleted;

        void wc_DownloadDataCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            if ((e.UserState as string) == "init")
            {
                this.IsInitCompleted = true;
                if (this.InitCompleted!=null)
                {
                    this.InitCompleted(this, new EventArgs());
                }

            }
        }

        public bool IsInitCompleted { get; set; }

        public List<MovieBasic> Query(string fcode)
        {
            Uri u = urlCombine(fcode);
            return PageParse(u);
        }

        public List<MovieBasic> PageParse(Uri u)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(wc.GetHTML(u));
            //doc.DocumentNode.SelectNodes("//li[@class='saledate']/span")[3].InnerText
            var listitems = doc.DocumentNode.SelectNodes("//div[@id='listitem']/table/tr/td/div[@class='data']/ul[1]/li[2]");

            var htmnode = doc.DocumentNode.SelectSingleNode("//div[@class='autopagerize_page_element']");
            if (htmnode == null)
            {
                //查无此片
                return new List<MovieBasic>();
            }
            string htm = htmnode.InnerHtml;
            List<MovieBasic> l = new List<MovieBasic>();
            //<div class="autopagerize_page_element">

            int cou = doc.DocumentNode.SelectNodes("//div[@id='itemd']").Count;

            for (int i = 0; i < cou; i++)
            {

                string n_title = doc.DocumentNode.SelectNodes("//div[@id='itemd']")[i].ChildNodes["ul"].ChildNodes["li"].ChildNodes["h3"].InnerText;
                n_title = Tools.RemoveInvalidChars(n_title);

                string n_itemURL = "http://" + u.Host + doc.DocumentNode.SelectNodes("//div[@id='itemd']")[i].ChildNodes["ul"].ChildNodes["li"].ChildNodes["h3"].ChildNodes["a"].Attributes["href"].Value;

                string n_date = doc.DocumentNode.SelectSingleNode("//div[@id='itemd']/ul/li/span[@class='date']").InnerText;

                var datanode = doc.DocumentNode.SelectNodes("//div[@class='data']")[i];
                HtmlDocument docData = new HtmlDocument();
                docData.LoadHtml(datanode.InnerHtml);
                int k = docData.DocumentNode.SelectNodes("//ul[1]/li").Count;
                string n_actor = string.Empty;
                List<string> actors = new List<string>();
                if (k > 1)
                {
                    for (int j = k; j > 1; j--)
                    {
                        n_actor = docData.DocumentNode.SelectNodes("//ul[1]/li[" + j + "]")[0].InnerText.Trim();
                        actors.Add(n_actor);
                    }
                }

                string n_maker = docData.DocumentNode.SelectSingleNode("//ul[2]/li[2]").InnerText.Trim();
                string n_company = docData.DocumentNode.SelectSingleNode("//ul[3]/li[2]").InnerText.Trim();
                var n_ticai_node = docData.DocumentNode.SelectSingleNode("//ul[4]/li[2]");
                string n_ticai;
                if (n_ticai_node == null)
                {
                    n_ticai = string.Empty;
                }
                else
                {
                    n_ticai = n_ticai_node.InnerText.Trim();
                }
                string s_img = doc.DocumentNode.SelectNodes("//div[@id='listitem']/table/tr/td/div/a/img")[i].Attributes["src"].Value;

                MovieBasic mb = new MovieBasic()
                {
                    Title = n_title,
                    ItemURL = n_itemURL,
                    Img_s = s_img,
                    Actor = actors,
                    Maker = n_company,
                    Label = n_ticai
                };
                l.Add(mb);
            }
            return l;
        }

        /// <summary>
        /// this is the old version.
        /// </summary>
        /// <param name="basic"></param>
        /// <returns></returns>
        //public Movie GetMovie(MovieBasic basic)
        //{
        //    try
        //    {
        //        string html = wc.GetHTML(new Uri(basic.ItemURL));
        //        var docc = new HtmlDocument();
        //        docc.LoadHtml(html);
        //        //web DOM Changed 2014/12/7
        //        string Title = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/div[@class='detail_title']/h1").InnerText.Trim();
        //        //string Title = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/div[@class='detail_title_new']/h1").InnerHtml;
                
                
        //        Title = Tools.RemoveInvalidChars(Title);

        //        while (Title.IndexOf("&nbsp;") != -1)
        //        {
        //          Title=  Title.Replace("&nbsp;", "");
        //        }
        //        while (Title.IndexOf("廃盤") != -1)
        //        {
        //            Title = Title.Replace("廃盤", "");
        //        }
        //        //var ddd ="[MIDD-983]Ｂａｂｙ　Ｅｎｔｅｒｔａｉｎｍｅｎｔ×ＭＯＯＤＹＺコラボ作品　淫神の女泥棒　哀しき痙攣の追憶　Ｄｅａｒ．Ｆ　１　恥辱的、屈辱的なイカせの拷問！　反反复复反反复复方法";
        //        if (Title.Length>82)
        //        {
        //            Title = Title.Substring(0, 81);
        //        }



        //        //string Title = basic.Title;
        //        string label = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[3]/td/a").InnerText.Trim();
        //        string changjia = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[2]/td/a").InnerText.Trim();
        //        string jiandu = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[5]/td[2]").InnerText.Trim();
        //        string date = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[6]/td[2]").InnerText.Trim();
        //        //2008/01/25 (DVD レンタル版)
        //        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\d{4}/\d{2}/\d{2}");
        //        if (r.IsMatch(date))
        //        {
        //            date = r.Match(date).Value;
        //        }
        //        else
        //        {
        //            date = "1900/01/01";
        //        }
        //        DateTime dtime = DateTime.Parse(date);
                
                
        //        string minutes = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[7]/td[2]").InnerText.Trim();
        //        string f_code = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[8]/td[2]").InnerText.Trim();

        //        while (f_code.IndexOf("&nbsp;")!=-1)
        //        {
        //            f_code = f_code.Replace("&nbsp;", "");
        //        }
        //        while (f_code.IndexOf("廃盤")!=-1)
        //        {
        //            f_code = f_code.Replace("廃盤", "");
        //        }

        //        f_code = Tools.Fcode(f_code);
        //        string xilie = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/table/tr/td/table[@class='item_detail']/tr/td[@class='caption']/table[@class='item']/tr[4]/td[2]").InnerText.Trim();
        //        //f_code = Tools.Fcode(f_code);
        //        string intro = docc.DocumentNode.SelectSingleNode("//table[@class='item_detail']/tr/td[@class='text']").InnerText.Trim();
        //        string coverImg = docc.DocumentNode.SelectSingleNode("//table[@class='item_detail']/tr/td/div/a").Attributes["href"].Value.Trim();
        //        Movie m = new Movie()
        //        {
        //            Actor = basic.Actor,
        //            Title = Title,
        //            Lable = label,
        //            Maker = changjia,
        //            ReleaseDate = dtime,
        //            Minutes = minutes,
        //            AVCode = f_code,
        //            Introduction = intro,
        //            CoverURL = coverImg,
        //            ItemURL = basic.ItemURL,
        //            Series = xilie,
        //            Producer = jiandu
        //        };
        //        //Console.WriteLine(string.Format("Actor:{0}\r\nTitle:{1}\r\nLabel:{2}\r\nMaker:{3}\r\nReleaseDate:{4}\r\n番号:{5}\r\n ", m.Actor[0], m.Title, m.Lable, m.Maker, m.ReleaseDate.ToShortDateString(), m.AVCode));
        //        return m;
        //    }
        //    catch (Exception)
        //    {
        //        throw  new Exception("获取影片信息失败！");
        //    }
        //}

        public Movie GetMovie(MovieBasic basic)
        {
            try
            {
                string html = wc.GetHTML(new Uri(basic.ItemURL));
                var docc = new HtmlDocument();
                docc.LoadHtml(html);
                //web DOM Changed 2014/12/7
                string Title = docc.DocumentNode.SelectSingleNode("//div[@id='detail_new']/div[@class='detail_title_new']/h1").InnerText.Trim();
                string coverImg = docc.DocumentNode.SelectSingleNode("//*[@id='detail_new']//table//table//a").Attributes["href"].Value.ToString().Trim();


                //AV女優：
                var item1 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[1]/td[2]").InnerText.Trim();
                var actorsArr = item1.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                //AVメーカー    制造厂
                var item2 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[2]/td[2]").InnerText.Trim();
                //AVレーベル    唱片公司
                var item3 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[3]/td[2]").InnerText.Trim();
                //シリーズ      系列
                var item4 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[4]/td[2]").InnerText.Trim();
                //監督          导演
                var item5 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[5]/td[2]").InnerText.Trim();
                //発売日：
                var item6 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[6]/td[2]").InnerText.Trim();
                //収録時間
                var item7 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[7]/td[2]").InnerText.Trim();
                //品番
                var item8 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[8]/td[2]").InnerText.Trim();
                //タグ：       标签
                var item9 = docc.DocumentNode.SelectSingleNode("//table[@class='item']/tr[9]/td[2]").InnerText.Trim();
                //作品紹介
                string descrition;
                try
                {
                    descrition = docc.DocumentNode.SelectSingleNode("//div[@class='item_text']").InnerText.Trim();
                }
                catch (Exception)
                {

                    descrition = "";
                }
                



                Movie m = new Movie()
                {
                    Actor = actorsArr,
                    Title = titleCleaner(Title),
                    Lable = item9,
                    Maker = item2,//ideapocket
                    ReleaseDate = dateCleaner(item6),
                    Minutes = item7,
                    AVCode = f_codeCleaner(item8),
                    Introduction = descrition,
                    CoverURL = coverImg,
                    ItemURL = basic.ItemURL,
                    Series = item4,
                    //导演
                    Producer = item5
                };
                //Console.WriteLine(string.Format("Actor:{0}\r\nTitle:{1}\r\nLabel:{2}\r\nMaker:{3}\r\nReleaseDate:{4}\r\n番号:{5}\r\n ", m.Actor[0], m.Title, m.Lable, m.Maker, m.ReleaseDate.ToShortDateString(), m.AVCode));
                return m;
            }
            catch (Exception)
            {
                throw new Exception("获取影片信息失败！");
            }
        }
        //标题除杂
        private string titleCleaner(string title)
        {
            title = Tools.RemoveInvalidChars(title);

            while (title.IndexOf("&nbsp;") != -1)
            {
                title = title.Replace("&nbsp;", "");
            }
            while (title.IndexOf("廃盤") != -1)
            {
                title = title.Replace("廃盤", "");
            }
            //var ddd ="[MIDD-983]Ｂａｂｙ　Ｅｎｔｅｒｔａｉｎｍｅｎｔ×ＭＯＯＤＹＺコラボ作品　淫神の女泥棒　哀しき痙攣の追憶　Ｄｅａｒ．Ｆ　１　恥辱的、屈辱的なイカせの拷問！　反反复复反反复复方法";
            if (title.Length > 82)
            {
                title = title.Substring(0, 81);
            }
            return title;
        }
        //日期
        private DateTime dateCleaner(string date)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\d{4}/\d{2}/\d{2}");
            if (r.IsMatch(date))
            {
                date = r.Match(date).Value;
            }
            else
            {
                date = "1900/01/01";
            }
            return DateTime.Parse(date);
        }
        //番号
        private string f_codeCleaner(string f_code)
        {
            while (f_code.IndexOf("&nbsp;") != -1)
            {
                f_code = f_code.Replace("&nbsp;", "");
            }
            while (f_code.IndexOf("廃盤") != -1)
            {
                f_code = f_code.Replace("廃盤", "");
            }

            f_code = Tools.Fcode(f_code);
            return f_code;
        }

        public bool GetCover(Movie mo)
        {
            wc.ReferURL = mo.ItemURL;
            FileInfo f = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cover", mo.AVCode + ".jpg"));
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(f.FullName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(f.FullName));
                }
                if (!File.Exists(f.FullName))
                {
                    wc.DownloadFile(mo.CoverURL, f.FullName);
                }
                else
                {
                    Console.WriteLine("已有封面 " + mo.Title);
                }
            }
            catch (Exception err)
            {
                return false;
            }
            mo.CoverFile = f.FullName;
            return true;
        }

        Uri urlCombine(string fcode)
        {
            string ur = "http://www.arzon.jp/itemlist.html?t=&m=all&s=&mkt=all&disp=30&sort=-saledate&list=list&q=" + fcode;
            return new Uri(ur);
        }

        public object Clone()
        {
            //MemoryStream ms = new MemoryStream();

            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(ms, this);
            //ms.Seek(0, 0);
            //object value = bf.Deserialize(ms);

            //ms.Close();

            //return value;//this.MemberwiseClone();



            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this.wc.m_container);
            ms.Seek(0, 0);
            object value = bf.Deserialize(ms);
            Arzon ar = new Arzon(false);
            ar.wc.m_container = value as System.Net.CookieContainer;
            return ar;
        }

        public List<MovieBasic> FindInURL(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(wc.GetHTML(new Uri(url)));
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='pictlist']");
            List<MovieBasic> list = new List<MovieBasic>();
            if ( nodes==null)
            {
                return list;
            }
            foreach (var item in nodes)
            {
                 var itemurl = "http://www.arzon.jp" + item.SelectSingleNode(".//dt/a").Attributes["href"].Value.ToString().Trim();
                 var title = item.SelectSingleNode(".//dt/a").Attributes["title"].Value.ToString().Trim();
                 var img = item.SelectSingleNode(".//img[1]").Attributes["src"].Value.ToString().Trim();

                 list.Add(new MovieBasic() { ItemURL = itemurl, Img_s = img, Title = title });
            }
            return list;
        }

    }
}
