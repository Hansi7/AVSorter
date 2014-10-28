using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AVSORTER
{
    public partial class BasicContainer : UserControl
    {
        public BasicContainer()
        {
            InitializeComponent();
            this.pictureBox1.Visible = false;
        }
        
        MovieBasic movie;

        public bool IsShowPic { get; set; }

        public MovieBasic MovieB
        {
            get
            {
                return movie;
            }
            set 
            {
                this.movie = value;
                if (this.movie!=null)
                {
                    RefreshUI();
                }
      
            } 
        }
        private List<MovieBasic> _listmovieBasic;
        public List<MovieBasic> ListMovieBasic 
        {
            get
            {
                return _listmovieBasic;
            }
            set
            {
                if (value!=null && value.Count>0)
                {
                    _listmovieBasic = value;
                    this.btn_next.Visible = true;
                    this.btn_pre.Visible = true;
                }
            }
        }

        int index = -1;

        private void RefreshUI()
        {
            
            this.txt_actor.Text = Tools.ListToString(this.movie.Actor);
            IsShowPic = this.cb_ShowPic.Checked;
            this.txt_labl.Text = movie.Label;
            this.txt_title.Text = movie.Title;
            this.txt_URL.Text = movie.ItemURL;
            this.txt_Maker.Text = movie.Maker;
            if (IsShowPic && string.IsNullOrEmpty(MovieB.Img_s_file))
            {
                this.pictureBox1.Visible = false;
                Gets.MyWebClient wc = new Gets.MyWebClient();
                wc.ReferURL = this.movie.ItemURL;
                string fi = this.movie.Title + ".jpg";
                fi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"SmallImage",Path.ChangeExtension(fi, "jpg"));
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(fi)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fi));
                    }
                    //wc.DownloadFile(movie.Img_s, fi);
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new Uri(movie.Img_s), fi,fi);
                    
                }
                catch (Exception s)
                {
                    throw new Exception("下载缩略图失败!");
                }
            }
            else if(IsShowPic)
            {
                this.pictureBox1.Image = Image.FromFile(MovieB.Img_s_file);
            }
        }

        void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            // e.ProgressPercentage
            this.progressBar1.Value = e.ProgressPercentage;
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (this.MovieB.Title == Path.GetFileNameWithoutExtension(e.UserState as string))
                {
                    this.MovieB.Img_s_file = e.UserState as string;
                    this.pictureBox1.Image = Image.FromFile(e.UserState as string);
                    this.pictureBox1.Visible = true;
                }
            }
            catch
            {
                
            }
        }

        private void btn_ShowDetail_Click(object sender, EventArgs e)
        {
            Process.Start(this.MovieB.ItemURL);
        }

        private void txt_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            if (this.ListMovieBasic.Count>1)
            {
                this.index = this.ListMovieBasic.IndexOf(MovieB);
                if (this.index>0)
                {
                    this.MovieB = this.ListMovieBasic[--index];
                }
            }
            else
            {
                this.btn_pre.Visible = false;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (this.ListMovieBasic.Count > 1)
            {
                this.index = this.ListMovieBasic.IndexOf(MovieB);
                if (this.index < this.ListMovieBasic.Count - 1)
                {
                    this.MovieB = this.ListMovieBasic[++index];
                }
            }
            else
            {
                this.btn_next.Visible = false;
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {

        }
    }
}
