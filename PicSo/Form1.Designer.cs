namespace PicSo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_BigCover = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_BrowerFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ChangeFcode = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_YouMaStatus = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_rebuild = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_AddNewEmptyItem = new System.Windows.Forms.Button();
            this.txt_EmptyItemKeyWord = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_removeItem = new System.Windows.Forms.Button();
            this.btn_brower = new System.Windows.Forms.Button();
            this.cb_AutoSelect = new System.Windows.Forms.CheckBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.cb_isCoverDownload = new System.Windows.Forms.CheckBox();
            this.btn_GO = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_MoveFile = new System.Windows.Forms.Button();
            this.cb_IsShowlog = new System.Windows.Forms.CheckBox();
            this.txt_Dest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sub = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bc = new AVSORTER.BasicContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cb_AutoCorrect = new System.Windows.Forms.CheckBox();
            this.movieContainer1 = new PicSo.MovieContainer();
            this.btn_LocalSearch = new System.Windows.Forms.Button();
            this.txt_LocalSearchKeyWord = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_BigCover,
            this.menu_BrowerFile,
            this.menu_ChangeFcode,
            this.menu_remove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 92);
            // 
            // menu_BigCover
            // 
            this.menu_BigCover.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.menu_BigCover.Name = "menu_BigCover";
            this.menu_BigCover.Size = new System.Drawing.Size(184, 22);
            this.menu_BigCover.Text = "查看大图";
            this.menu_BigCover.Click += new System.EventHandler(this.menu_BigCover_Click);
            // 
            // menu_BrowerFile
            // 
            this.menu_BrowerFile.Name = "menu_BrowerFile";
            this.menu_BrowerFile.Size = new System.Drawing.Size(184, 22);
            this.menu_BrowerFile.Text = "查看文件位置";
            this.menu_BrowerFile.Click += new System.EventHandler(this.menu_BrowerFile_Click);
            // 
            // menu_ChangeFcode
            // 
            this.menu_ChangeFcode.Name = "menu_ChangeFcode";
            this.menu_ChangeFcode.Size = new System.Drawing.Size(184, 22);
            this.menu_ChangeFcode.Text = "更改此项目的关键字";
            this.menu_ChangeFcode.Click += new System.EventHandler(this.menu_ChangeFcode_Click);
            // 
            // menu_remove
            // 
            this.menu_remove.Name = "menu_remove";
            this.menu_remove.Size = new System.Drawing.Size(184, 22);
            this.menu_remove.Text = "移除项目";
            this.menu_remove.Click += new System.EventHandler(this.menu_remove_Click);
            // 
            // lbl_YouMaStatus
            // 
            this.lbl_YouMaStatus.AutoSize = true;
            this.lbl_YouMaStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_YouMaStatus.Location = new System.Drawing.Point(14, 607);
            this.lbl_YouMaStatus.Name = "lbl_YouMaStatus";
            this.lbl_YouMaStatus.Size = new System.Drawing.Size(77, 12);
            this.lbl_YouMaStatus.TabIndex = 26;
            this.lbl_YouMaStatus.Text = "骑兵组件状态";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_rebuild);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btn_select);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.bc);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "批量文件处理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_rebuild
            // 
            this.btn_rebuild.Location = new System.Drawing.Point(681, 461);
            this.btn_rebuild.Name = "btn_rebuild";
            this.btn_rebuild.Size = new System.Drawing.Size(119, 60);
            this.btn_rebuild.TabIndex = 20;
            this.btn_rebuild.Text = "重建数据库\r\n\r\n不移动文件";
            this.btn_rebuild.UseVisualStyleBackColor = true;
            this.btn_rebuild.Click += new System.EventHandler(this.btn_rebuild_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_AddNewEmptyItem);
            this.groupBox2.Controls.Add(this.txt_EmptyItemKeyWord);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.btn_removeItem);
            this.groupBox2.Controls.Add(this.btn_brower);
            this.groupBox2.Controls.Add(this.cb_AutoSelect);
            this.groupBox2.Controls.Add(this.btn_Clear);
            this.groupBox2.Controls.Add(this.cb_isCoverDownload);
            this.groupBox2.Controls.Add(this.btn_GO);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 324);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件列表处理";
            // 
            // btn_AddNewEmptyItem
            // 
            this.btn_AddNewEmptyItem.Location = new System.Drawing.Point(139, 47);
            this.btn_AddNewEmptyItem.Name = "btn_AddNewEmptyItem";
            this.btn_AddNewEmptyItem.Size = new System.Drawing.Size(127, 23);
            this.btn_AddNewEmptyItem.TabIndex = 19;
            this.btn_AddNewEmptyItem.Text = "新建查询条目";
            this.btn_AddNewEmptyItem.UseVisualStyleBackColor = true;
            this.btn_AddNewEmptyItem.Click += new System.EventHandler(this.btn_AddNewEmptyItem_Click);
            // 
            // txt_EmptyItemKeyWord
            // 
            this.txt_EmptyItemKeyWord.Location = new System.Drawing.Point(6, 49);
            this.txt_EmptyItemKeyWord.Name = "txt_EmptyItemKeyWord";
            this.txt_EmptyItemKeyWord.Size = new System.Drawing.Size(127, 21);
            this.txt_EmptyItemKeyWord.TabIndex = 18;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(788, 238);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 445;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "番号";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            this.columnHeader3.Width = 158;
            // 
            // btn_removeItem
            // 
            this.btn_removeItem.Location = new System.Drawing.Point(139, 20);
            this.btn_removeItem.Name = "btn_removeItem";
            this.btn_removeItem.Size = new System.Drawing.Size(127, 23);
            this.btn_removeItem.TabIndex = 4;
            this.btn_removeItem.Text = "删除选择项目";
            this.btn_removeItem.UseVisualStyleBackColor = true;
            this.btn_removeItem.Click += new System.EventHandler(this.btn_removeItem_Click);
            // 
            // btn_brower
            // 
            this.btn_brower.Location = new System.Drawing.Point(6, 20);
            this.btn_brower.Name = "btn_brower";
            this.btn_brower.Size = new System.Drawing.Size(127, 23);
            this.btn_brower.TabIndex = 3;
            this.btn_brower.Text = "浏览文件夹...";
            this.btn_brower.UseVisualStyleBackColor = true;
            this.btn_brower.Click += new System.EventHandler(this.btn_brower_Click);
            // 
            // cb_AutoSelect
            // 
            this.cb_AutoSelect.AutoSize = true;
            this.cb_AutoSelect.Checked = true;
            this.cb_AutoSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_AutoSelect.Location = new System.Drawing.Point(406, 24);
            this.cb_AutoSelect.Name = "cb_AutoSelect";
            this.cb_AutoSelect.Size = new System.Drawing.Size(120, 16);
            this.cb_AutoSelect.TabIndex = 17;
            this.cb_AutoSelect.Text = "自动对应唯一结果";
            this.cb_AutoSelect.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(272, 20);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(128, 50);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "清除";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // cb_isCoverDownload
            // 
            this.cb_isCoverDownload.AutoSize = true;
            this.cb_isCoverDownload.Checked = true;
            this.cb_isCoverDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_isCoverDownload.Location = new System.Drawing.Point(406, 41);
            this.cb_isCoverDownload.Name = "cb_isCoverDownload";
            this.cb_isCoverDownload.Size = new System.Drawing.Size(72, 16);
            this.cb_isCoverDownload.TabIndex = 16;
            this.cb_isCoverDownload.Text = "下载封面";
            this.cb_isCoverDownload.UseVisualStyleBackColor = true;
            // 
            // btn_GO
            // 
            this.btn_GO.Location = new System.Drawing.Point(532, 20);
            this.btn_GO.Name = "btn_GO";
            this.btn_GO.Size = new System.Drawing.Size(110, 50);
            this.btn_GO.TabIndex = 15;
            this.btn_GO.Text = "Go!";
            this.btn_GO.UseVisualStyleBackColor = true;
            this.btn_GO.Click += new System.EventHandler(this.btn_GO_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(423, 341);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(159, 63);
            this.btn_select.TabIndex = 24;
            this.btn_select.Text = "设置对应关系至选定的项目";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_MoveFile);
            this.groupBox1.Controls.Add(this.cb_IsShowlog);
            this.groupBox1.Controls.Add(this.txt_Dest);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_sub);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(423, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 111);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件移动设置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_MoveFile
            // 
            this.btn_MoveFile.Location = new System.Drawing.Point(137, 78);
            this.btn_MoveFile.Name = "btn_MoveFile";
            this.btn_MoveFile.Size = new System.Drawing.Size(99, 23);
            this.btn_MoveFile.TabIndex = 25;
            this.btn_MoveFile.Text = "移动文件";
            this.btn_MoveFile.UseVisualStyleBackColor = true;
            this.btn_MoveFile.Click += new System.EventHandler(this.btn_MoveFile_Click);
            // 
            // cb_IsShowlog
            // 
            this.cb_IsShowlog.AutoSize = true;
            this.cb_IsShowlog.Checked = true;
            this.cb_IsShowlog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsShowlog.Location = new System.Drawing.Point(23, 78);
            this.cb_IsShowlog.Name = "cb_IsShowlog";
            this.cb_IsShowlog.Size = new System.Drawing.Size(108, 16);
            this.cb_IsShowlog.TabIndex = 18;
            this.cb_IsShowlog.Text = "完成后显示日志";
            this.cb_IsShowlog.UseVisualStyleBackColor = true;
            this.cb_IsShowlog.CheckedChanged += new System.EventHandler(this.UIParamChange);
            // 
            // txt_Dest
            // 
            this.txt_Dest.Location = new System.Drawing.Point(75, 20);
            this.txt_Dest.Name = "txt_Dest";
            this.txt_Dest.Size = new System.Drawing.Size(161, 21);
            this.txt_Dest.TabIndex = 9;
            this.txt_Dest.Leave += new System.EventHandler(this.UIParamChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "分类路径";
            // 
            // txt_sub
            // 
            this.txt_sub.Location = new System.Drawing.Point(75, 47);
            this.txt_sub.Name = "txt_sub";
            this.txt_sub.Size = new System.Drawing.Size(161, 21);
            this.txt_sub.TabIndex = 8;
            this.txt_sub.Text = "演员\\[番号]标题";
            this.txt_sub.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txt_sub.Leave += new System.EventHandler(this.UIParamChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "目标路径";
            // 
            // bc
            // 
            this.bc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bc.IsShowPic = false;
            this.bc.ListMovieBasic = null;
            this.bc.Location = new System.Drawing.Point(6, 341);
            this.bc.MovieB = null;
            this.bc.Name = "bc";
            this.bc.Size = new System.Drawing.Size(411, 180);
            this.bc.TabIndex = 7;
            this.bc.Load += new System.EventHandler(this.bc_Load);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 583);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.cb_AutoCorrect);
            this.tabPage2.Controls.Add(this.movieContainer1);
            this.tabPage2.Controls.Add(this.btn_LocalSearch);
            this.tabPage2.Controls.Add(this.txt_LocalSearchKeyWord);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(965, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "本地查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(913, 136);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cb_AutoCorrect
            // 
            this.cb_AutoCorrect.AutoSize = true;
            this.cb_AutoCorrect.Checked = true;
            this.cb_AutoCorrect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_AutoCorrect.Location = new System.Drawing.Point(231, 8);
            this.cb_AutoCorrect.Name = "cb_AutoCorrect";
            this.cb_AutoCorrect.Size = new System.Drawing.Size(72, 16);
            this.cb_AutoCorrect.TabIndex = 3;
            this.cb_AutoCorrect.Text = "自动改正";
            this.cb_AutoCorrect.UseVisualStyleBackColor = true;
            // 
            // movieContainer1
            // 
            this.movieContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.movieContainer1.Location = new System.Drawing.Point(6, 176);
            this.movieContainer1.Movie = null;
            this.movieContainer1.MovieList = null;
            this.movieContainer1.Name = "movieContainer1";
            this.movieContainer1.Size = new System.Drawing.Size(913, 375);
            this.movieContainer1.TabIndex = 2;
            // 
            // btn_LocalSearch
            // 
            this.btn_LocalSearch.Location = new System.Drawing.Point(309, 4);
            this.btn_LocalSearch.Name = "btn_LocalSearch";
            this.btn_LocalSearch.Size = new System.Drawing.Size(123, 23);
            this.btn_LocalSearch.TabIndex = 1;
            this.btn_LocalSearch.Text = "搜索";
            this.btn_LocalSearch.UseVisualStyleBackColor = true;
            this.btn_LocalSearch.Click += new System.EventHandler(this.btn_LocalSearch_Click);
            // 
            // txt_LocalSearchKeyWord
            // 
            this.txt_LocalSearchKeyWord.Location = new System.Drawing.Point(6, 6);
            this.txt_LocalSearchKeyWord.Name = "txt_LocalSearchKeyWord";
            this.txt_LocalSearchKeyWord.Size = new System.Drawing.Size(219, 21);
            this.txt_LocalSearchKeyWord.TabIndex = 0;
            this.txt_LocalSearchKeyWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_LocalSearchKeyWord_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 635);
            this.Controls.Add(this.lbl_YouMaStatus);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "AVSorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_BrowerFile;
        private System.Windows.Forms.ToolStripMenuItem menu_ChangeFcode;
        private System.Windows.Forms.ToolStripMenuItem menu_remove;
        private System.Windows.Forms.Label lbl_YouMaStatus;
        private System.Windows.Forms.ToolStripMenuItem menu_BigCover;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_removeItem;
        private System.Windows.Forms.Button btn_brower;
        private System.Windows.Forms.CheckBox cb_AutoSelect;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.CheckBox cb_isCoverDownload;
        private System.Windows.Forms.Button btn_GO;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_MoveFile;
        private System.Windows.Forms.CheckBox cb_IsShowlog;
        private System.Windows.Forms.TextBox txt_Dest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sub;
        private System.Windows.Forms.Label label1;
        private AVSORTER.BasicContainer bc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_AddNewEmptyItem;
        private System.Windows.Forms.TextBox txt_EmptyItemKeyWord;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_LocalSearch;
        private System.Windows.Forms.TextBox txt_LocalSearchKeyWord;
        private MovieContainer movieContainer1;
        private System.Windows.Forms.CheckBox cb_AutoCorrect;
        private System.Windows.Forms.Button btn_rebuild;
        private System.Windows.Forms.ListBox listBox1;
    }
}

