using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProiectNic
{

    public partial class FormGrila : Form
    {
        public int nrIntrebari, nrRaspunsuriCorecte;
        private StreamReader reader = new StreamReader("Resurse\\TestGrila\\Intrebari.txt");
        public FormGrila()
        {
            InitializeComponent();
        }

        private void FormGrila_Load(object sender, EventArgs e)
        {
            nrIntrebari = Convert.ToInt32(reader.ReadLine());
            CitesteIntrebare();
            nrIntrebari--;
            nrRaspunsuriCorecte = 0;
        }



        public void CitesteIntrebare()
        {
            groupBox1.Text = reader.ReadLine();
            radioButton1.Text = reader.ReadLine();
            radioButton1.Tag = reader.ReadLine();
            radioButton2.Text = reader.ReadLine();
            radioButton2.Tag = reader.ReadLine();
            radioButton3.Text = reader.ReadLine();
            radioButton3.Tag = reader.ReadLine();
        }

        public int VerificareIntrebare()
        {
            if (radioButton1.Checked == true && radioButton1.Tag.Equals("1"))
                return 1;
            if (radioButton2.Checked == true && radioButton2.Tag.Equals("1"))
                return 1;
            if (radioButton3.Checked == true && radioButton3.Tag.Equals("1"))
                return 1;
            return 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificareIntrebare() == 1)
                nrRaspunsuriCorecte++;
            if (nrIntrebari > 0)
            {
                CitesteIntrebare();
                nrIntrebari--;
            }
            else
            {
                MessageBox.Show("You answerd correctly at " + nrRaspunsuriCorecte + " questions!");
                this.Close();
            }
        }
    }
}
