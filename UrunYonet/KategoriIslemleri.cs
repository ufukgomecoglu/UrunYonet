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
                dataModel.KategoriEkle(textBoxKategoriAdi.Text);
                textBoxKategoriAdi.Text = "";
                MessageBox.Show("Kategori başarı ile eklendi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listBoxKategori.DataSource = dataModel.KategoriListele(); ;
            listBoxKategori.DisplayMember = "KategoriAdi";
            listBoxKategori.ValueMember = "KategoriID";
        }

        private void buttonKategoriGüncelle_Click(object sender, EventArgs e)
        {
            
            if (listBoxKategori.SelectedItem != null)
            {
                if (dataModel.KategoriGuncelle(Convert.ToInt32(listBoxKategori.SelectedValue), textBoxKategoriAdi.Text))
                {
                    MessageBox.Show($"Kategori başarı ile güncellendi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kategori listesinden kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBoxKategori.DataSource = dataModel.KategoriListele(); ;
            listBoxKategori.DisplayMember = "KategoriAdi";
            listBoxKategori.ValueMember = "KategoriID";
        }

        private void KategoriIslemleri_Load(object sender, EventArgs e)
        {
            if (dataModel.KategoriListele().Count != 0)
            {
                listBoxKategori.DataSource = dataModel.KategoriListele(); ;
                listBoxKategori.DisplayMember = "KategoriAdi";
                listBoxKategori.ValueMember = "KategoriID";
            }
            else
            {
                listBoxKategori.Items.Add("Hiç kategori eklenmedi.");
            }
        }

        private void buttonKategoriSil_Click(object sender, EventArgs e)
        {

        }
    }
}
