using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class ProgressBar
    {
        [STAThread]
        public static void Main()
        {
            ConsoleApplication1.Form1 aform = new Form1();
            Application.EnableVisualStyles();
            Application.Run(aform);
        }
    }
}
