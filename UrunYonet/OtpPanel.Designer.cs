namespace UrunYonet
{
    partial class OtpPanel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.labelDakika = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSaniye = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tek Kullanımlık Şifre";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(122, 13);
            this.maskedTextBox1.Mask = "999999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // labelDakika
            // 
            this.labelDakika.AutoSize = true;
            this.labelDakika.Location = new System.Drawing.Point(16, 49);
            this.labelDakika.Name = "labelDakika";
            this.labelDakika.Size = new System.Drawing.Size(22, 13);
            this.labelDakika.TabIndex = 2;
            this.labelDakika.Text = "_ _";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // labelSaniye
            // 
            this.labelSaniye.AutoSize = true;
            this.labelSaniye.Location = new System.Drawing.Point(61, 49);
            this.labelSaniye.Name = "labelSaniye";
            this.labelSaniye.Size = new System.Drawing.Size(22, 13);
            this.labelSaniye.TabIndex = 2;
            this.labelSaniye.Text = "_ _";
            // 
            // OtpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 87);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSaniye);
            this.Controls.Add(this.labelDakika);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "OtpPanel";
            this.Text = "OtpPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtpPanel_FormClosed);
            this.Load += new System.EventHandler(this.OtpPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label labelDakika;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSaniye;
    }
}