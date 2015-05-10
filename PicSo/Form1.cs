using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PicSo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListView.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arzon = new Gets.Arzon(false);
            arzon.InitCompleted += arzon_InitCompleted;
            arzon.CookiesInit();

            var f = AVSORTER.FileProcessor.GetInstance();
            this.txt_Dest.Text = f.DestPath;
            this.txt_sub.Text = f.SubPath;
        }

        void arzon_InitCompleted(object sender, EventArgs e)
        {
            lbl_YouMaStatus.BackColor = Color.Green;
        }

        Gets.Arzon arzon;


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        bool lastSort;
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                this.listView1.ListViewItemSorter = new ListViewColumnSorter(e.Column, !lastSort);
                lastSort = !lastSort;
            }
            catch (Exception)
            {

            }
        }

        //void Go()
        //{
        //    try
        //    {
        //        for (int i = 0; i < this.listView1.Items.Count; i++)
        //        {
        //            this.listView1.Items[i].SubItems.Add("查询品番...");
        //            var mbs = arzon.Query(this.listView1.Items[i].SubItems[1].Text);
        //            if (mbs.Count == 1)
        //            {
        //                this.bc.MovieB = mbs[0];
        //                this.listView1.Items[i].SubItems[2].Text = "下载封面...";
        //                var mv = arzon.GetMovie(this.bc.MovieB);
        //                arzon.GetCover(mv);
        //                this.listView1.Items[i].SubItems[2].Text = "完成";

        //                f.MakeMove(mv, listView1.Items[i].Text);

        //            }
        //            else
        //            {
        //                this.listView1.Items[i].SubItems[2].Text = "未找到";
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        f.WriteLog();
        //    }

        //}


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.listView1.ListViewItemSorter = null;
            AVSORTER.FileProcessor.GetInstance().Files.Clear();
        }

        private void btn_removeItem_Click(object sender, EventArgs e)
        {
            while (this.listView1.SelectedItems.Count > 0)
            {
                this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
            }
        }

        private void btn_brower_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var f = AVSORTER.FileProcessor.GetInstance();
                f.AddDirectory(fbd.SelectedPath);
                List<ListViewItem> li = new List<ListViewItem>();
                for (int i = 0; i < f.Files.Count; i++)
                {
                    li.Add(new ListViewItem(f.Files[i]));
                }
                this.listView1.Items.AddRange(li.ToArray());
            }
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].SubItems.Add(AVSORTER.Tools.Fcode(Path.GetFileNameWithoutExtension(this.listView1.Items[i].Text)));
                this.listView1.Items[i].SubItems.Add("");
            }
        }
        void initFileProcessor()
        {
            var f = AVSORTER.FileProcessor.GetInstance();
            if (f != null)
            {
                f.DestPath = txt_Dest.Text;
                f.SubPath = txt_sub.Text;
                f.ShowLog = cb_IsShowlog.Checked;
                new AVSORTER.DB.AVDB().SetDestPath(f.DestPath);
                new AVSORTER.DB.AVDB().SetSubPath(f.SubPath);
            }
        }

        private void btn_GO_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                var fi = new AVSORTER.SearchItem(item.SubItems[1].Text, arzon.Clone() as AVSORTER.IGetable);

                item.Tag = fi;
                fi.OnStatusChange += fi_OnStatusChange;
                fi.Tag = item;
                fi.IsAutoSelect = cb_AutoSelect.Checked;
                fi.IsDownloadCover = cb_isCoverDownload.Checked;
                fi.StartQuery();
            }
        }

        void fi_OnStatusChange(object sender, AVSORTER.SearchItem.StatusChangeEventArgs e)
        {
            ((sender as AVSORTER.SearchItem).Tag as ListViewItem).SubItems[2].Text = e.After.ToString();



        }

        private void UIParamChange(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (listView1.SelectedItems[0].Tag != null)
                {
                    var si = (listView1.SelectedItems[0].Tag as AVSORTER.SearchItem);

                    this.bc.ListMovieBasic = si.MovieBasicList;
                    if (si.IsSelected)
                    {
                        this.bc.MovieB = si.SelectedMovieBasic;
                    }
                    else if (si.MovieBasicList != null && si.MovieBasicList.Count != 0)
                    {
                        this.bc.MovieB = si.MovieBasicList[0];
                    }
                }

            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (listView1.SelectedItems[0].Tag != null)
                {
                    (listView1.SelectedItems[0].Tag as AVSORTER.SearchItem).Select(this.bc.MovieB);
                }

            }
        }

        private void btn_MoveFile_Click(object sender, EventArgs e)
        {
            this.btn_MoveFile.Enabled = false;
            try
            {
                initFileProcessor();
                foreach (ListViewItem item in listView1.Items)
                {
                    if ((item.Tag as AVSORTER.SearchItem).IsSelected == true)
                    {
                        if (item.Text != "No File")
                        {
                            AVSORTER.FileProcessor.GetInstance().MakeMove((item.Tag as AVSORTER.SearchItem).MovieDetail, item.Text);
                            item.SubItems[2].Text = "移动成功！";
                        }
                        else
                        {
                            item.SubItems[2].Text = "未移动";
                        }



                    }
                    else
                    {
                        item.SubItems[2].Text = "未指定对应影片信息";
                    }

                }
                AVSORTER.FileProcessor.GetInstance().WriteLog();
            }
            catch(Exception err )
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.btn_MoveFile.Enabled = true;
            }
        }

        private void menu_BrowerFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                System.Diagnostics.Process.Start("Explorer.exe", "/select, " + listView1.SelectedItems[0].Text);
            }
        }

        private void menu_ChangeFcode_Click(object sender, EventArgs e)
        {
            var inp = new InputBox();
            if (listView1.SelectedItems.Count>0)
            {
                inp.InputText = listView1.SelectedItems[0].SubItems[1].Text;
            }

            if (inp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listView1.SelectedItems[0].SubItems[1].Text = inp.InputText;
            }
        }

        private void menu_remove_Click(object sender, EventArgs e)
        {
            while (this.listView1.SelectedItems.Count > 0)
            {
                this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Link)
            {
                var dd = e.Data.GetData(DataFormats.FileDrop);


                var f = AVSORTER.FileProcessor.GetInstance();
                this.txt_Dest.Text = f.DestPath;
                this.txt_sub.Text = f.SubPath;
                var arr = dd as string[];
                foreach (var item in arr)
                {
                    f.AddDirectory(item);
                }
                List<ListViewItem> li = new List<ListViewItem>();
                for (int i = 0; i < f.Files.Count; i++)
                {
                    var lsvi = new ListViewItem(f.Files[i]);
                    lsvi.SubItems.Add(AVSORTER.Tools.Fcode(Path.GetFileNameWithoutExtension(f.Files[i])));
                    lsvi.SubItems.Add("");
                    li.Add(lsvi);
                }
                this.listView1.Items.Clear();
                this.listView1.Items.AddRange(li.ToArray());
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void bc_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menu_BigCover_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                var d = (listView1.SelectedItems[0].Tag as AVSORTER.SearchItem).MovieDetail;
                if (d != null)
                {
                    System.Diagnostics.Process.Start(d.CoverFile);
                }
            }
        }

        private void btn_AddNewEmptyItem_Click(object sender, EventArgs e)
        {

            var li = new ListViewItem("No File");
            li.SubItems.Add(AVSORTER.Tools.Fcode(this.txt_EmptyItemKeyWord.Text));
            li.SubItems.Add("");

            this.listView1.Items.Add(li);

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                var d = (listView1.SelectedItems[0].Tag as AVSORTER.SearchItem);
                if (d.MovieDetail != null &&  !string.IsNullOrEmpty(d.MovieDetail.CoverFile))
                {
                    System.Diagnostics.Process.Start(d.MovieDetail.CoverFile);
                }
            }
        }


        private void btn_rebuild_Click(object sender, EventArgs e)
        {
            this.btn_MoveFile.Enabled = false;
            initFileProcessor();
            foreach (ListViewItem item in listView1.Items)
            {
                if ((item.Tag as AVSORTER.SearchItem).IsSelected == true)
                {
                    if (item.Text != "No File")
                    {
                        AVSORTER.FileProcessor.GetInstance().MakeDataBase((item.Tag as AVSORTER.SearchItem).MovieDetail, item.Text);
                        item.SubItems[2].Text = "成功！";
                    }
                    else
                    {
                        item.SubItems[2].Text = "未动";
                    }



                }
                else
                {
                    item.SubItems[2].Text = "未指定对应影片信息";
                }

            }
            AVSORTER.FileProcessor.GetInstance().WriteLog();
            this.btn_MoveFile.Enabled = true;
        }


        #region Page2

        private void btn_LocalSearch_Click(object sender, EventArgs e)
        {
            string fc = txt_LocalSearchKeyWord.Text;
            if (cb_AutoCorrect.Checked)
            {
                fc = AVSORTER.Tools.Fcode(txt_LocalSearchKeyWord.Text);
                txt_LocalSearchKeyWord.Text = fc;
            }
            var db = new AVSORTER.DB.AVDB();
            var l = db.QueryAV(fc);
            this.movieContainer1.MovieList = l;


            this.listBox1.DataSource = l;
            //this.listBox1.DisplayMember = string.Format("{0}:{1}", "AVCode", "Title");

            if (l.Count > 0)
            {
                this.movieContainer1.Movie = l[0];
            }
        }
        private void txt_LocalSearchKeyWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btn_LocalSearch_Click(sender, e);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count>0)
            {
                this.movieContainer1.Movie = (this.listBox1.SelectedItem as AVSORTER.Movie);
            }
        }
        #endregion

        #region Page3
        

        private void btnFind_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(worker);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker =  (e.Argument as BackgroundWorker);
            List<AVSORTER.Movie> list = new List<AVSORTER.Movie>();
            var mvbs = arzon.FindInURL(txt_url.Text);
            worker.ReportProgress(0, "共找到影片:" + mvbs.Count.ToString());
            int no = 0;
            int totalNo = mvbs.Count;
            foreach (var mvb in mvbs)
            {
                var fi = arzon.Clone() as AVSORTER.IGetable;
                var mv = fi.GetMovie(mvb);
                no++;
                worker.ReportProgress(0, no.ToString() + "/" + totalNo.ToString());
                worker.ReportProgress(0,mv.AVCode + "\t" + mv.Title);
                Gets.MyWebClient wc = new Gets.MyWebClient();
                wc.ReferURL = mvb.ItemURL;
                string fn = mvb.Title + ".jpg";
                fn = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmallImageFindInURL", Path.ChangeExtension(fn, "jpg"));
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(fn)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fn));
                    }
                    if (!File.Exists(fn))
                    {
                        wc.DownloadFile(mvb.Img_s, fn);
                    }
                    else
                    {
                        Console.WriteLine("已有封面" + fn);
                    }
                    worker.ReportProgress(0, mv.AVCode + "\t封面OK!");

                }
                catch (Exception s)
                {
                    throw new Exception("下载缩略图失败!");
                }
                mv.CoverFile = fn;
                list.Add(mv);
            }
            StringBuilder sb = new StringBuilder();
            foreach (AVSORTER.Movie item in list)
            {
                sb.Append("<div id = \"" + item.AVCode + "\" class = \"item\"><img src = \"" + item.CoverFile + "\" /><input type=\"checkbox\" />" + item.AVCode + "</div>");
            }
            var htmlResult = Properties.Resources.htmlResultStart + sb + Properties.Resources.htmlResultEnd;
            System.IO.File.WriteAllText("temp.html", htmlResult);
            System.Diagnostics.Process.Start("temp.html");
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage==0)
            {
                txt_FindStatus.AppendText(e.UserState as string + "\r\n");
            }
        }

        #endregion


        
    }

    

}
