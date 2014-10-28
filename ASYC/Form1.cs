using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ASYC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gets.Arzon a = new Gets.Arzon(true);
            a.InitCompleted += a_InitCompleted;
            MessageBox.Show("Wait OK ");
            var ms = a.Query(textBox2.Text);
            a.GetMovie(ms[0]);
            MessageBox.Show("Get Movie!");
        }

        void a_InitCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("init OK!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
