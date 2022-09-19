using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minimarket
{
    public partial class splashForm1 : Form
    {
        public splashForm1()
        {
            InitializeComponent();
        }

        private void splashForm1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            startpoint += 2;
            CircleProgressBar.Value = startpoint;
            if(CircleProgressBar.Value==100)
            {
                CircleProgressBar.Value = 0;
                timer1.Stop();
                loginForm1 loginForm = new loginForm1();
                this.Hide();
                loginForm.Show();
            }
        }
    }
}
