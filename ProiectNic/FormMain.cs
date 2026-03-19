using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectNic
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInformare f = new FormInformare();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTestare f = new FormTestare();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRelaxare f = new FormRelaxare();
            f.ShowDialog();
        }
    }
}
