using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PicSo
{
    public class ListViewColumnSorter:IComparer
    {
        public int ColumnIndex { get; set; }
        bool isAsc = true;
        public ListViewColumnSorter()
        {
            this.ColumnIndex = 0;
        }
        public ListViewColumnSorter(int columnIndex,bool Asc)
        {
            this.ColumnIndex = columnIndex;
            this.isAsc = Asc;
        }

        public int Compare(object x, object y)
        {
            var k = (x as System.Windows.Forms.ListViewItem).SubItems[ColumnIndex].Text.CompareTo((y as System.Windows.Forms.ListViewItem).SubItems[ColumnIndex].Text);
            if (isAsc)
            {
                return k;
            }
            else
            {
                return -k;
            }
        }
    }
}
