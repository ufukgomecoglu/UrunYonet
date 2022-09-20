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
            
            InitializeComponent();
            
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
            if (dakika == 0)
            {
                timer1.Stop();
                Random generator = new Random();
                MessageBox.Show("Süre doldu yeniden şifre isteyin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SifremiUnuttum.otp = null;
                this.Close();
                SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
                sifremiUnuttum.Show();
            }
        }

        private void buttonSifreBelirle_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxOtp.Text==SifremiUnuttum.otp)
            {
                timer1.Stop();
                this.Close();
                SifreBelirle sifreBelirle = new SifreBelirle();
                sifreBelirle.Show();
            }
            else
            {
                MessageBox.Show("Şifre yanlış doğru şifreyi giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
