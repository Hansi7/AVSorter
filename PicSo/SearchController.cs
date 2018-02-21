using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AVSORTER;
using Gets;

namespace PicSo
{
    internal class SearchController
    {
        private List<string> list1;

        Arzon arzon;

        public List<ResultArzon> Results = new List<ResultArzon>();

        public SearchController(Arzon a, List<string> list)
        {
            list1 = list;
            arzon = a;
        }

        public void MainDo(int threadCount)
        {
            int minWorker, minIOC;

            ThreadPool.GetMinThreads(out minWorker, out minIOC);

            ThreadPool.SetMaxThreads(minWorker, minIOC);

            foreach (string item in list1)
            {
                ResultArzon ra = new ResultArzon { Code = item.ToString(), QStatus= QStatus.未开始 };

                Results.Add(ra);
                ThreadPool.QueueUserWorkItem(willdo,ra as object);
            }
            return;
        }

        void willdo(object fcode)
        {
            Console.WriteLine("start:" + Thread.CurrentThread.ManagedThreadId);

            var ra = fcode as ResultArzon;
            ra.QStatus = QStatus.查询中;
            RaiseStatusChangeEvent(ra);

            var mb_list =  code_2_mb_list(ra.Code);
            ra.QStatus = QStatus.查询完成;
            RaiseStatusChangeEvent(ra);

            if (mb_list.Count<4)
            {
                ra.QStatus = QStatus.获取信息中;
                RaiseStatusChangeEvent(ra);
                foreach (MovieBasic item in mb_list)
                {
                    var m = mb_2_m(item);
                    if (m.AVCode == ra.Code)
                    {
                        ra.QStatus = QStatus.获取信息完成;
                        RaiseStatusChangeEvent(ra);
                        ra.Movie = m;
                        break;
                    }
                }
                ra.QStatus = QStatus.下载封面中;
                RaiseStatusChangeEvent(ra);
                if (m_cover(ra.Movie))
                {
                    ra.QStatus = QStatus.封面下载完成;
                    RaiseStatusChangeEvent(ra);
                }
                else
                {
                    ra.QStatus = QStatus.出错;
                    RaiseStatusChangeEvent(ra);
                }  
            }
            else
            {
                ra.QStatus = QStatus.查询完成无匹配;
                RaiseStatusChangeEvent(ra);
                throw new ArgumentException("code可能不对，有过多的查询结果");
            }
            ra.QStatus = QStatus.准备好移动文件;
            RaiseStatusChangeEvent(ra);
            Console.WriteLine("end:" + Thread.CurrentThread.ManagedThreadId);
        }

        List<MovieBasic> code_2_mb_list(string fcode)
        {
            var new_a = this.arzon.Clone() as Arzon;
            return new_a.Query(fcode);
        }

        Movie mb_2_m(MovieBasic mb)
        {
            var new_a = this.arzon.Clone() as Arzon;
            return new_a.GetMovie(mb);
        }
        bool m_cover(Movie m)
        {
            var new_a = this.arzon.Clone() as Arzon;
            return new_a.GetCover(m);
        }


        public class StatusChangeEventArgs : EventArgs
        {
 
            public ResultArzon Ra { get; set; }
            public StatusChangeEventArgs(ResultArzon ra)
            {
                this.Ra = ra;
            }
        }
        public delegate void StatusChangeHandler(object sender, StatusChangeEventArgs e);

        public event StatusChangeHandler OnStatusChange;

        private void RaiseStatusChangeEvent(ResultArzon ra)
        {
            if (OnStatusChange!=null)
            {
                OnStatusChange(this, new StatusChangeEventArgs(ra));
            }

        }
    }


}
