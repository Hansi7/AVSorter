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
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(textBox1.Text);

            var nodes = doc.DocumentNode.SelectNodes("//span[@class='subbox']/span[1]");
            textBox1.Text = "";
            foreach (var item in nodes)
            {
                textBox1.AppendText("\"" + item.InnerText.ToLower() + "\",\r\n");
            }





            Console.WriteLine();


            
        }
    }
}
