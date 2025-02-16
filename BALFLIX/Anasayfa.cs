using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BALFLIX
{
    public partial class Anasayfa : Form
    {
        public Point mouseLocation;

        loginSistemi girisSayfasi;
        filmTavsiyesiHelp filmYardimSayfasi = new filmTavsiyesiHelp();
        filmKaydetYardim kaydetYardimSayfasi = new filmKaydetYardim();
        public Anasayfa()
        {
            InitializeComponent();
            girisSayfasi = new loginSistemi(this);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void filmTavsiyesiHelpButon_Click(object sender, EventArgs e)
        {
            filmYardimSayfasi.Show();
        }

        private void filmKaydetHelpButon_Click(object sender, EventArgs e)
        {
            kaydetYardimSayfasi.Show();
        }

        private void filmTavsiyesiButon_Click(object sender, EventArgs e)
        {

            this.Hide();
            girisSayfasi.hangisi = true;
            girisSayfasi.Show();
        }

        private void filmKaydetButon_Click(object sender, EventArgs e)
        {
            this.Hide();
            girisSayfasi.hangisi = false;
            girisSayfasi.Show();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void Anasayfa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Anasayfa_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}
