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
    public partial class FormLabirint : Form
    {
        public FormLabirint()
        {
            InitializeComponent();
        }
        private int nrLinii = 10, nrColoane = 15, dWH;
        private int[] dl = { -1, 0, 1, 0 };
        private int[] dc = { 0, 1, 0, -1 };

        private Panel[,] labirint;
        int linCav1, colCav1;
        int linCav2, colCav2;
        int linCav3, colCav3;
        int linRege = 1, colRege = 1;

        private void FormLabirint_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (Valid(linRege, colRege + 1, pictureBox1) == 1)
                        colRege++;
                    break;
                case Keys.Left:
                    if (Valid(linRege, colRege - 1, pictureBox1) == 1)
                        colRege--;
                    break;
                case Keys.Up:
                    if (Valid(linRege - 1, colRege, pictureBox1) == 1)
                        linRege--;
                    break;
                case Keys.Down:
                    if (Valid(linRege + 1, colRege, pictureBox1) == 1)
                        linRege++;
                    break;

            }

            PlaseazaPersonaj(linRege, colRege, pictureBox1);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MutaCavaler(ref linCav1, ref colCav1, pictureBox2);
            MutaCavaler(ref linCav2, ref colCav2, pictureBox3);
            MutaCavaler(ref linCav3, ref colCav3, pictureBox4);
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
            if (linRege == 0 || colRege == 0 || linRege == nrLinii - 1 || colRege == nrColoane - 1)
            {
                MessageBox.Show("Corey a ajuns la concert!!!!");
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void pictureBox2_Move(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds == (sender as PictureBox).Bounds)
            {
                MessageBox.Show("Corey s-a certat cu membrii Limp Buizkit si nu a mai ajuns la concert!!!!");
                pictureBox1.Visible = false;
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        Random rd = new Random();

        private int Valid(int lin, int col, PictureBox personaj)
        {
            if (lin < 0 || col < 0 || lin >= nrLinii || col >= nrColoane)
                return 0;
            if (personaj.Equals(pictureBox1) == true && labirint[lin, col].BackColor != Color.Green)
                return 0;
            if (personaj.Equals(pictureBox1) == false && labirint[lin, col].BackColor == Color.Red)
                return 0;

            return 1;
        }

        private void PlaseazaPersonaj(int lin, int col, PictureBox personaj)
        {
            if (personaj.Equals(pictureBox1) == false)
                labirint[lin, col].BackColor = Color.Gold;

            personaj.Top = (lin + 1) * dWH;
            personaj.Left = (col + 1) * dWH;
        }

        private void MutaCavaler(ref int lin, ref int col, PictureBox personaj)
        {
            int linnou, colnou, dirCurr;
            dirCurr = rd.Next(4);

            linnou = lin + dl[dirCurr];
            colnou = col + dc[dirCurr];
            if (Valid(linnou, colnou, personaj) == 1)
            {
                lin = linnou;
                col = colnou;
                PlaseazaPersonaj(lin, col, personaj);
            }
        }

        private void CautLocLiber(out int lin, out int col)
        {
            do
            {
                lin = rd.Next(nrLinii);
                col = rd.Next(nrColoane);
            } while (labirint[lin, col].BackColor == Color.Red);
        }
        private void FormLabirint_Load(object sender, EventArgs e)
        {
            int i, j;
            int ocupat;

            labirint = new Panel[nrLinii, nrColoane];
            dWH = this.Width / (nrColoane + 2);
            pictureBox1.Height = dWH;
            pictureBox1.Width = dWH;
            pictureBox2.Height = dWH;
            pictureBox2.Width = dWH;
            pictureBox3.Height = dWH;
            pictureBox3.Width = dWH;
            pictureBox4.Height = dWH;
            pictureBox4.Width = dWH;

            for (i = 0; i < nrLinii; i++)
            {
                for (j = 0; j < nrColoane; j++)
                {
                    labirint[i, j] = new Panel();
                    labirint[i, j].Height = dWH;
                    labirint[i, j].Width = dWH;
                    labirint[i, j].Top = dWH * (i + 1);
                    labirint[i, j].Left = dWH * (j + 1);

                    ocupat = rd.Next(3);

                    if (ocupat == 1)
                        labirint[i, j].BackColor = Color.Red;
                    else
                        labirint[i, j].BackColor = Color.Green;

                    this.Controls.Add(labirint[i, j]);
                }
            }

            CautLocLiber(out linRege, out colRege);
            PlaseazaPersonaj(linRege, colRege, pictureBox1);

            CautLocLiber(out linCav1, out colCav1);
            PlaseazaPersonaj(linCav1, colCav1, pictureBox2);

            CautLocLiber(out linCav2, out colCav2);
            PlaseazaPersonaj(linCav2, colCav2, pictureBox3);

            CautLocLiber(out linCav3, out colCav3);
            PlaseazaPersonaj(linCav3, colCav3, pictureBox4);

            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
