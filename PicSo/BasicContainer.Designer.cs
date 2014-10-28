namespace AVSORTER
{
    partial class BasicContainer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_Maker = new System.Windows.Forms.TextBox();
            this.txt_actor = new System.Windows.Forms.TextBox();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.txt_labl = new System.Windows.Forms.TextBox();
            this.btn_ShowDetail = new System.Windows.Forms.Button();
            this.cb_ShowPic = new System.Windows.Forms.CheckBox();
            this.btn_pre = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 173);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txt_title
            // 
            this.txt_title.Enabled = false;
            this.txt_title.Location = new System.Drawing.Point(131, 3);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(273, 21);
            this.txt_title.TabIndex = 1;
            this.txt_title.Text = "title";
            this.txt_title.TextChanged += new System.EventHandler(this.txt_title_TextChanged);
            // 
            // txt_Maker
            // 
            this.txt_Maker.Enabled = false;
            this.txt_Maker.Location = new System.Drawing.Point(131, 57);
            this.txt_Maker.Name = "txt_Maker";
            this.txt_Maker.Size = new System.Drawing.Size(273, 21);
            this.txt_Maker.TabIndex = 2;
            this.txt_Maker.Text = "Maker";
            // 
            // txt_actor
            // 
            this.txt_actor.Enabled = false;
            this.txt_actor.Location = new System.Drawing.Point(131, 84);
            this.txt_actor.Name = "txt_actor";
            this.txt_actor.Size = new System.Drawing.Size(273, 21);
            this.txt_actor.TabIndex = 3;
            this.txt_actor.Text = "演员";
            // 
            // txt_URL
            // 
            this.txt_URL.Enabled = false;
            this.txt_URL.Location = new System.Drawing.Point(131, 30);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(273, 21);
            this.txt_URL.TabIndex = 4;
            this.txt_URL.Text = "URL";
            // 
            // txt_labl
            // 
            this.txt_labl.Enabled = false;
            this.txt_labl.Location = new System.Drawing.Point(131, 111);
            this.txt_labl.Name = "txt_labl";
            this.txt_labl.Size = new System.Drawing.Size(273, 21);
            this.txt_labl.TabIndex = 5;
            this.txt_labl.Text = "Label";
            // 
            // btn_ShowDetail
            // 
            this.btn_ShowDetail.Location = new System.Drawing.Point(234, 138);
            this.btn_ShowDetail.Name = "btn_ShowDetail";
            this.btn_ShowDetail.Size = new System.Drawing.Size(56, 23);
            this.btn_ShowDetail.TabIndex = 6;
            this.btn_ShowDetail.Text = "详细";
            this.btn_ShowDetail.UseVisualStyleBackColor = true;
            this.btn_ShowDetail.Click += new System.EventHandler(this.btn_ShowDetail_Click);
            // 
            // cb_ShowPic
            // 
            this.cb_ShowPic.AutoSize = true;
            this.cb_ShowPic.Location = new System.Drawing.Point(134, 138);
            this.cb_ShowPic.Name = "cb_ShowPic";
            this.cb_ShowPic.Size = new System.Drawing.Size(72, 16);
            this.cb_ShowPic.TabIndex = 7;
            this.cb_ShowPic.Text = "显示图片";
            this.cb_ShowPic.UseVisualStyleBackColor = true;
            // 
            // btn_pre
            // 
            this.btn_pre.Location = new System.Drawing.Point(296, 138);
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.Size = new System.Drawing.Size(51, 23);
            this.btn_pre.TabIndex = 22;
            this.btn_pre.Text = "上一个";
            this.btn_pre.UseVisualStyleBackColor = true;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(353, 138);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(51, 23);
            this.btn_next.TabIndex = 21;
            this.btn_next.Text = "下一个";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // BasicContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_pre);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.cb_ShowPic);
            this.Controls.Add(this.btn_ShowDetail);
            this.Controls.Add(this.txt_labl);
            this.Controls.Add(this.txt_URL);
            this.Controls.Add(this.txt_actor);
            this.Controls.Add(this.txt_Maker);
            this.Controls.Add(this.txt_title);
            this.Name = "BasicContainer";
            this.Size = new System.Drawing.Size(409, 180);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_Maker;
        private System.Windows.Forms.TextBox txt_actor;
        private System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.TextBox txt_labl;
        private System.Windows.Forms.Button btn_ShowDetail;
        private System.Windows.Forms.CheckBox cb_ShowPic;
        private System.Windows.Forms.Button btn_pre;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
