using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BALFLIX
{
    public partial class loginSistemi : Form
    {
        public static FirebaseClient firebaseClient;
        public Point mouseLocation;
        Anasayfa anaEkran;
        public static string username;
        public static string password;
        public bool hangisi { get; set; }
        FilmTavsiyesi filmTavsiyeEkrani = new FilmTavsiyesi();
        Kaydedilen kaydedilenFilm = new Kaydedilen();
        private string firebaseDatabaseUrl = //programın çalışması için firebase url nizi giriniz;

        public loginSistemi(Anasayfa anaEkranForm)
        {
            InitializeComponent();
            anaEkran = anaEkranForm;

            firebaseClient = new FirebaseClient(firebaseDatabaseUrl,
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult("src"),
                JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings { }
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            anaEkran.Show();
        }

        private async void girisYapButonu_Click(object sender, EventArgs e)
        {
            username = girisUsername.Text;
            password = girisPassword.Text;

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurun.");
                    return;
                }

                var result = await firebaseClient.Child("users")
                                                  .OrderBy("Username")
                                                  .EqualTo(username)
                                                  .OnceAsync<User>();

                bool userFound = false;

                foreach (var user in result)
                {
                    if (user.Object.Password == password)
                    {
                        userFound = true;
                        break;
                    }
                }

                if (userFound)
                {
                    if (hangisi == true)
                    {
                        this.Hide();
                        filmTavsiyeEkrani.Show();
                    } if (hangisi == false)
                    {
                        this.Hide();
                        kaydedilenFilm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Giriş başarısız. Kullanıcı adı veya şifre hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private async void registerButton_Click_1(object sender, EventArgs e)
        {
            string username = registerUsername.Text;
            string password = registerPassword.Text;

         

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Lütfen bütün boşlukları doldurunuz.");
                    return;
                }

                var existingUser = await firebaseClient.Child("users").Child(username).OnceSingleAsync<User>();
                if (existingUser != null)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kullanımda. Lütfen farklı bir kullanıcı adı seçin.");
                    return;
                }

                var result = await firebaseClient.Child("users").PostAsync(new { Username = username, Password = password });

                if (result.Object != null)
                {
                    MessageBox.Show("Kullanıcı başarıyla kaydedildi.");
                    gecisSayfalari.SelectedTab = loginPage;
                    registerUsername.Text = "";
                    registerPassword.Text = "";
                    girisUsername.Text = "";
                    girisPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerUsername.Text = "";
            registerPassword.Text = "";
            girisUsername.Text = "";
            girisPassword.Text = "";
            gecisSayfalari.SelectedTab = registerPage;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void hesabimVar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gecisSayfalari.SelectedTab = loginPage;
            girisUsername.Text = "";
            girisPassword.Text = "";
            registerUsername.Text = "";
            registerPassword.Text = "";
        }

        private void loginSistemi_MouseDown(object sender, MouseEventArgs e)
        {

            mouseLocation = new Point(-e.X, -e.Y);


        }

        private void loginSistemi_MouseMove(object sender, MouseEventArgs e)
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
