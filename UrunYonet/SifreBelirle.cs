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
    public partial class SifreBelirle : Form
    {
        DataModel dataModel = new DataModel();
        public SifreBelirle()
        {
            InitializeComponent();
        }

        private void SifreBelirle_Load(object sender, EventArgs e)
        {
            groupBox2.Text ="Kullanici:" + SifremiUnuttum.kullaniciAdi; 
        }

        private void buttonYeniSifre_Click(object sender, EventArgs e)
        {
            if (textBoxSifre.Text!="")
            {
                if (textBoxSifreTekrar.Text== textBoxSifre.Text)
                {
                    dataModel.KullaniciSifreGüncelle(SifremiUnuttum.kullaniciID, textBoxSifre.Text);
                    MessageBox.Show("Kullanıcı:"+SifremiUnuttum.kullaniciAdi +"\r Yeni şifreniz belirlendi." , "Şifre güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Şifre ile şifre tekrar aynı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Şifre boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
