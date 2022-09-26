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
    public partial class KategoriIslemleri : Form
    {
        DataModel dataModel = new DataModel();
        public KategoriIslemleri()
        {
            InitializeComponent();
        }

        private void buttonKategoriEkle_Click(object sender, EventArgs e)
        {
            bool key = true;
            if (textBoxKategoriAdi.Text=="")
            {
                MessageBox.Show("Kategori Adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key= false; 
            }
            if (key==true)
            {
                dataModel.KategoriEkle(textBoxKategoriAdi.Text.ToUpper());
                MessageBox.Show("Kategori başarı ile eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Kategori> kategoris = dataModel.KategoriListele();
                int kategoriID = 0;
                foreach (Kategori kategori in kategoris)
                {
                    kategoriID = kategori.KategoriID;
                }
                dataModel.KategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, kategoriID, $"{KullaniciGiris.kullaniciAdi} {textBoxKategoriAdi.Text.ToUpper()} isimli {kategoriID.ToString()} kategorisini ekledi.");
                textBoxKategoriAdi.Text = "";
            }
            KategoriIslemleri_Load();
        }

        private void buttonKategoriGüncelle_Click(object sender, EventArgs e)
        {
            
            if (listBoxKategori.SelectedItem != null && listBoxKategori.SelectedValue.ToString()!= "Henüz kategori eklenmedi")
            {
                if (dataModel.KategoriGuncelle(Convert.ToInt32(listBoxKategori.SelectedValue), textBoxKategoriAdi.Text.ToUpper()))
                {
                    MessageBox.Show($"Kategori başarı ile güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataModel.KategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxKategori.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {listBoxKategori.SelectedValue} kategorisini güncelledi.");
                    textBoxKategoriAdi.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kategori listesinden kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KategoriIslemleri_Load();
        }
        private void buttonKategoriSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult= MessageBox.Show("Kategoriyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult== DialogResult.OK)
            {
                if (listBoxKategori.SelectedItem != null && listBoxKategori.SelectedValue.ToString() != "Henüz kategori eklenmedi")
                {
                    if (dataModel.KategoriGuncelle(Convert.ToInt32(listBoxKategori.SelectedValue)))
                    {
                        MessageBox.Show($"Kategori başarı ile silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataModel.KategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxKategori.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {listBoxKategori.SelectedValue} kategorisini sildi.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Kategori listesinden kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                KategoriIslemleri_Load();
            }
            else
            {
                MessageBox.Show($"İşlem iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void KategoriIslemleri_Load(object sender, EventArgs e)
        {
            if (dataModel.KategoriListele().Count!= 0)
            {
                listBoxKategori.DataSource = dataModel.KategoriListele(); ;
                listBoxKategori.DisplayMember = "KategoriAdi";
                listBoxKategori.ValueMember = "KategoriID";
                comboBox1.DisplayMember = "KategoriAdi";
                comboBox1.ValueMember = "KategoriID";
                comboBox1.DataSource = dataModel.KategoriListele();
                comboBox1.SelectedItem = null;
            }
            else
            {
                List<string> strings = new List<string>();
                strings.Add("Henüz kategori eklenmedi");
                listBoxKategori.DataSource = strings;
            }
            comboBox1.Text = "Lütfen Kategori seçiniz...";
            if (comboBox1.SelectedItem== null)
            {
                textBoxAltKategoriAdi.Enabled = false;
                buttonAltKategoriEkle.Enabled = false;
                buttonAltKategoriGüncelle.Enabled = false;
                buttonAltKategoriSil.Enabled = false;
                listBoxAltKotegori.Enabled = false;
            }
            else
            {
                textBoxAltKategoriAdi.Enabled = true;
                buttonAltKategoriEkle.Enabled = true;
                buttonAltKategoriGüncelle.Enabled = true;
                buttonAltKategoriSil.Enabled = true;
            }
            listBoxTumKategoriListesi.ValueMember = "KategoriID";
            listBoxTumKategoriListesi.DataSource = dataModel.TumKategoriListele();
            listBoxTumAltKategoriListesi.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.DataSource = dataModel.AltkategoriListele();
        }
        private void KategoriIslemleri_Load()
        {
            if (dataModel.KategoriListele().Count != 0)
            {
                listBoxKategori.DataSource = dataModel.KategoriListele(); ;
                listBoxKategori.DisplayMember = "KategoriAdi";
                listBoxKategori.ValueMember = "KategoriID";
                comboBox1.DisplayMember = "KategoriAdi";
                comboBox1.ValueMember = "KategoriID";
                comboBox1.DataSource = dataModel.KategoriListele();
            }
            else
            {
                List<string> strings = new List<string>();
                strings.Add("Henüz kategori eklenmedi");
                listBoxKategori.DataSource = strings;
            }
            if (comboBox1.SelectedItem == null)
            {
                textBoxAltKategoriAdi.Enabled = false;
                buttonAltKategoriEkle.Enabled = false;
                buttonAltKategoriGüncelle.Enabled = false;
                buttonAltKategoriSil.Enabled = false;
                listBoxAltKotegori.Enabled = false;
            }
            else
            {
                textBoxAltKategoriAdi.Enabled = true;
                buttonAltKategoriEkle.Enabled = true;
                buttonAltKategoriGüncelle.Enabled = true;
                buttonAltKategoriSil.Enabled = true;
            }
            List<Kategori> list = dataModel.TumKategoriListele();
            listBoxTumKategoriListesi.ValueMember = "KategoriID";
            listBoxTumKategoriListesi.DataSource = dataModel.TumKategoriListele();
            listBoxTumAltKategoriListesi.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.DataSource = dataModel.AltkategoriListele();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue)).Count!=0)
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) != 0)
                {
                    textBoxAltKategoriAdi.Enabled = true;
                    buttonAltKategoriEkle.Enabled = true;
                    buttonAltKategoriGüncelle.Enabled = true;
                    buttonAltKategoriSil.Enabled = true;
                    listBoxAltKotegori.Enabled = true;
                    listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
                    listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
                    listBoxAltKotegori.ValueMember = "AltKategoriID";
                }
            }
            else
            {
                textBoxAltKategoriAdi.Enabled = true;
                buttonAltKategoriEkle.Enabled = true;
                buttonAltKategoriGüncelle.Enabled = true;
                buttonAltKategoriSil.Enabled = true;
                List<string> list = new List<string>();
                list.Add("Henüz seçtiğiniz kategoriye alt kategori eklenmedi");
                listBoxAltKotegori.DataSource = list;
                listBoxAltKotegori.Enabled = false;
            }
        }

        private void buttonAltKategoriEkle_Click(object sender, EventArgs e)
        {
            bool key = true;
            if (textBoxAltKategoriAdi.Text == "")
            {
                MessageBox.Show("Alt Kategori Adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                key = false;
            }
            if (key==true)
            {
                dataModel.AltKategoriEkle(Convert.ToInt32(comboBox1.SelectedValue), textBoxAltKategoriAdi.Text.ToUpper());
                MessageBox.Show($"{comboBox1.SelectedText} altına kategori başarı ile eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<AltKategori> altKategoris = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
                int altKategoriID = 0;
                foreach (AltKategori altKategori in altKategoris)
                {
                    altKategoriID = altKategori.AltKategoriID;
                }
                dataModel.AltkategoriYapilanIslemEkle(KullaniciGiris.kullaniciID,altKategoriID , $"{KullaniciGiris.kullaniciAdi} {textBoxAltKategoriAdi.Text.ToUpper()} isimli {altKategoriID.ToString()} alt kategorisini ekledi .");
                textBoxAltKategoriAdi.Text = "";
            }
            if (dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue)).Count != 0)
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) != 0)
                {
                    listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
                    listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
                    listBoxAltKotegori.ValueMember = "AltKategoriID";
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add("Henüz seçtiğiniz kategoriye alt kategori eklenmedi");
                listBoxAltKotegori.DataSource = list;
                listBoxAltKotegori.Enabled = false;
            }
            listBoxTumAltKategoriListesi.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.DataSource = dataModel.AltkategoriListele();
        }

        private void buttonAltKategoriGüncelle_Click(object sender, EventArgs e)
        {
            if (listBoxAltKotegori.SelectedItem != null && listBoxAltKotegori.SelectedValue.ToString() != "Henüz seçtiğiniz kategoriye alt kategori eklenmedi")
            {
                if (dataModel.AltKategoriGuncelle(Convert.ToInt32(listBoxAltKotegori.SelectedValue), textBoxAltKategoriAdi.Text.ToUpper()))
                {
                    MessageBox.Show($"Alt Kategori başarı ile güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataModel.AltkategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxAltKotegori.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {listBoxAltKotegori.SelectedValue}  alt kategorisini güncelledi .");
                    textBoxAltKategoriAdi.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Lütfen Alt Kategori listesinden alt kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
            listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
            listBoxAltKotegori.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.DataSource = dataModel.AltkategoriListele();
        }

        private void buttonAltKategoriSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Alt Kategoriyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                if (listBoxAltKotegori.SelectedItem != null && listBoxAltKotegori.SelectedValue.ToString() != "\"Henüz seçtiğiniz kategoriye alt kategori eklenmedi\"")
                {
                    if (dataModel.AltKategoriGuncelle(Convert.ToInt32(listBoxAltKotegori.SelectedValue)))
                    {
                        dataModel.AltkategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxAltKotegori.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {listBoxAltKotegori.SelectedValue}  alt kategorisini sildi.");
                        MessageBox.Show($"Alt Kategori başarı ile silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Alt Kategori listesinden kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue)).Count != 0)
                {
                    if (Convert.ToInt32(comboBox1.SelectedValue) != 0)
                    {
                        listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
                        listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
                        listBoxAltKotegori.ValueMember = "AltKategoriID";
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add("Henüz seçtiğiniz kategoriye alt kategori eklenmedi");
                    listBoxAltKotegori.DataSource = list;
                    listBoxAltKotegori.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show($"İşlem iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listBoxTumAltKategoriListesi.ValueMember = "AltKategoriID";
            listBoxTumAltKategoriListesi.DataSource = dataModel.AltkategoriListele();
        }

        private void buttonKategoriGeriAl_Click(object sender, EventArgs e)
        {
            if (listBoxTumKategoriListesi.SelectedValue!=null)
            {
                dataModel.KategoriGuncelleGeriAl(Convert.ToInt32(listBoxTumKategoriListesi.SelectedValue));
                MessageBox.Show($"Kategori başarıyla aktif ettniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataModel.KategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxTumKategoriListesi.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {Convert.ToInt32(listBoxTumKategoriListesi.SelectedValue)} kategoriyi aktif etti.");
            }
            else
            {
                MessageBox.Show("Lütfen Tum Kategori listesinden  kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KategoriIslemleri_Load();
        }

        private void listBoxTumKategoriListesi_Format(object sender, ListControlConvertEventArgs e)
        {
            int iD = ((Kategori)e.ListItem).KategoriID;
            string ad = ((Kategori)e.ListItem).KategoriAdi;
            e.Value = $"{iD} {ad}";
        }

        private void listBoxTumAltKategoriListesi_Format(object sender, ListControlConvertEventArgs e)
        {
            int iD = ((AltKategori)e.ListItem).AltKategoriID;
            string ad = ((AltKategori)e.ListItem).AltKategoriAdi;
            e.Value = $"{iD} {ad}";
        }

        private void buttonAltKategoriGeriAl_Click(object sender, EventArgs e)
        {
            if (listBoxTumAltKategoriListesi.SelectedValue != null)
            {
                dataModel.AltKategoriGuncelleGeriAl(Convert.ToInt32(listBoxTumAltKategoriListesi.SelectedValue));
                MessageBox.Show($"Alt Kategori başarıyla aktif ettniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataModel.KategoriYapilanIslemEkle(KullaniciGiris.kullaniciID, Convert.ToInt32(listBoxTumAltKategoriListesi.SelectedValue), $"{KullaniciGiris.kullaniciAdi} {Convert.ToInt32(listBoxTumAltKategoriListesi.SelectedValue)} alt kategoriyi aktif etti.");
            }
            else
            {
                MessageBox.Show("Lütfen Tum ALT Kategori listesinden  kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KategoriIslemleri_Load();
            if (dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue)).Count != 0)
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) != 0)
                {
                    listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
                    listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
                    listBoxAltKotegori.ValueMember = "AltKategoriID";
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add("Henüz seçtiğiniz kategoriye alt kategori eklenmedi");
                listBoxAltKotegori.DataSource = list;
                listBoxAltKotegori.Enabled = false;
            }
        }
    }
}
