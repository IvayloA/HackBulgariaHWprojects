using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private volatile int APMCounter;
        private  double result;
        private Stopwatch watch = new Stopwatch();

        private void button1_Click(object sender, EventArgs e)
        {
            Object objct1 = new Object();
            lock (objct1)
            {
                APMCounter++;
            }
           
        }

        public void APMCalculator()
        {
           
            Object objct2 = new Object();
            while (true)
            {
                lock (objct2)
                {
                    result = APMCounter / watch.Elapsed.TotalMinutes;
                }
                Thread.Sleep(1500);

                BeginInvoke((Action)delegate()
                {
                    ResultCaller();
                });
            }

        }

        private void ResultCaller()
        {
            label1.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch.Start();

            Thread thread = new Thread(APMCalculator);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
