using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicSo
{
    public partial class MovieContainer : UserControl
    {
        private bool _showOtherButton;

        public bool IsShowOtherButton
        {
            get
            {
                this.Size = new Size(this.Width, this.Height + 30);
                return _showOtherButton;
            }
            set
            {
                this.Size = new Size(this.Width, this.Height - 30);

                _showOtherButton = value;
            }
        }

        public MovieContainer()
        {
            InitializeComponent();
        }

        private AVSORTER.Movie _movie;

        public AVSORTER.Movie Movie
        {
            get { return _movie; }
            set
            {
                if (value!=null)
                {
                    _movie = value;
                    if (value.Actor!=null)
                    {
                        txt_Actor.Text = AVSORTER.Tools.ListToString(value.Actor);
                    }
                    if (value.AVCode!=null)
                    {
                        txt_Code.Text = value.AVCode;
                    }
                    if (value.CoverFile!=null)
                    {
                        txt_CoverFile.Text = value.CoverFile;
                        if (System.IO.File.Exists(value.CoverFile))
                        {
                            this.pictureBox1.Image = Image.FromFile(value.CoverFile);
                        }
                    }
                    if (value.Introduction!=null)
                    {
                        txt_intro.Text = value.Introduction;
                    }
                    if (value.ItemURL!=null)
                    {
                        txt_ItemURL.Text = value.ItemURL;
                    }
                    if (value.Lable!=null)
                    {
                        txt_Lable.Text = value.Lable;
                    }
                    if (value.Maker!=null)
                    {
                        txt_Maker.Text = value.Maker;
                    }
                    if (value.Minutes!=null)
                    {
                        txt_Minutes.Text = value.Minutes;
                    }
                    if (value.Producer!=null)
                    {
                        txt_Producer.Text = value.Producer;
                    }
                    if (value.ReleaseDate!=null)
                    {
                        txt_ReleaseDate.Text = value.ReleaseDate.ToString("yyyy年MM月dd日");
                    }
                    if (value.Series!=null)
                    {
                        txt_Series.Text = value.Series;
                    }
                    if (value.Title!=null)
                    {
                        txt_Title.Text = value.Title;
                    }
                }
                
            }
        }

        private List<AVSORTER.Movie> _list;

        public List<AVSORTER.Movie> MovieList
        {
            get { return _list; }
            set { _list = value; }
        }

        void showNext()
        {
            int i = _list.IndexOf(this.Movie);
            if (i < this.MovieList.Count-1)
            {
                this.Movie = this.MovieList[++i];
            }
        }
        void showPre()
        {
            int i = _list.IndexOf(this.Movie);
            if (i > 0)
            {
                this.Movie = this.MovieList[--i];
            }
        }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            
            if (this.Movie!=null &&  this.Movie.CoverFile != null && System.IO.File.Exists(this.Movie.CoverFile))
            {
                System.Diagnostics.Process.Start(this.Movie.CoverFile);
            }
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            showPre();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            showNext();
        }

        private void btn_openWithBrower_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.txt_ItemURL.Text);
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", System.IO.Path.GetDirectoryName(this.Movie.CoverFile));
        }



    }
}
