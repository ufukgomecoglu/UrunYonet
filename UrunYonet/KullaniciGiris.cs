using DataAccsessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonet
{
    public partial class KullaniciGiris : Form
    {
        public static string kullaniciAdi = "";
        public static int  kullaniciID = 0;
        bool girisYap = false;
        DataModel dataModel = new DataModel();
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void KullaniciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (girisYap == false)
            {
                Application.Exit();
            }
        }

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            bool key = true;
            if (textBoxKullaniciAdi.Text=="" )
            {
                key = false;
                MessageBox.Show("Kullanıcı Adı boş bırakalımaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBoxSifre.Text == "")
            {
                key = false;
                MessageBox.Show("Sifre boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (key==true)
            {
                if (!String.IsNullOrEmpty(textBoxKullaniciAdi.Text) && !String.IsNullOrEmpty(textBoxSifre.Text))
                {
                    kullaniciAdi =textBoxKullaniciAdi.Text;
                    Kullanicilar kullanicilar = dataModel.Giris(textBoxKullaniciAdi.Text, textBoxSifre.Text);
                    if (kullanicilar != null)
                    {
                        kullaniciID = kullanicilar.KullaniciID;
                        girisYap = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre doğru değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSifremiUnuttum_Click(object sender, EventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            if (Application.OpenForms.OfType<SifremiUnuttum>().Count() == 0 && Application.OpenForms.OfType<SifreBelirle>().Count() == 0&& Application.OpenForms.OfType<OtpPanel>().Count() == 0)
            {
                sifremiUnuttum.Show();
            }
        }

        private void KullaniciGiris_Load(object sender, EventArgs e)
        {
            checkBoxBeniHatirla.Checked = dataModel.BeniHatirlaList();
            if (checkBoxBeniHatirla.Checked == true)
            {
                StreamReader sr = new StreamReader(@"C:\UrunYonet\KullaniciHatirla.urunYonet");
                textBoxKullaniciAdi.Text = sr.ReadLine();
                textBoxSifre.Text = sr.ReadLine();
                sr.Close();
            }
        }

        private void checkBoxBeniHatirla_Click(object sender, EventArgs e)
        {
            if (checkBoxBeniHatirla.Checked == true)
            {
                dataModel.BeniHatirlaUpdate(true);
            }
            else
            {
                dataModel.BeniHatirlaUpdate(false);
            }
            if (checkBoxBeniHatirla.Checked == true)
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\UrunYonet");
                if (!di.Exists)
                {
                    di.Create();
                }
                FileInfo fi = new FileInfo(@"C:\UrunYonet\KullaniciHatirla.urunYonet");
                if (!fi.Exists)
                {
                    fi.Create();
                }
                StreamWriter sw = new StreamWriter(@"C:\UrunYonet\KullaniciHatirla.urunYonet");
                sw.WriteLine(textBoxKullaniciAdi.Text);
                sw.WriteLine(textBoxSifre.Text);
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(@"C:\UrunYonet\KullaniciHatirla.urunYonet");
                sw.WriteLine("");
                sw.Close();
            }
        }
    }
}
