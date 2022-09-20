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
    public partial class SifremiUnuttum : Form
    {
        public static int kullaniciID = 0;
        public static string otp = "";
        public static string kullaniciAdi = "";
        DataModel dataModel = new DataModel();
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void buttonGonder_Click(object sender, EventArgs e)
        {
            string eposta = "";
            bool key = true;
            if (textBoxKullaniciAdi.Text=="")
            {
                MessageBox.Show("Sifre boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key = false;
            }
            if (textBoxEposta.Text=="")
            {
                MessageBox.Show("Sifre boş bırakılamaz.Örnek ornek@ornek.com", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key = false;
            }
            if (key==true)
            {
                Kullanicilar kullanicilar = dataModel.SifremiUnuttum(textBoxKullaniciAdi.Text, textBoxEposta.Text);
                if (kullanicilar!=null)
                {
                    eposta = kullanicilar.Eposta;
                    kullaniciID = kullanicilar.KullaniciID;
                    kullaniciAdi = kullanicilar.KullaniciAdi;
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya eposta hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key = false;
                }
            }
            if (key==true)
            {
                Random generator = new Random();
                otp = generator.Next(0, 1000000).ToString("D6");
                dataModel.MailGönder(eposta, otp);
                this.Close();
                OtpPanel otpPanel = new OtpPanel();
                otpPanel.Show();
            }
        }
        
    }
}
