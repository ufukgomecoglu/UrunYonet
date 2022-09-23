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
    public partial class TedarikciIslemleri : Form
    {
        DataModel dataModel = new DataModel();
        public TedarikciIslemleri()
        {
            InitializeComponent();
        }

        private void buttonSifirla_Click(object sender, EventArgs e)
        {
            textBoxAdi.Text = "";
            textBoxEposta.Text = "";
            textBoxYetkiliAdi.Text = "";
            maskedTextBoxTelefon.Text = ""; 
        }
        private void buttonSifirla_Click()
        {
            textBoxAdi.Text = "";
            textBoxEposta.Text = "";
            textBoxYetkiliAdi.Text = "";
            maskedTextBoxTelefon.Text = "";
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            bool key= true;
            if (textBoxAdi.Text=="")
            {
                MessageBox.Show("Adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                key = false;
            }
            if (maskedTextBoxTelefon.Text== "(   )    -")
            {
                MessageBox.Show("Telefon boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key= false;
            }
            if (textBoxEposta.Text == "")
            {
                MessageBox.Show("Eposta boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key = false;
            }
            if (textBoxYetkiliAdi.Text == "")
            {
                MessageBox.Show("Yetkili adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key = false;
            }
            if (key==true)
            {
                dataModel.TedarikciEkle(textBoxAdi.Text, maskedTextBoxTelefon.Text, textBoxEposta.Text, textBoxYetkiliAdi.Text);
                List<Tedarikci> tedarikcis = dataModel.TedarikciListele();
                int tedarikciID = 0;
                foreach (Tedarikci tedarikci in tedarikcis)
                {
                    tedarikciID = tedarikci.TedarikciID;
                }
                dataModel.TedarikciYapilanIslemEkle(KullaniciGiris.kullaniciID, tedarikciID, $"{KullaniciGiris.kullaniciAdi} {textBoxAdi.Text} adlı {tedarikciID} tedarikçiyi ekledi");
                MessageBox.Show($" Tedarikci başarı ile eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonSifirla_Click();
            }
            TedarikciIslemleri_Load();
        }

        private void TedarikciIslemleri_Load(object sender, EventArgs e)
        {
            if (dataModel.TedarikciListele().Count!=0)
            {
                listBoxTedarikci.DisplayMember = "Adi";
                listBoxTedarikci.ValueMember = "TedarikciID";
                listBoxTedarikci.DataSource = dataModel.TedarikciListele();
                listBoxTumTedarikci.ValueMember = "TedarikciID";
                listBoxTumTedarikci.DataSource = dataModel.TedarikciListele();
            }
            else
            {
                List<string> list = new List<string>();
                list.Add("Henüz tedarikci eklenmedi.");
                listBoxTedarikci.DataSource = list;
                listBoxTumTedarikci.DataSource = list;
            }
            buttonSifirla_Click();
        }
        private void TedarikciIslemleri_Load()
        {
            if (dataModel.TedarikciListele().Count != 0)
            {
                listBoxTedarikci.DisplayMember = "Adi";
                listBoxTedarikci.ValueMember = "TedarikciID";
                listBoxTedarikci.DataSource = dataModel.TedarikciListele();
                listBoxTumTedarikci.ValueMember = "TedarikciID";
                listBoxTumTedarikci.DataSource = dataModel.TedarikciListele();
            }
            else
            {
                List<string> list = new List<string>();
                list.Add("Henüz tedarikci eklenmedi.");
                listBoxTedarikci.DataSource = list;
                listBoxTumTedarikci.DataSource = list;
            }
        }

        private void listBoxTedarikci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTedarikci.SelectedItem!=null)
            {
                List<Tedarikci> tedarikcis = dataModel.TedarikciListele(Convert.ToInt32(listBoxTedarikci.SelectedValue));
                foreach (Tedarikci Tedarikci in tedarikcis)
                {
                    textBoxAdi.Text = Tedarikci.Adi;
                    maskedTextBoxTelefon.Text = Tedarikci.Tel;
                    textBoxEposta.Text = Tedarikci.Eposta;
                    textBoxYetkiliAdi.Text = Tedarikci.YetkiliAdi;
                }
            }
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (listBoxTedarikci.SelectedItem != null)
            {
                bool key = true;
                if (textBoxAdi.Text == "")
                {
                    MessageBox.Show("Adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key = false;
                }
                if (maskedTextBoxTelefon.Text == "(   )    -")
                {
                    MessageBox.Show("Telefon boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key = false;
                }
                if (textBoxEposta.Text == "")
                {
                    MessageBox.Show("Eposta boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key = false;
                }
                if (textBoxYetkiliAdi.Text == "")
                {
                    MessageBox.Show("Yetkili adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    key = false;
                }
                if (key==true)
                {
                    dataModel.TedarikciGuncelle(Convert.ToInt32(listBoxTedarikci.SelectedValue), textBoxAdi.Text, maskedTextBoxTelefon.Text, textBoxEposta.Text, textBoxYetkiliAdi.Text);
                    MessageBox.Show($" Tedarikci başarı ile güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataModel.TedarikciYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxTedarikci.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {textBoxAdi.Text} isimli {Convert.ToInt32(listBoxTedarikci.SelectedValue)} tedarikçiyi güncelledi.");
                    buttonSifirla_Click();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tedarikçi listesinden tedarikçi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TedarikciIslemleri_Load();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (listBoxTedarikci.SelectedItem!=null)
            {
                dataModel.TedarikciGuncelle(Convert.ToInt32(listBoxTedarikci.SelectedValue));
                MessageBox.Show($" Tedarikci başarı ile silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataModel.TedarikciYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxTedarikci.SelectedValue), $"{KullaniciGiris.kullaniciAdi}  {Convert.ToInt32(listBoxTedarikci.SelectedValue)} tedarikçiyi sildi.");
            }
            else
            {
                MessageBox.Show("Lütfen tedarikçi listesinden tedarikçi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TedarikciIslemleri_Load();
        }

        private void listBoxTumTedarikci_Format(object sender, ListControlConvertEventArgs e)
        {
            int iD = ((Tedarikci)e.ListItem).TedarikciID;
            string ad = ((Tedarikci)e.ListItem).Adi;
            e.Value = $"{iD} {ad}";
        }

        private void buttonGeriAl_Click(object sender, EventArgs e)
        {
            if (listBoxTumTedarikci.SelectedItem!=null)
            {
                dataModel.TedarikciGuncelleGeriAl(Convert.ToInt32(listBoxTumTedarikci.SelectedValue));
                MessageBox.Show($" Tedarikci başarı ile aktifleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataModel.TedarikciYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxTedarikci.SelectedValue), $"{KullaniciGiris.kullaniciAdi}  {Convert.ToInt32(listBoxTedarikci.SelectedValue)} tedarikçiyi aktifleştirildi.");
            }
            else
            {
                MessageBox.Show("Lütfen tüm tedarikçi listesinden tedarikçi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TedarikciIslemleri_Load();
        }
    }
}
