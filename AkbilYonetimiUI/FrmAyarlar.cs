using AkbilYntmIsKatmani;
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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MinDate = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Value = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;

            KullanicininBilgileriniGetir();
        }

        private void KullanicininBilgileriniGetir()
        {
            try
            {
                //NOT: Giriş yapmış kullnıcının bilgileriyle select sorgusu yazacağız
                //kullanıcı bilgisini alabilmek için burada 2 yöntem kullanbilirz.
                //static bir class açıp içinde giris yapmis kullanici email propertisysi kullanilabilir.
                //2.yöntem olarak properties settings içine kayıtlı email bilgisinden yararlanılabilir.


            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik hata oluştu" + hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme başarısızdır!" + hata.Message);
            }
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Güle Güle...  \n  Çıkış Yapıldı! ");
            GenelIslemler.GirisYapanKullaniciAdSoyad = string.Empty;
            GenelIslemler.GirisYapanKullaniciID = 0;

            foreach (Form item in Application.OpenForms)
            {
                if (item.Name != "Form1")
                {
                    item.Hide();
                }
            }
            Application.OpenForms["Form1"].Show();

        }

        private void aNASAYFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnasayfa frma = new FrmAnasayfa();
            this.Hide();
            frma.Show();
        }
    }
}
