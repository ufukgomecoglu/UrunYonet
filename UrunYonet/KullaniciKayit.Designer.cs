namespace UrunYonet
{
    partial class KullaniciKayit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonKullaniciKayit = new System.Windows.Forms.Button();
            this.textBoxSifreTekrar = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.maskedTextBoxDogumTarihi = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCepTel = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEposta = new System.Windows.Forms.TextBox();
            this.textBoxKullaniciAd = new System.Windows.Forms.TextBox();
            this.textBoxSoyad = new System.Windows.Forms.TextBox();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonKullaniciKayit);
            this.groupBox1.Controls.Add(this.textBoxSifreTekrar);
            this.groupBox1.Controls.Add(this.textBoxSifre);
            this.groupBox1.Controls.Add(this.maskedTextBoxDogumTarihi);
            this.groupBox1.Controls.Add(this.maskedTextBoxCepTel);
            this.groupBox1.Controls.Add(this.textBoxEposta);
            this.groupBox1.Controls.Add(this.textBoxKullaniciAd);
            this.groupBox1.Controls.Add(this.textBoxSoyad);
            this.groupBox1.Controls.Add(this.textBoxAd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı Kayıt Paneli ";
            // 
            // buttonKullaniciKayit
            // 
            this.buttonKullaniciKayit.Location = new System.Drawing.Point(70, 207);
            this.buttonKullaniciKayit.Name = "buttonKullaniciKayit";
            this.buttonKullaniciKayit.Size = new System.Drawing.Size(75, 23);
            this.buttonKullaniciKayit.TabIndex = 4;
            this.buttonKullaniciKayit.Text = "Kayıt Ol";
            this.buttonKullaniciKayit.UseVisualStyleBackColor = true;
            this.buttonKullaniciKayit.Click += new System.EventHandler(this.buttonKullaniciKayit_Click);
            // 
            // textBoxSifreTekrar
            // 
            this.textBoxSifreTekrar.Location = new System.Drawing.Point(130, 181);
            this.textBoxSifreTekrar.Name = "textBoxSifreTekrar";
            this.textBoxSifreTekrar.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifreTekrar.TabIndex = 3;
            this.textBoxSifreTekrar.UseSystemPasswordChar = true;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Location = new System.Drawing.Point(130, 156);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifre.TabIndex = 3;
            this.textBoxSifre.UseSystemPasswordChar = true;
            // 
            // maskedTextBoxDogumTarihi
            // 
            this.maskedTextBoxDogumTarihi.Location = new System.Drawing.Point(130, 133);
            this.maskedTextBoxDogumTarihi.Mask = "00/00/0000";
            this.maskedTextBoxDogumTarihi.Name = "maskedTextBoxDogumTarihi";
            this.maskedTextBoxDogumTarihi.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDogumTarihi.TabIndex = 2;
            this.maskedTextBoxDogumTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxCepTel
            // 
            this.maskedTextBoxCepTel.Location = new System.Drawing.Point(130, 108);
            this.maskedTextBoxCepTel.Mask = "(999) 000-0000";
            this.maskedTextBoxCepTel.Name = "maskedTextBoxCepTel";
            this.maskedTextBoxCepTel.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxCepTel.TabIndex = 2;
            // 
            // textBoxEposta
            // 
            this.textBoxEposta.Location = new System.Drawing.Point(130, 85);
            this.textBoxEposta.Name = "textBoxEposta";
            this.textBoxEposta.Size = new System.Drawing.Size(100, 20);
            this.textBoxEposta.TabIndex = 1;
            // 
            // textBoxKullaniciAd
            // 
            this.textBoxKullaniciAd.Location = new System.Drawing.Point(130, 61);
            this.textBoxKullaniciAd.Name = "textBoxKullaniciAd";
            this.textBoxKullaniciAd.Size = new System.Drawing.Size(100, 20);
            this.textBoxKullaniciAd.TabIndex = 1;
            // 
            // textBoxSoyad
            // 
            this.textBoxSoyad.Location = new System.Drawing.Point(130, 37);
            this.textBoxSoyad.Name = "textBoxSoyad";
            this.textBoxSoyad.Size = new System.Drawing.Size(100, 20);
            this.textBoxSoyad.TabIndex = 1;
            // 
            // textBoxAd
            // 
            this.textBoxAd.Location = new System.Drawing.Point(130, 12);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(100, 20);
            this.textBoxAd.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Şifre Tekrar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Şifre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Doğum Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cep Telefonu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "E posta adresi ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyadı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adı";
            // 
            // KullaniciKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 256);
            this.Controls.Add(this.groupBox1);
            this.Name = "KullaniciKayit";
            this.Text = "KullaniciKayit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSifreTekrar;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDogumTarihi;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCepTel;
        private System.Windows.Forms.TextBox textBoxEposta;
        private System.Windows.Forms.TextBox textBoxKullaniciAd;
        private System.Windows.Forms.TextBox textBoxSoyad;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.Button buttonKullaniciKayit;
    }
}