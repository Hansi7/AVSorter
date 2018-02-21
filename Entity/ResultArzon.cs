using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVSORTER
{
    public class ResultArzon
    {
        public string Code { get; set; }
        public Movie Movie { get; set; }
        public string Status { get; set; }


        private QStatus _qstatus;

        public QStatus QStatus
        {
            get { return _qstatus; }
            set { _qstatus = value;
                Console.WriteLine(_qstatus.ToString());
            }
        }





    }
}
