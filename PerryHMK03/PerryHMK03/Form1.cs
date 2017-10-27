using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerryHMK03
{
    public partial class Form1 : Form
    {
        int count = 1;

        public Form1()
        {
            InitializeComponent();
            
            foreach(Control Ctrl in Controls)
            {
                if (Ctrl is Button)
                {
                    (Ctrl as Button).Click += Button_Click;
                }
            }
        }

        private void PressMe_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void PressMe_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = Color.DodgerBlue;
        }

        private void ClickMe_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            label1.Text = $"Clicks counted: {count++}";
        }
    }
}
