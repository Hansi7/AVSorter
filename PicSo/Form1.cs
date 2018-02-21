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
using System.Threading.Tasks;
using AVSORTER;

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

        Semaphore sem1_bmovie = new Semaphore(2, 2);
        Semaphore sem2_movie = new Semaphore(2, 2);

        private void btn_GO_Click(object sender, EventArgs e)
        {
            //newGOGOGO();
            //return;



            foreach (ListViewItem item in listView1.Items)
            {
                var fi = new AVSORTER.SearchItem(item.SubItems[1].Text, arzon.Clone() as AVSORTER.IGetable);
                item.Tag = fi;
                fi.OnStatusChange += fi_OnStatusChange;
                fi.Tag = item;
                fi.IsAutoSelect = cb_AutoSelect.Checked;
                fi.IsDownloadCover = cb_isCoverDownload.Checked;
                //等一个许可信号
                fi.OnAboutToLoadInfo += Fi_OnAboutToLoadInfo;
                //释放放一个许可
                fi.OnCompletedLoadInfo += Fi_OnCompletedLoadInfo;

                fi.OnAboutToLoadImage += Fi_OnAboutToLoadImage;

                fi.OnCompletedLoadImage += Fi_OnCompletedLoadImage;

                fi.StartQuery();
            }
        }
        private void newGOGOGO()
        {

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;


            Task<List<AVSORTER.MovieBasic>>[] tasks = new Task<List<AVSORTER.MovieBasic>>[listView1.Items.Count];
            int i = -1;

            foreach (ListViewItem item in listView1.Items)
            {
                i++;
                AVSORTER.IGetable getor = arzon.Clone() as AVSORTER.IGetable;
                tasks[i] = new Task<List<AVSORTER.MovieBasic>>(() =>
                {
                    return getor.Query(item.SubItems[1].Text);
                }, token);

                tasks[i].ContinueWith<AVSORTER.Movie>((mbasics) =>
                {
                    if (mbasics.Result.Count == 1)
                    {
                        return getor.GetMovie(mbasics.Result[0]);
                    }
                    else
                    {
                        return null;
                    }
                });

                tasks[i].Start();

            }


        }




        private void Fi_OnAboutToLoadImage(object sender, EventArgs e)
        {
            sem2_movie.WaitOne();
        }

        private void Fi_OnCompletedLoadImage(object sender, EventArgs e)
        {
            sem2_movie.Release();
        }
        private void Fi_OnCompletedLoadInfo(object sender, EventArgs e)
        {
            sem1_bmovie.Release();
        }

        private void Fi_OnAboutToLoadInfo(object sender, EventArgs e)
        {
            sem1_bmovie.WaitOne();
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
            return;

            if (listView1.SelectedItems.Count == 1)
            {
                if (listView1.SelectedItems[0].Tag != null)
                {
                    var si = (listView1.SelectedItems[0].Tag as ResultArzon);


                }

            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {

            MessageBox.Show("不需要了");
            return;


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

                    if (item.Text != "No File")
                    {
                        AVSORTER.FileProcessor.GetInstance().MakeMove((item.Tag as AVSORTER.ResultArzon).Movie, item.Text);
                        item.SubItems[2].Text = "移动成功！";
                    }
                    else
                    {
                        item.SubItems[2].Text = "未移动";
                    }

                }
                AVSORTER.FileProcessor.GetInstance().WriteLog();
            }
            catch (Exception err)
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
            if (listView1.SelectedItems.Count > 0)
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
                var d = (listView1.SelectedItems[0].Tag as ResultArzon).Movie;

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
        private void btn_paste_new_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txt_EmptyItemKeyWord.Text = Clipboard.GetText();
                btn_AddNewEmptyItem_Click(this, new EventArgs());
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            { 


                if (this.listView1.SelectedItems.Count > 0)
                {
                    var d = (listView1.SelectedItems[0].Tag as ResultArzon);

                    Console.WriteLine(d.Movie);


                    if (d.Movie != null && d != null && !string.IsNullOrEmpty(d.Movie.CoverFile))
                    {
                        System.Diagnostics.Process.Start(d.Movie.CoverFile);
                    }
                }
            }
            catch (Exception ees)
            {
                MessageBox.Show(ees.Message);
            }
        }


        private void btn_rebuild_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未实现");
            return;
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
            if (e.KeyChar == 13)
            {
                btn_LocalSearch_Click(sender, e);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (this.listBox1.SelectedItems.Count > 0)
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
            var worker = (e.Argument as BackgroundWorker);
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
                worker.ReportProgress(0, mv.AVCode + "\t" + mv.Title);
                if (mv.Actor != null && mv.Actor.Count <= nud_ActorLessThan.Value)
                {
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
                    catch
                    { }
                    mv.CoverFile = fn;
                    list.Add(mv);
                }
                else
                {
                    worker.ReportProgress(0, mv.AVCode + "\t演员人数超限制\t" + mv.Title);
                }
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
            if (e.ProgressPercentage == 0)
            {
                txt_FindStatus.AppendText(e.UserState as string + "\r\n");
            }
        }

        #endregion


        #region Page4
        private void btn_p4_Go1_Click(object sender, EventArgs e)
        {
            lbl_p4_status.Visible = true;
            btn_p4_Go1.Enabled = false;
            btn_p4_Go1_paste.Enabled = false;


            BackgroundWorker workerP4 = new BackgroundWorker();
            workerP4.WorkerReportsProgress = true;
            workerP4.ProgressChanged += workerP4_ProgressChanged;
            workerP4.DoWork += workerP4_DoWork;
            workerP4.RunWorkerCompleted += workerP4_RunWorkerCompleted;
            workerP4.RunWorkerAsync();

        }
        void workerP4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_p4_status.Visible = false;
            btn_p4_Go1.Enabled = true;
            btn_p4_Go1_paste.Enabled = true;
        }
        /// <summary>
        /// torrentKitty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void workerP4_DoWork(object sender, DoWorkEventArgs e)
        {
            Gets.HttpHelper help = new Gets.HttpHelper(new System.Net.CookieContainer());
            var html = help.GetHtml("http://www.torrentkitty.net/search/" + txt_p4_keyword.Text.Trim());
            Console.WriteLine(html);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            if (doc.DocumentNode.SelectNodes("//table[@id='archiveResult']/tr") == null)
            {
                return;
            }

            int n = doc.DocumentNode.SelectNodes("//table[@id='archiveResult']/tr").Count;

            for (int i = 2; i < n; i++)
            {
                var name = doc.DocumentNode.SelectSingleNode("//table[@id='archiveResult']/tr[" + i + "]/td[@class='name']").InnerText;
                ListViewItem li = new ListViewItem(name);
                var size = doc.DocumentNode.SelectSingleNode("//table[@id='archiveResult']/tr[" + i + "]/td[@class='size']").InnerText;
                li.SubItems.Add(size);
                var link = doc.DocumentNode.SelectSingleNode("//table[@id='archiveResult']/tr[" + i + "]/td[@class='action']/a[2]").Attributes["href"].Value;
                li.SubItems.Add(link);
                lv_p4_result.Items.Add(li);
            }
            lv_p4_result.Items.Add(new ListViewItem("====="));
        }

        void workerP4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void cmenu_p4_item_copy_Click(object sender, EventArgs e)
        {
            if (lv_p4_result.SelectedItems.Count == 1)
            {
                var link = lv_p4_result.SelectedItems[0].SubItems[2].Text;

                Clipboard.SetText(link);

            }
        }
        private void btn_p4_Clear_Click(object sender, EventArgs e)
        {
            lv_p4_result.Items.Clear();
        }
        private void btn_p4_Go1_paste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txt_p4_keyword.Text = Clipboard.GetText();
                btn_p4_Go1_Click(this, new EventArgs());
            }
        }
        #endregion
        SearchController currentSearchController;
        private void button1_Click(object sender, EventArgs e)
        {

            List<string> l = new List<string>();

            foreach (ListViewItem item in listView1.Items)
            {
                l.Add(item.SubItems[1].Text);
            }
            SearchController sc = new SearchController(arzon, l);

            currentSearchController = sc;

            sc.OnStatusChange += Sc_OnStatusChange;

            sc.MainDo(1);

        }

        private void Sc_OnStatusChange(object sender, SearchController.StatusChangeEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == e.Ra.Code)
                {
                    item.SubItems[2].Text = e.Ra.QStatus.ToString();
                    item.Tag = e.Ra;
                }
            }
        }
    }



}
