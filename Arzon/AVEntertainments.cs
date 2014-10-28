using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using HtmlAgilityPack;
using AVSORTER;

namespace Gets
{
    public class AVEntertainments:IGetable
    {
        MyWebClient wc;
        Uri uri;
        public AVEntertainments()
        {
            const string url = "http://www.aventertainments.com/search_Products.aspx?languageID=2";
            uri = new Uri(url);
            wc = new MyWebClient();
            wc.DownloadData(uri);
        }
        public List<MovieBasic> Query(string keyword)
        {
            Uri u = urlCombine(keyword);
            HtmlDocument doc = new HtmlDocument();
            wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-TW; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5");
            wc.Headers.Set("Referer", "http://aventertainments.com/Main.aspx?languageID=2");
            wc.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
            string htmlString = wc.GetHTML(u);
            

            doc.LoadHtml(htmlString );

            var listItems = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentPlaceHolder1_Rows2Items1_MyList']/tr/td[@valign='top']/table");

            List<MovieBasic> l = new List<MovieBasic>();
            if (listItems == null)
            {
                return l;
            }
            foreach (var item in listItems)
            {
                var title = item.ChildNodes["tr"].ChildNodes["td"].ChildNodes["h4"].InnerText;
                //listItems[0].ChildNodes["table"].ChildNodes["tr"].ChildNodes["td"].ChildNodes["h4"].InnerText;
                title = title.Trim("&nbsp;".ToArray());
                var img_s = item.ChildNodes["tr"].ChildNodes["td"].ChildNodes["div"].ChildNodes["a"].ChildNodes["img"].Attributes["src"].Value;
                var actor = item.ChildNodes["tr"].ChildNodes["td"].ChildNodes["a"].InnerText;
                var maker = item.ChildNodes["tr"].ChildNodes["td"].Elements("a").ElementAt(1).InnerText;
                var itemURL = item.ChildNodes["tr"].ChildNodes["td"].ChildNodes["h4"].ChildNodes["a"].Attributes["href"].Value;
                var label = item.ChildNodes["tr"].ChildNodes["td"].InnerText;
                int st = label.IndexOf("商品番号:") + 5;
                int ed = label.IndexOf("発売日");
                label = label.Substring(st, ed - st).Trim().Trim("&nbsp;".ToArray());


                var _actorList = new List<string>();
                _actorList.Add(actor);
                MovieBasic mb = new MovieBasic()
                {
                    Title = title,
                    Img_s = img_s,
                    Actor = _actorList,
                    ItemURL = itemURL,
                    Label = label,
                    Maker = maker
                };
                l.Add(mb);
            }

            return l;


            //wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            //wc.Headers.Add(System.Net.HttpRequestHeader.Referer, "https://www.aventertainments.com/login.aspx?languageID=1");
            //NameValueCollection nvc = new NameValueCollection();
            //nvc.Add("ctl00$ContentPlaceHolder1$uid","hansi-go@163.com");
            //nvc.Add("ctl00$ContentPlaceHolder1$passwd", "177991");
            
            //wc.UploadData("https://www.aventertainments.com/login.aspx?languageID=1", "POST", nvc);
            

        }

        private Uri urlCombine(string keyword)
        {
            return new Uri("http://www.aventertainments.com/search_Products.aspx?languageID=2&searchby=keyword&keyword=" + keyword);
        }

        public Movie GetMovie(MovieBasic movieBasic)
        {
            //wc.Headers.Set("Referer", "http://www.aventertainments.com/search_Products.aspx?languageID=2&searchby=keyword&keyword=cwp");
            //wc.Headers.Set("Host", "www.aventertainments.com");
            //wc.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
            wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

            string html = wc.GetHTML(new Uri(movieBasic.ItemURL));
            var docc = new HtmlDocument();
            docc.LoadHtml(html);

            string Title = movieBasic.Title;
            string label = docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[3].ParentNode.InnerText;
            string changjia = docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[1].ParentNode.ChildNodes["a"].InnerText;
            string jiandu = string .Empty;
            string date = docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[4].ParentNode.InnerText;
            string minutes = docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[5].ParentNode.InnerText;
            string f_code = movieBasic.Label;
            string xilie = docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[2].ParentNode.ChildNodes["a"].InnerText;
            string intro = docc.DocumentNode.SelectNodes("//div[@id='titlebox']/div[5]/p")[0].InnerText;
            string coverImage = docc.DocumentNode.SelectNodes("//div[@class='top_sample']")[0].InnerHtml;
            int st = coverImage.IndexOf("ImageUrl=") + 9;
            int ed = coverImage.IndexOf(",", st);
            coverImage = coverImage.Substring(st, ed - st);


            //docc.DocumentNode.SelectNodes("//span[@class='redtitle']")[1].ParentNode.ChildNodes["a"].InnerText


            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\d{1,2}/\d{1,2}/\d{4}");
            date = r.Match(date).Value;

            //*[@id="titlebox"]/ul[3]/li[5]
            Movie m = new Movie()
            {
                Title = Title,
                Lable = label,
                Maker = changjia,
                ReleaseDate = DateTime.Parse(date),
                Minutes = minutes,
                AVCode = f_code,
                Introduction = intro,
                Actor = movieBasic.Actor,
                ItemURL = movieBasic.ItemURL,
                CoverURL = coverImage,
                Producer = jiandu,
                Series = xilie
            };

            return m;
        }

        public bool GetCover(Movie mo)
        {
            throw new NotImplementedException();
        }

        public bool IsInitCompleted
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
