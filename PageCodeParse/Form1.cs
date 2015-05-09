using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gets;
using System.Threading;

namespace PageCodeParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Arzon a;
        private void btn_Start_Click(object sender, EventArgs e)
        {
            a = new Arzon(true);
            a.InitCompleted += a_InitCompleted;



        }

        void a_InitCompleted(object sender, EventArgs e)
        {
            this.lbl_status.BackColor = Color.Green;
            var ms = a.PageParse(new Uri(textBox1.Text));

            StringBuilder sb = new StringBuilder();
            foreach (AVSORTER.MovieBasic item in ms)
            {
                sb.AppendLine(item.ToString());
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
