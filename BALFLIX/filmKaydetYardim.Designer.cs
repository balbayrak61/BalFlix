namespace BALFLIX
{
    partial class filmKaydetYardim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filmKaydetYardim));
            this.kaydetSayfasiBALFLIX = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kaydetYardimAnaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kaydetSayfasiBALFLIX
            // 
            this.kaydetSayfasiBALFLIX.AutoSize = true;
            this.kaydetSayfasiBALFLIX.Font = new System.Drawing.Font("Consolas", 22F, System.Drawing.FontStyle.Bold);
            this.kaydetSayfasiBALFLIX.ForeColor = System.Drawing.Color.White;
            this.kaydetSayfasiBALFLIX.Location = new System.Drawing.Point(12, 9);
            this.kaydetSayfasiBALFLIX.Name = "kaydetSayfasiBALFLIX";
            this.kaydetSayfasiBALFLIX.Size = new System.Drawing.Size(127, 36);
            this.kaydetSayfasiBALFLIX.TabIndex = 0;
            this.kaydetSayfasiBALFLIX.Text = "BALFLIX";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(733, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // kaydetYardimAnaLabel
            // 
            this.kaydetYardimAnaLabel.AutoSize = true;
            this.kaydetYardimAnaLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.kaydetYardimAnaLabel.Location = new System.Drawing.Point(28, 99);
            this.kaydetYardimAnaLabel.Name = "kaydetYardimAnaLabel";
            this.kaydetYardimAnaLabel.Size = new System.Drawing.Size(705, 126);
            this.kaydetYardimAnaLabel.TabIndex = 2;
            this.kaydetYardimAnaLabel.Text = resources.GetString("kaydetYardimAnaLabel.Text");
            // 
            // filmKaydetYardim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(780, 265);
            this.Controls.Add(this.kaydetYardimAnaLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kaydetSayfasiBALFLIX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "filmKaydetYardim";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BALFLIX";
            this.Load += new System.EventHandler(this.filmKaydetYardim_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filmKaydetYardim_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.filmKaydetYardim_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label kaydetSayfasiBALFLIX;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label kaydetYardimAnaLabel;
    }
}