using AkbilYntmIsKatmani;
using AkbilYntmVeriKatmani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkbilYonetimiUI
{
    public partial class FrmKayitOl : Form
    {
        IVeriTabaniIslemleri veriTabaniIslemleri = new SQLVeriTabaniIslemleri(GenelIslemler.SinifSQLBaglantiCumlesi);


        public FrmKayitOl()
        {
            InitializeComponent();
        }

        private void FrmKayitOl_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MaxDate = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Value = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox && string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        MessageBox.Show("zorunlu alanları doldurunuz");
                        return;

                    }

                }
                Dictionary<string, object> kolonlar = new Dictionary<string, object>();
                kolonlar.Add("Ad", $"'{txtIsim.Text.ToUpper().Trim()}'");
                kolonlar.Add("Soyad", $"'{txtSoyisim.Text.ToUpper().Trim()}'");
                kolonlar.Add("Email", $"'{txtEmail.Text.Trim()}'");
                kolonlar.Add("EklenmeTarihi", $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'");
                kolonlar.Add("DogumTarihi", $"'{dtpDogumTarihi.Value.ToString("yyyyMMdd")}'");
                kolonlar.Add("Parola", $"'{GenelIslemler.MD5Encryption(txtSifre.Text.Trim())}'");

                string insertCumle = veriTabaniIslemleri.VeriEklemeCumlesiOlustur("Kullanicilar", kolonlar);
                int sonuc = veriTabaniIslemleri.KomutIsle(insertCumle);
                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt oluşturuldu");
                    DialogResult cevap = MessageBox.Show("Giriş sayfasına yönlendirmek ister misin?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        //Temizlik
                        //Girişe git
                        Form1 frmg = new Form1();
                        frmg.Email = txtEmail.Text.Trim();

                        foreach (Form item in Application.OpenForms)
                        {
                            item.Hide();
                        }
                        frmg.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Kayıt EKLENEMEDİ!");
                }


            }



            catch (Exception ex)
            {

                // ex log.txt'ye yazılacak(loglama)
                MessageBox.Show("beklenmedik bir hata oluştu!lütfen tekrar deneyiniz!", ex.Message);
            }
        }

        private void GirisFormunaGit()
        {
            Form1 frmG = new Form1();
            frmG.Email = txtEmail.Text.Trim();
            this.Hide();
            frmG.Show();
        }

        private void FrmKayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisFormunaGit();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisFormunaGit();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
