using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long CountCharecters()
        {
            long count = 0;
            
            using(StreamReader reader=new StreamReader("E:\\Practice\\Async.txt"))
            {
                String content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Task<long> task = new Task<long>(CountCharecters);
            task.Start();
            lblMsg.Text = "Processing file. Please wait..";
            long c = await task;
            lblMsg.Text = "There are " + c.ToString() + " charecters in the file."; 
        }
    }
}
