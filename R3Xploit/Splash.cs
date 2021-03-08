using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3Xploit
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
           
            if (panel2.Width >= 581)
            {
                timer1.Stop();
                R3Xploit f1 = new R3Xploit();
                f1.Show();
                this.Hide();
            }
        }
    }
}
