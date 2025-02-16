using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace BALFLIX
{

    public partial class Kaydedilen : Form
    {
        public string detay = "";
        public Point mouseLocation;
        public Kaydedilen()
        {

            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async Task GetSavedFilmsAsync(string username)
        {
            try
            {
                var dataSnapshot = await loginSistemi.firebaseClient
                    .Child("users")
                    .Child(username)
                    .Child("savedFilms")
                    .OnceAsync<SavedFilm>();

                filmlerView.Rows.Clear();

                foreach (var data in dataSnapshot)
                {
                    var film = data.Object;
                    filmlerView.Rows.Add(film.FilmAdi, film.IMDBSkoru, film.Detay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        private async void filmGetir_Click(object sender, EventArgs e)
        {
            await GetSavedFilmsAsync(loginSistemi.username);
        }

        private void Kaydedilen_Load_1(object sender, EventArgs e)
        {
            filmlerView.ReadOnly = true;
            filmlerView.ColumnCount = 3;
            filmlerView.Columns[0].Name = "Film Adı";
            filmlerView.Columns[1].Name = "IMDB";
            filmlerView.Columns[2].Name = "Detay";
            filmlerView.ScrollBars = ScrollBars.Both;
            filmlerView.AllowUserToAddRows = false;


            filmlerView.DefaultCellStyle.BackColor = Color.LightGray;
            filmlerView.DefaultCellStyle.ForeColor = Color.Black;
            filmlerView.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            filmlerView.DefaultCellStyle.SelectionForeColor = Color.White;


            filmlerView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            filmlerView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            filmlerView.RowTemplate.Height = 40;


            filmlerView.RowsDefaultCellStyle.BackColor = Color.White;
            filmlerView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;


            filmlerView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            filmlerView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private async void filmiSil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soldaki oku kullanarak secip silme işlemi yapınız.");
            if (filmlerView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz filmi seçin.");
                return;
            }

            string filmAdi = filmlerView.SelectedRows[0].Cells[0].Value.ToString();
            string username = loginSistemi.username;

            try
            {
                var dataSnapshot = await loginSistemi.firebaseClient
                    .Child("users")
                    .Child(username)
                    .Child("savedFilms")
                    .OnceAsync<SavedFilm>();

                foreach (var data in dataSnapshot)
                {
                    if (data.Object.FilmAdi == filmAdi)
                    {
                        await loginSistemi.firebaseClient
                            .Child("users")
                            .Child(username)
                            .Child("savedFilms")
                            .Child(data.Key)
                            .DeleteAsync();

                        filmlerView.Rows.Remove(filmlerView.SelectedRows[0]);
                        MessageBox.Show("Film başarıyla silindi.");
                        return;
                    }
                }

                MessageBox.Show("Silmek istediğiniz film bulunamadı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }



        private void Kaydedilen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);


        }

        private void Kaydedilen_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Anasayfa anasayfaForm = new Anasayfa();


            this.Hide();


            anasayfaForm.Show();
        }


        private void filmlerView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = filmlerView.Rows[e.RowIndex];
            string filmAdi = row.Cells["Film Adı"].Value.ToString();
            string imdbPuani = row.Cells["IMDB"].Value.ToString();

            if (e.RowIndex >= 0 &&row.Cells["Detay"].Value == null)
            {
                detay = "Film detayi secmediniz.";
                MessageBox.Show($"Film Adı {filmAdi}\nIMDB Puanı : {imdbPuani}\nFilm Detayı: {detay}");
            }
            else if (e.RowIndex >= 0 &&row.Cells["Detay"].Value != null)
            {
                string detay = row.Cells["Detay"].Value.ToString();
                MessageBox.Show($"Film Adı {filmAdi}\nIMDB Puanı : {imdbPuani}\nFilm Detayı: {detay}");
            }

        }

        public class SavedFilm
        {
            public string FilmAdi { get; set; }
            public string IMDBSkoru { get; set; }
            public string Detay { get; set; }
        }
    }

}
