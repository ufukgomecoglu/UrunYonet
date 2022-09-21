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
                textBoxKategoriAdi.Text = "";
                MessageBox.Show("Kategori başarı ile eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            KategoriIslemleri_Load();
        }

        private void buttonKategoriGüncelle_Click(object sender, EventArgs e)
        {
            
            if (listBoxKategori.SelectedItem != null)
            {
                if (dataModel.KategoriGuncelle(Convert.ToInt32(listBoxKategori.SelectedValue), textBoxKategoriAdi.Text.ToUpper()))
                {
                    MessageBox.Show($"Kategori başarı ile güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (listBoxKategori.SelectedItem != null)
                {
                    if (dataModel.KategoriGuncelle(Convert.ToInt32(listBoxKategori.SelectedValue)))
                    {
                        MessageBox.Show($"Kategori başarı ile silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                comboBox1.DataSource = dataModel.KategoriListele();
                comboBox1.DisplayMember = "KategoriAdi";
                comboBox1.ValueMember = "KategoriID";
            }
            else
            {
                List<string> strings = new List<string>();
                strings.Add("Henüz kategori eklenmedi");
                listBoxKategori.DataSource = strings;
            }
            comboBox1.SelectedItem = null;
            comboBox1.Text = "Lütfen Kategori seçiniz...";
            if (comboBox1.SelectedItem== null)
            {
                textBoxAltKategoriAdi.Enabled = false;
                buttonAltKategoriEkle.Enabled = false;
                buttonAltKategoriGüncelle.Enabled = false;
                buttonAltKategoriSil.Enabled = false;
            }
            else
            {
                textBoxAltKategoriAdi.Enabled = true;
                buttonAltKategoriEkle.Enabled = true;
                buttonAltKategoriGüncelle.Enabled = true;
                buttonAltKategoriSil.Enabled = true;
            }
        }
        private void KategoriIslemleri_Load()
        {
            if (dataModel.KategoriListele().Count != 0)
            {
                listBoxKategori.DataSource = dataModel.KategoriListele(); ;
                listBoxKategori.DisplayMember = "KategoriAdi";
                listBoxKategori.ValueMember = "KategoriID";
                comboBox1.DataSource = dataModel.KategoriListele();
                comboBox1.DisplayMember = "KategoriAdi";
                comboBox1.ValueMember = "KategoriID";
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
            }
            else
            {
                textBoxAltKategoriAdi.Enabled = true;
                buttonAltKategoriEkle.Enabled = true;
                buttonAltKategoriGüncelle.Enabled = true;
                buttonAltKategoriSil.Enabled = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAltKategoriAdi.Enabled = true;
            buttonAltKategoriEkle.Enabled = true;
            buttonAltKategoriGüncelle.Enabled = true;
            buttonAltKategoriSil.Enabled = true;
        }
    }
}
