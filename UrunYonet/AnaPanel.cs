﻿using System;
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
        }

        private void TSMI_KategoriIslemleri_Click(object sender, EventArgs e)
        {

        }
    }
}
