using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread threadA;
        private Thread threadB;
        private Thread threadC;
        private Thread threadD;

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart start1 = new ThreadStart(MyThreadClass.Thread1);
            ThreadStart start2 = new ThreadStart(MyThreadClass.Thread2);

            Console.WriteLine(label1.Text.ToString());

            threadA = new Thread(start1);
            threadA.Name = "Thread A Process";
            threadA.Priority = ThreadPriority.Highest;


            threadB = new Thread(start2);
            threadB.Name = "Thread B Process";
            threadB.Priority = ThreadPriority.Normal;


            threadC = new Thread(start1);
            threadC.Name = "Thread C Process";
            threadC.Priority = ThreadPriority.AboveNormal;


            threadD = new Thread(start2);
            threadD.Name = "Thread D Process";
            threadD.Priority = ThreadPriority.BelowNormal;


            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            label1.Text = "-End of Thread-";
            Console.WriteLine(label1.Text.ToString());
        }
    }
}
