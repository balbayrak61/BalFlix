using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Firebase.Database;
using Firebase.Database.Query;
using HtmlAgilityPack;

namespace BALFLIX
{
    public partial class FilmTavsiyesi : Form
    {
        public Point mouseLocation;
        FilmListesi listeFilmler = new FilmListesi();
        public FilmTavsiyesi()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FilmTavsiyesi_Load(object sender, EventArgs e)
        {
            hosgeldinUser.Text = "Hosgeldin " + loginSistemi.username;

            donenBilgiler.ColumnCount = 3;
            donenBilgiler.Columns[0].Name = "Film Adı";
            donenBilgiler.Columns[1].Name = "IMDB";
            donenBilgiler.ScrollBars = ScrollBars.Both;

            donenBilgiler.AllowUserToAddRows = false;

            donenBilgiler.RowPrePaint += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && ev.RowIndex < donenBilgiler.Rows.Count)
                {
                    donenBilgiler.Rows[ev.RowIndex].Cells[2].Style.Padding = new Padding(0); 
                    donenBilgiler.Rows[ev.RowIndex].Cells[2].Style.ForeColor = donenBilgiler.DefaultCellStyle.BackColor; 
                }
            };
        }



        private async void taramaBasla_Click(object sender, EventArgs e)
        {
            donenBilgiler.Rows.Clear();
            string filmTurumuz = filminTuru.Text;
            string imdbPuanimiz = imdbPuani.Text;


            string url = $"https://www.imdb.com/search/title/?user_rating={imdbPuanimiz},{imdbPuanimiz+1},&genres={filmTurumuz}";
            string htmlContent = await GetHtmlAsync(url);

            if (!string.IsNullOrEmpty(htmlContent))
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);
                if(detayliKontrol.Checked)
                {
                    MessageBox.Show("Detaylara ulasmak icin ilgili filme çift tıklayınız.","BALFLIX");
                }

                var movieNodes = doc.DocumentNode.SelectNodes("//h3[@class='ipc-title__text']");
                var svgNodes = doc.DocumentNode.SelectNodes("//svg[@class='ipc-icon ipc-icon--star-inline']");
                var detailDivs = doc.DocumentNode.SelectNodes("//div[@class='ipc-html-content-inner-div']");

                if (movieNodes != null && svgNodes != null)
                {
                    int count = 0;
                    for (int i = 0; i < Math.Min(movieNodes.Count, svgNodes.Count) && count < 10; i++)
                    {
                        string filmAdi = movieNodes[i].InnerText.Trim();
                        string imdbPuani = svgNodes[i].NextSibling.InnerText.Trim().Replace("\n", "");

                        donenBilgiler.Rows.Add(filmAdi, imdbPuani);

                        if (detayliKontrol.Checked && detailDivs != null && i < detailDivs.Count)
                        {
                            string detay = detailDivs[i].InnerText.Trim();
                            donenBilgiler.Rows[i].Cells[2].Value = detay;
                            donenBilgiler.Rows[i].Cells[2].Style.ForeColor = donenBilgiler.DefaultCellStyle.BackColor; 
                        }

                        count++;
                    }
                  
                    donenBilgiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Filmler bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("HTML içeriği alınamadı.");
            }
        }


        private async Task<string> GetHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
        }


        private async void filmiKaydet_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow selectedRow = donenBilgiler.SelectedRows[0];

            if (selectedRow != null)
            {
                try
                {
                    string filmAdi = selectedRow.Cells[0].Value?.ToString();
                    string imdbSkoru = selectedRow.Cells[1].Value?.ToString();
                    string detay = selectedRow.Cells[2].Value?.ToString();

                    await loginSistemi.firebaseClient
                        .Child("users")
                        .Child(loginSistemi.username)
                        .Child("savedFilms")
                        .PostAsync(new { FilmAdi = filmAdi, IMDBSkoru = imdbSkoru, Detay = detay });

                    MessageBox.Show("Film başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Film kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek film seçilmedi.");
            }
        }

        private void donenBilgiler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < donenBilgiler.Rows.Count)
            {
                DataGridViewRow selectedRow = donenBilgiler.Rows[e.RowIndex];
                string filmAdi = selectedRow.Cells[0].Value?.ToString();
                string detay = selectedRow.Cells[2].Value?.ToString();

                if (!string.IsNullOrEmpty(filmAdi) && !string.IsNullOrEmpty(detay))
                {
                    MessageBox.Show(detay, filmAdi);
                }
            }
        }

        private void filmListesi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen aynı türlerde gözüktüğü gibi ingilizce yazınız.");
            listeFilmler.Show();
        }

        private void FilmTavsiyesi_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void FilmTavsiyesi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfaForm = new Anasayfa();


            this.Hide();


            anasayfaForm.Show();
        }
    }
}
