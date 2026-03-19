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
    public partial class FormNomenclator : Form
    {
        public FormNomenclator()
        {
            InitializeComponent();
        }

        private void FormNomenclator_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ok = 1;
            foreach (Control x in this.Controls)
            {
                if ( x is ComboBox )
                {
                    ComboBox c = (ComboBox)x;
                    if (!c.Text.Equals(c.Tag))
                        ok = 0;
                }
            }

            if (ok == 1)
                MessageBox.Show("Felicitari!");
            else
                MessageBox.Show("Mai incearca");
        }
    }
}
