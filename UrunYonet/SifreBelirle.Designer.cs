namespace UrunYonet
{
    partial class SifreBelirle
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonYeniSifre = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSifreTekrar = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonYeniSifre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxSifreTekrar);
            this.groupBox2.Controls.Add(this.textBoxSifre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // buttonYeniSifre
            // 
            this.buttonYeniSifre.Location = new System.Drawing.Point(13, 83);
            this.buttonYeniSifre.Name = "buttonYeniSifre";
            this.buttonYeniSifre.Size = new System.Drawing.Size(165, 23);
            this.buttonYeniSifre.TabIndex = 3;
            this.buttonYeniSifre.Text = "Yeni Şifre";
            this.buttonYeniSifre.UseVisualStyleBackColor = true;
            this.buttonYeniSifre.Click += new System.EventHandler(this.buttonYeniSifre_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre Tekrar";
            // 
            // textBoxSifreTekrar
            // 
            this.textBoxSifreTekrar.Location = new System.Drawing.Point(78, 48);
            this.textBoxSifreTekrar.Name = "textBoxSifreTekrar";
            this.textBoxSifreTekrar.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifreTekrar.TabIndex = 1;
            this.textBoxSifreTekrar.UseSystemPasswordChar = true;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Location = new System.Drawing.Point(78, 20);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifre.TabIndex = 1;
            this.textBoxSifre.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sifre";
            // 
            // SifreBelirle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 141);
            this.Controls.Add(this.groupBox2);
            this.Name = "SifreBelirle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sifre Belirle";
            this.Load += new System.EventHandler(this.SifreBelirle_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonYeniSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSifreTekrar;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.Label label4;
    }
}