using System;
using System.Drawing;
using System.Windows.Forms;

namespace BALFLIX
{
    public partial class filmTavsiyesiHelp : Form
    {
        public Point mouseLocation;
        public filmTavsiyesiHelp()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void filmTavsiyesiHelp_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

        private void filmTavsiyesiHelp_MouseMove(object sender, MouseEventArgs e)
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
