using AkbilYntmVeriKatmani;
using AkbilYntmIsKatmani;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

namespace AkbilYonetimiUI
{
    public partial class Form1 : Form
    {
        public string Email { get; set; }//kay�tol fromunda kay�t olan kullan�c�n�n emaili buraya gelsin

        IVeriTabaniIslemleri veriTabaniIslemleri = new SQLVeriTabaniIslemleri();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Email != null)
            {
                txtEmail.Text = Email;
            }


            txtEmail.TabIndex = 1;
            txtSifre.TabIndex = 2;
            checkBoxHatirla.TabIndex = 3;
            btnGirisYap.TabIndex = 4;
            btnKayitOl.TabIndex = 5;
            txtSifre.PasswordChar = '*';

            //beni hatirla

            txtEmail.Text = "yarenp";
            txtSifre.Text = "yp";




        }



        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            //bu formu gizleyece�iz
            //kay�t ol formu a�aca��z
            this.Hide();
            FrmKayitOl frm = new FrmKayitOl();
            frm.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            try
            {
                //1) Email ve �ifre textboxlar� dolu mu?
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("bilgileri eksiksiz giriniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                //2) Girdi�i email ve �ifre veritaban�nda mevcut mu?
                //select*from kullan�c�lar where email='' and sifre=''

                string[] istedigimKolonlar = new string[] { "Id", "Ad", "Soyad" };
                string kosullar = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append($"Email='{txtEmail.Text.Trim()}'");
                sb.Append(" and ");
                sb.Append($"Parola='{GenelIslemler.MD5Encryption(txtSifre.Text.Trim())}'");
                kosullar = sb.ToString();

                var sonuc = veriTabaniIslemleri.VeriOku("Kullanicilar", istedigimKolonlar, kosullar);

                if (sonuc.Count == 0)
                {
                    MessageBox.Show("Email. ya da �ifre yanl�� tekrar deneyiniz");
                }
                else
                {
                    GenelIslemler.GirisYapanKullaniciID = (int)sonuc["Id"];
                    GenelIslemler.GirisYapanKullaniciAdSoyad = $"{sonuc["Ad"]} {sonuc["Soyad"]}";
                    MessageBox.Show($"Ho�geldiniz... {GenelIslemler.GirisYapanKullaniciAdSoyad}");

                    //Beni Hat�rla
                    this.Hide();
                    FrmAnasayfa frmAnasayfa = new FrmAnasayfa();
                    frmAnasayfa.Show();


                }


            }
            catch (Exception hata)
            {
                //dipnot excepti�nlar asla kullan�c�ya g�sterilmez
                //exceptionlar loglan�r. biz �u an ��renme/geli�tirme a�ams�nda oldu�umuz i�in yazd�k.
                MessageBox.Show("beklenmedik bir sorun olu�tu!" + hata.Message);

            }
        }

        private void checkBoxHatirla_CheckedChanged(object sender, EventArgs e)
        {
            BeniHatirlaAyarla();

        }
        private void BeniHatirlaAyarla()
        {

        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))//bas�lan tu� enter ise giri� yapacak
            {
                GirisYap();
            }
        }

        private void checkBoxHatirla_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}