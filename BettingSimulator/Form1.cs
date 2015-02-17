using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            // Use the below line to disable controls when race is started.
            //bettingParlorGroupBox.Enabled = false;
        }

        private void betButton_Click(object sender, EventArgs e)
        {

        }

        private void betNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dogNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
