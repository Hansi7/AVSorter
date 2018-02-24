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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_brower = new System.Windows.Forms.Button();
            this.btn_AddNewEmptyItem = new System.Windows.Forms.Button();
            this.btn_removeItem = new System.Windows.Forms.Button();
            this.btn_paste_new = new System.Windows.Forms.Button();
            this.btn_MoveFile = new System.Windows.Forms.Button();
            this.lbl_Path_preview = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Dest = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sub = new System.Windows.Forms.TextBox();
            this.cb_IsShowlog = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cb_AutoCorrect = new System.Windows.Forms.CheckBox();
            this.btn_LocalSearch = new System.Windows.Forms.Button();
            this.txt_LocalSearchKeyWord = new System.Windows.Forms.TextBox();
            this.cmenu_p4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenu_p4_item_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sl_Network = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.movieContainer1 = new PicSo.MovieContainer();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cmenu_p4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 569);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "批量文件处理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clear, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_brower, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_AddNewEmptyItem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_removeItem, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_paste_new, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_MoveFile, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cb_IsShowlog, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Path_preview, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 563);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 6);
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(911, 342);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(208)))), ((int)(((byte)(243)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.button1.Location = new System.Drawing.Point(763, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(151, 74);
            this.button1.TabIndex = 21;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(221)))), ((int)(((byte)(254)))));
            this.btn_Clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_Clear.Location = new System.Drawing.Point(611, 43);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(146, 34);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "清除全部";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_brower
            // 
            this.btn_brower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btn_brower, 2);
            this.btn_brower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_brower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_brower.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_brower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_brower.Location = new System.Drawing.Point(3, 3);
            this.btn_brower.Name = "btn_brower";
            this.btn_brower.Size = new System.Drawing.Size(298, 34);
            this.btn_brower.TabIndex = 3;
            this.btn_brower.Text = "浏览文件夹...";
            this.btn_brower.UseVisualStyleBackColor = false;
            this.btn_brower.Click += new System.EventHandler(this.btn_brower_Click);
            // 
            // btn_AddNewEmptyItem
            // 
            this.btn_AddNewEmptyItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.btn_AddNewEmptyItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AddNewEmptyItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewEmptyItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddNewEmptyItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_AddNewEmptyItem.Location = new System.Drawing.Point(3, 43);
            this.btn_AddNewEmptyItem.Name = "btn_AddNewEmptyItem";
            this.btn_AddNewEmptyItem.Size = new System.Drawing.Size(146, 34);
            this.btn_AddNewEmptyItem.TabIndex = 19;
            this.btn_AddNewEmptyItem.Text = "新建空项目";
            this.btn_AddNewEmptyItem.UseVisualStyleBackColor = false;
            this.btn_AddNewEmptyItem.Click += new System.EventHandler(this.btn_AddNewEmptyItem_Click);
            // 
            // btn_removeItem
            // 
            this.btn_removeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(221)))), ((int)(((byte)(254)))));
            this.btn_removeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_removeItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removeItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_removeItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_removeItem.Location = new System.Drawing.Point(611, 3);
            this.btn_removeItem.Name = "btn_removeItem";
            this.btn_removeItem.Size = new System.Drawing.Size(146, 34);
            this.btn_removeItem.TabIndex = 4;
            this.btn_removeItem.Text = "删除选择项目";
            this.btn_removeItem.UseVisualStyleBackColor = false;
            this.btn_removeItem.Click += new System.EventHandler(this.btn_removeItem_Click);
            // 
            // btn_paste_new
            // 
            this.btn_paste_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.btn_paste_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_paste_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_paste_new.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_paste_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_paste_new.Location = new System.Drawing.Point(155, 43);
            this.btn_paste_new.Name = "btn_paste_new";
            this.btn_paste_new.Size = new System.Drawing.Size(146, 34);
            this.btn_paste_new.TabIndex = 20;
            this.btn_paste_new.Text = "剪贴板新建";
            this.btn_paste_new.UseVisualStyleBackColor = false;
            this.btn_paste_new.Click += new System.EventHandler(this.btn_paste_new_Click);
            // 
            // btn_MoveFile
            // 
            this.btn_MoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.btn_MoveFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MoveFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.btn_MoveFile.Location = new System.Drawing.Point(763, 431);
            this.btn_MoveFile.Name = "btn_MoveFile";
            this.tableLayoutPanel1.SetRowSpan(this.btn_MoveFile, 2);
            this.btn_MoveFile.Size = new System.Drawing.Size(151, 54);
            this.btn_MoveFile.TabIndex = 25;
            this.btn_MoveFile.Text = "移动文件";
            this.btn_MoveFile.UseVisualStyleBackColor = false;
            this.btn_MoveFile.Click += new System.EventHandler(this.btn_MoveFile_Click);
            // 
            // lbl_Path_preview
            // 
            this.lbl_Path_preview.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_Path_preview, 6);
            this.lbl_Path_preview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Path_preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.lbl_Path_preview.Location = new System.Drawing.Point(3, 528);
            this.lbl_Path_preview.Name = "lbl_Path_preview";
            this.lbl_Path_preview.Size = new System.Drawing.Size(164, 17);
            this.lbl_Path_preview.TabIndex = 13;
            this.lbl_Path_preview.Text = "【点列表条目预览目标路径】";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Dest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 24);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "目标路径";
            // 
            // txt_Dest
            // 
            this.txt_Dest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Dest.Location = new System.Drawing.Point(62, 0);
            this.txt_Dest.Name = "txt_Dest";
            this.txt_Dest.Size = new System.Drawing.Size(497, 23);
            this.txt_Dest.TabIndex = 9;
            this.txt_Dest.Leave += new System.EventHandler(this.txt_Dest_Leave);
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_sub);
            this.panel2.Location = new System.Drawing.Point(3, 461);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 24);
            this.panel2.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "分类路径";
            // 
            // txt_sub
            // 
            this.txt_sub.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sub.Location = new System.Drawing.Point(62, 0);
            this.txt_sub.Name = "txt_sub";
            this.txt_sub.Size = new System.Drawing.Size(497, 23);
            this.txt_sub.TabIndex = 8;
            this.txt_sub.Text = "演员\\[番号]标题";
            this.txt_sub.Leave += new System.EventHandler(this.txt_sub_Leave);
            // 
            // cb_IsShowlog
            // 
            this.cb_IsShowlog.AutoSize = true;
            this.cb_IsShowlog.Checked = true;
            this.cb_IsShowlog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsShowlog.Dock = System.Windows.Forms.DockStyle.Right;
            this.cb_IsShowlog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_IsShowlog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.cb_IsShowlog.Location = new System.Drawing.Point(646, 431);
            this.cb_IsShowlog.Name = "cb_IsShowlog";
            this.tableLayoutPanel1.SetRowSpan(this.cb_IsShowlog, 2);
            this.cb_IsShowlog.Size = new System.Drawing.Size(111, 54);
            this.cb_IsShowlog.TabIndex = 18;
            this.cb_IsShowlog.Text = "完成后显示日志";
            this.cb_IsShowlog.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 599);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.movieContainer1);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.cb_AutoCorrect);
            this.tabPage2.Controls.Add(this.btn_LocalSearch);
            this.tabPage2.Controls.Add(this.txt_LocalSearchKeyWord);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 569);
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
            this.listBox1.Size = new System.Drawing.Size(913, 112);
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
            // cmenu_p4
            // 
            this.cmenu_p4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenu_p4_item_copy});
            this.cmenu_p4.Name = "cmenu_p4";
            this.cmenu_p4.Size = new System.Drawing.Size(125, 26);
            // 
            // cmenu_p4_item_copy
            // 
            this.cmenu_p4_item_copy.Name = "cmenu_p4_item_copy";
            this.cmenu_p4_item_copy.Size = new System.Drawing.Size(124, 22);
            this.cmenu_p4_item_copy.Text = "复制地址";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_Network});
            this.statusStrip1.Location = new System.Drawing.Point(0, 577);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sl_Network
            // 
            this.sl_Network.BackColor = System.Drawing.Color.Crimson;
            this.sl_Network.Name = "sl_Network";
            this.sl_Network.Size = new System.Drawing.Size(68, 17);
            this.sl_Network.Text = "网络不可用";
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 14);
            this.panel3.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label3.Location = new System.Drawing.Point(93, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "番号";
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label4.Location = new System.Drawing.Point(155, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "演员";
            this.label4.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label5.Location = new System.Drawing.Point(217, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "标题";
            this.label5.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label6.Location = new System.Drawing.Point(279, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "厂商";
            this.label6.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label7.Location = new System.Drawing.Point(341, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "标签";
            this.label7.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label8.Location = new System.Drawing.Point(403, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "制造商";
            this.label8.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "双设计路径-->";
            // 
            // movieContainer1
            // 
            this.movieContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.movieContainer1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.movieContainer1.IsShowOtherButton = false;
            this.movieContainer1.Location = new System.Drawing.Point(8, 168);
            this.movieContainer1.Movie = null;
            this.movieContainer1.MovieList = null;
            this.movieContainer1.Name = "movieContainer1";
            this.movieContainer1.Size = new System.Drawing.Size(911, 438);
            this.movieContainer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 599);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AVSorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.cmenu_p4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_BrowerFile;
        private System.Windows.Forms.ToolStripMenuItem menu_ChangeFcode;
        private System.Windows.Forms.ToolStripMenuItem menu_remove;
        private System.Windows.Forms.ToolStripMenuItem menu_BigCover;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_removeItem;
        private System.Windows.Forms.Button btn_brower;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_MoveFile;
        private System.Windows.Forms.CheckBox cb_IsShowlog;
        private System.Windows.Forms.TextBox txt_Dest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_AddNewEmptyItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_LocalSearch;
        private System.Windows.Forms.TextBox txt_LocalSearchKeyWord;
        private System.Windows.Forms.CheckBox cb_AutoCorrect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip cmenu_p4;
        private System.Windows.Forms.ToolStripMenuItem cmenu_p4_item_copy;
        private System.Windows.Forms.Button btn_paste_new;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Path_preview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sl_Network;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MovieContainer movieContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

