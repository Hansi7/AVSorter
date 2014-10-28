using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicSo
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public string InputText { get; set; }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.InputText = this.textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                this.InputText = this.textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
