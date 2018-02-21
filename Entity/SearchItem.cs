using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AVSORTER
{
    public class SearchItem
    {
        #region 构造函数 public FileItem(string codeString,IGetable getor)

        public SearchItem(string codeString, IGetable getor)
        {
            this._queryString = codeString;
            this.Getor = getor;
        }
        #endregion

        #region 属性 查询字符串public string SeedString

        private string _queryString;
        public string SeedString
        {
            get { return _queryString; }
        }
        #endregion

        #region 属性 影片信息 public Movie MovieDetail
        private Movie _mv;

        public Movie MovieDetail
        {
            get { return _mv; }

        }
        #endregion

        /// <summary>
        /// 结果列表
        /// </summary>
        public List<MovieBasic> MovieBasicList { get; set; }

        private QStatus _status = QStatus.未开始;

        public QStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public object Tag { get; set; }

        /// <summary>
        /// 设定选择结果
        /// </summary>
        /// <param name="index"></param>
        public void Select(int index)
        {
            this.chooseIndex = index;

            _startGetMovie();
        }
        public bool IsSelected
        {
            get
            {
                if (this.chooseIndex == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 设定选择结果
        /// </summary>
        /// <param name="basic"></param>
        public void Select(MovieBasic basic)
        {
            this.chooseIndex = MovieBasicList.IndexOf(basic);
            _startGetMovie();
        }

        public MovieBasic SelectedMovieBasic
        {
            get
            {
                if (this.IsSelected)
                {
                    return this.MovieBasicList[chooseIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        private void _startGetMovie()
        {
            if (OnAboutToLoadImage == null)
            {
                throw new Exception("必须注册这个事件");
            }
            else
            {
                OnAboutToLoadImage(this, new EventArgs());
            }

            try
            {
                if (this.chooseIndex != -1)
                {
                    Func<MovieBasic, Movie> fuc = new Func<MovieBasic, Movie>(Getor.GetMovie);
                    fuc.BeginInvoke(this.MovieBasicList[this.chooseIndex], _getMovieCallback, fuc);
                    RaiseStatusChangeEvent(QStatus.查询完成一个结果, QStatus.获取信息中, "");
                }
                else
                {
                    this._status = QStatus.出错;
                    throw new Exception("还没有选定影片");
                }
            }
            catch (Exception ee)
            {

                throw ee;
            }
        }
        private void _getMovieCallback(IAsyncResult res)
        {

            try
            {
                this._mv = (res.AsyncState as Func<MovieBasic, Movie>).EndInvoke(res);
                this._status = QStatus.获取信息完成;
                if (IsDownloadCover)
                {

                    RaiseStatusChangeEvent(QStatus.获取信息中, QStatus.获取信息完成, "已经获取影片信息！");
                    this._status = QStatus.下载封面中;
                    RaiseStatusChangeEvent(QStatus.获取信息完成, QStatus.下载封面中, "已经获取影片信息！");
                    _startGetCover();
                }
                else
                {
                    this._status = QStatus.准备好移动文件;
                    RaiseStatusChangeEvent(QStatus.获取信息中, QStatus.准备好移动文件, "已经获取影片信息,不要求获取封面！");
                }
            }
            catch (Exception)
            {
                RaiseStatusChangeEvent(QStatus.获取信息中, QStatus.出错, "获取影片信息时出错！");
            }
            finally
            {
                if (OnCompletedLoadImage == null)
                {
                    throw new Exception("必须注册这个事件");
                }
                else
                {
                    OnCompletedLoadImage(this, new EventArgs());
                }
            }

        }

        private void _startGetCover()
        {
            if (IsDownloadCover)
            {
                Func<Movie, bool> fuc = new Func<Movie, bool>(Getor.GetCover);
                fuc.BeginInvoke(this._mv, _getCoverCallBack, fuc);
            }
        }
        private void _getCoverCallBack(IAsyncResult res)
        {
            try
            {
                var ress = (res.AsyncState as Func<Movie, bool>).EndInvoke(res);

                this._status = QStatus.准备好移动文件;
                RaiseStatusChangeEvent(QStatus.下载封面中, QStatus.准备好移动文件, "封面下载完毕");
            }
            catch (Exception)
            {
                RaiseStatusChangeEvent(QStatus.下载封面中, QStatus.出错, "下载封面出错");
            }

        }

        virtual protected void RaiseStatusChangeEvent(QStatus b, QStatus aft, string msg)
        {
            this._status = aft;
            if (OnStatusChange != null)
            {
                OnStatusChange(this, new StatusChangeEventArgs(b, aft, msg));
            }
        }

        public event StatusChangeEvent OnStatusChange;

        private int chooseIndex = -1;

        public IGetable Getor
        {
            get;
            set;
        }

        public void StartQuery()
        {
            if (OnAboutToLoadInfo == null)
            {
                throw new Exception("必须注册这个事件");
            }
            else
            {
				OnAboutToLoadInfo(this, new EventArgs());
            }


            if (this.Getor != null)
            {
                //this.MovieBasicList = Getor.Query(SeedString);
                Func<string, List<MovieBasic>> fuc = new Func<string, List<MovieBasic>>(Getor.Query);
                fuc.BeginInvoke(SeedString, queryFinishCallBack, fuc);

                RaiseStatusChangeEvent(QStatus.未开始, QStatus.查询中, "");
            }
            else
            {
                RaiseStatusChangeEvent(QStatus.查询中, QStatus.出错, "查询影片出错");
            }
        }
        private void queryFinishCallBack(IAsyncResult obj)
        {
            try
            {
                this.MovieBasicList = (obj.AsyncState as Func<string, List<MovieBasic>>).EndInvoke(obj);
                if (this.MovieBasicList.Count > 1)
                {
                    RaiseStatusChangeEvent(QStatus.查询中, QStatus.多个结果请选择一个, "");
                }
                else if (this.MovieBasicList.Count == 1)
                {
                    RaiseStatusChangeEvent(QStatus.查询中, QStatus.查询完成一个结果, "");
                    if (this.IsAutoSelect)
                    {
                        RaiseStatusChangeEvent(QStatus.查询完成一个结果, QStatus.获取信息中, "");
                        Select(0);
                    }
                }
                else
                {
                    RaiseStatusChangeEvent(QStatus.查询中, QStatus.查询完成无匹配, "");
                }
            }
            catch (Exception)
            {
                RaiseStatusChangeEvent(QStatus.查询中, QStatus.出错, "查询出错");
                this.MovieBasicList = null;
                this.chooseIndex = -1;
            }
            finally
            {
                if (OnCompletedLoadInfo == null)
                {
                    throw new Exception("必须注册这个事件");
                }
                else
                {
                    OnCompletedLoadInfo(this, new EventArgs());
                }
            }

        }

        public class StatusChangeEventArgs : EventArgs
        {
            public QStatus Before { get; set; }
            public QStatus After { get; set; }
            public string Message { get; set; }
            public StatusChangeEventArgs(QStatus _before, QStatus _after, string _msg)
            {
                this.Before = _before;
                this.After = _after;
                this.Message = _msg;
            }
        }

        public delegate void StatusChangeEvent(object sender, StatusChangeEventArgs e);

        public event EventHandler OnAboutToLoadInfo;

        public event EventHandler OnCompletedLoadInfo;

        public event EventHandler OnAboutToLoadImage;

        public event EventHandler OnCompletedLoadImage;



        /// <summary>
        /// 是否自动下载封面
        /// </summary>
        public bool IsDownloadCover { get; set; }
        /// <summary>
        /// 当查询结果只有一个时候，是否自动下载详细信息。
        /// </summary>
        public bool IsAutoSelect { get; set; }
    }

}
