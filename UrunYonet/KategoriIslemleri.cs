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

        private void buttonAltKategoriGüncelle_Click(object sender, EventArgs e)
        {
            if (listBoxAltKotegori.SelectedItem != null)
            {
                if (dataModel.AltKategoriGuncelle(Convert.ToInt32(listBoxAltKotegori.SelectedValue), textBoxAltKategoriAdi.Text.ToUpper()))
                {
                    MessageBox.Show($"Alt Kategori başarı ile güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Alt Kategori listesinden alt kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBoxAltKotegori.DataSource = dataModel.KategoriyeGöreAltkategoriListele(Convert.ToInt32(comboBox1.SelectedValue));
            listBoxAltKotegori.DisplayMember = "AltKategoriAdi";
            listBoxAltKotegori.ValueMember = "AltKategoriID";
        }

        private void buttonAltKategoriSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Alt Kategoriyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                if (listBoxAltKotegori.SelectedItem != null)
                {
                    if (dataModel.AltKategoriGuncelle(Convert.ToInt32(listBoxAltKotegori.SelectedValue)))
                    {
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
        }
    }
}
