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
    public partial class FormPuzzle : Form
    {
        PictureBox[,] puzzleImages = new PictureBox[3, 3];
        int[] numereOcupate = new int[10];

        public FormPuzzle()
        {
            InitializeComponent();
        }

        private void FormPuzzle_Load(object sender, EventArgs e)
        {
            int laturaH, laturaW, numar, i, j;

            laturaH = this.Height / 6;
            laturaW = this.Width / 6;

            for (i = 0; i < 10; i++)
                numereOcupate[i] = 0;

            Random random = new Random();

            for ( i = 0; i < 3; i++ )
                for ( j = 0; j < 3; j++ )
                {
                    puzzleImages[i, j] = new PictureBox();
                    puzzleImages[i, j].Width = laturaW;
                    puzzleImages[i, j].Height = laturaH;
                    puzzleImages[i, j].Left = laturaW * (j + 1);
                    puzzleImages[i, j].Top = laturaH * (i + 1);
                    puzzleImages[i, j].BackColor = Color.Red;
                    puzzleImages[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    do
                    {
                        numar = random.Next(0, 9);
                    } while (numereOcupate[numar] != 0);
                    numereOcupate[numar] = 1;

                    puzzleImages[i, j].Text = Convert.ToString(numar);
                    puzzleImages[i, j].Click += new EventHandler(puzzlePictureBox_Click);
                    puzzleImages[i, j].Load("Resurse\\Puzzle\\" + Convert.ToString(numar) + ".jpg");

                    this.Controls.Add(puzzleImages[i, j]);
                }
        }

        private void Vecin( int i, int j, out int iv, out int jv)
        {
            iv = i; jv = j;
            if (i > 0 && puzzleImages[i - 1, j].Text == "0")
                iv = i - 1;
            if (i < 2 && puzzleImages[i + 1, j].Text == "0")
                iv = i + 1;
            if (j > 0 && puzzleImages[i, j - 1].Text == "0")
                jv = j - 1;
            if (j < 2 && puzzleImages[i, j + 1].Text == "0")
                jv = j + 1;
        }

        private void Interschimba( int i1, int j1, int i2, int j2 )
        {
            string aux;
            aux = puzzleImages[i1, j1].Text;
            puzzleImages[i1, j1].Text = puzzleImages[i2, j2].Text;
            puzzleImages[i1, j1].Load("Resurse\\Puzzle\\" + puzzleImages[i1, j1].Text + ".jpg");
            puzzleImages[i2, j2].Text = aux;
            puzzleImages[i2, j2].Load("Resurse\\Puzzle\\" + puzzleImages[i2, j2].Text + ".jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numar = 0;
            bool ok = true;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (puzzleImages[i, j].Text != Convert.ToString(numar))
                        ok = false;
                    else
                        numar++;

            if (ok)
                MessageBox.Show("Felicitari!");
            else
                MessageBox.Show("Puzzle-ul nu este facut!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void puzzlePictureBox_Click( object sender, EventArgs e)
        {
            int iSender = 0, jSender = 0;
            int iVecinSender, jVecinSender;
            if ((sender as PictureBox).Text == "0")
                MessageBox.Show("Nu se poate muta patratul gol!");
            else
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if ((sender as PictureBox) == puzzleImages[i, j])
                        {
                            iSender = i;
                            jSender = j;
                        }

            Vecin(iSender, jSender, out iVecinSender, out jVecinSender);
            Interschimba(iSender, jSender, iVecinSender, jVecinSender);
        }
    }
}
