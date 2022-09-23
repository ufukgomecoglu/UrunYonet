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
    public partial class AnaPanel : Form
    {
        public AnaPanel()
        {
            KullaniciGiris frm = new KullaniciGiris();
            frm.ShowDialog();
            InitializeComponent();
            toolStripStatusLabel1.Text ="Kullanici:" + KullaniciGiris.kullaniciAdi;
        }

        private void TSMI_KategoriIslemleri_Click(object sender, EventArgs e)
        {
            Form[] AcikFormlar = this.MdiChildren;
            bool acikmi = false;
            foreach (Form item in AcikFormlar)
            {
                if (item.GetType() == typeof(KategoriIslemleri))
                {
                    acikmi = true;
                    item.Activate();
                }
            }
            if (acikmi == false)
            {
                KategoriIslemleri frm = new KategoriIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void TSMI_TedarikciIslemleri_Click(object sender, EventArgs e)
        {
            Form[] AcikFormlar = this.MdiChildren;
            bool acikmi = false;
            foreach (Form item in AcikFormlar)
            {
                if (item.GetType() == typeof(TedarikciIslemleri))
                {
                    acikmi = true;
                    item.Activate();
                }
            }
            if (acikmi == false)
            {
                TedarikciIslemleri frm = new TedarikciIslemleri();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
