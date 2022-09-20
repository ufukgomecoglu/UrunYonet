using DataAccsessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonet
{
    public partial class KullaniciGiris : Form
    {
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
                    Kullanicilar kullanicilar = dataModel.Giris(textBoxKullaniciAdi.Text, textBoxSifre.Text);
                    if (kullanicilar != null)
                    {
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
            if (Application.OpenForms.OfType<SifremiUnuttum>().Count() == 0)
            {
                sifremiUnuttum.Show();
            }
        }
    }
}
