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
    public partial class FormAlbum : Form
    {
        int imgCrt = 0, nrImg = 27;
        public FormAlbum()
        {
            InitializeComponent();
        }

        private void FormAlbum_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("Resurse\\Album Foto\\" + Convert.ToString(imgCrt) + ".jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imgCrt++;
            if (imgCrt > nrImg)
                imgCrt = 0;

            pictureBox1.Load("Resurse\\Album Foto\\" + Convert.ToString(imgCrt) + ".jpg");
            richTextBox1.LoadFile("Resurse\\Album Foto\\" + Convert.ToString(imgCrt) +".rtf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgCrt--;
            if (imgCrt < 0)
                imgCrt = nrImg;

            pictureBox1.Load("Resurse\\Album Foto\\" + Convert.ToString(imgCrt) + ".jpg");
            richTextBox1.LoadFile("Resurse\\Album Foto\\" + Convert.ToString(imgCrt) +".rtf");
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
