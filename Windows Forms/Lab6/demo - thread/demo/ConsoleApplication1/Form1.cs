using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        delegate void MyDelegate();

        int value;
        Thread thr;
        private void setProgress()
        {
            progressBar1.Value = value;
        }
        private void updateProgress()
        {
            while (true)
            {
                value++;
                if (value == 100)
                    value = 0;
                this.Invoke(new MyDelegate(setProgress), null);
                // fail (only the original thread can modify GUI)
                setProgress();
                Thread.Sleep(100);
            }
        }
        public Form1()
        {
            InitializeComponent();

            thr = new Thread(updateProgress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thr.ThreadState == ThreadState.Unstarted)
                thr.Start();
        }
    }
}
