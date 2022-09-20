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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UrunYonet
{
    public partial class OtpPanel : Form
    {
        int dakika = 3;
        int saniye = 60;
        public OtpPanel()
        {
            DataModel dataModel = new DataModel();
            InitializeComponent();
            if (labelDakika.Text == "-1")
            {
                timer1.Stop();
                labelDakika.Text = "00";
                labelDakika.Text = "00";
                Random generator = new Random();
                string otp = generator.Next(0, 1000000).ToString("D6");
                dataModel.KullanıcıSifreGüncelle(SifremiUnuttum.kullaniciID, otp);
                MessageBox.Show("Süre doldu yeniden şifre isteyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void OtpPanel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye = saniye - 1;
            labelSaniye.Text = Convert.ToString(saniye);
            labelDakika.Text = Convert.ToString(dakika - 1);
            if (saniye == 0)
            {

                dakika = dakika - 1;
                labelDakika.Text = Convert.ToString(dakika);
                saniye = 60;
            }
        }

        private void OtpPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.ShowDialog();
        }
    }
}
