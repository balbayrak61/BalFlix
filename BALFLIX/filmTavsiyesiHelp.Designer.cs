namespace BALFLIX
{
    partial class filmTavsiyesiHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filmTavsiyesiHelp));
            this.filmTavsiyeBALFLIX = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tavsiyeAnaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // filmTavsiyeBALFLIX
            // 
            this.filmTavsiyeBALFLIX.AutoSize = true;
            this.filmTavsiyeBALFLIX.Font = new System.Drawing.Font("Consolas", 22F, System.Drawing.FontStyle.Bold);
            this.filmTavsiyeBALFLIX.ForeColor = System.Drawing.Color.White;
            this.filmTavsiyeBALFLIX.Location = new System.Drawing.Point(12, 9);
            this.filmTavsiyeBALFLIX.Name = "filmTavsiyeBALFLIX";
            this.filmTavsiyeBALFLIX.Size = new System.Drawing.Size(127, 36);
            this.filmTavsiyeBALFLIX.TabIndex = 0;
            this.filmTavsiyeBALFLIX.Text = "BALFLIX";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(822, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tavsiyeAnaLabel
            // 
            this.tavsiyeAnaLabel.AutoSize = true;
            this.tavsiyeAnaLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold);
            this.tavsiyeAnaLabel.Location = new System.Drawing.Point(26, 101);
            this.tavsiyeAnaLabel.Name = "tavsiyeAnaLabel";
            this.tavsiyeAnaLabel.Size = new System.Drawing.Size(844, 168);
            this.tavsiyeAnaLabel.TabIndex = 2;
            this.tavsiyeAnaLabel.Text = resources.GetString("tavsiyeAnaLabel.Text");
            // 
            // filmTavsiyesiHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(869, 337);
            this.Controls.Add(this.tavsiyeAnaLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.filmTavsiyeBALFLIX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "filmTavsiyesiHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BALFLIX";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filmTavsiyesiHelp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.filmTavsiyesiHelp_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filmTavsiyeBALFLIX;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tavsiyeAnaLabel;
    }
}