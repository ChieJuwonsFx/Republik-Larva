namespace Republik_Larva.Views
{
    partial class V_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Dashboard));
            btnProduk = new Button();
            btnTransaksi = new Button();
            btnEmail = new Button();
            btnAkun = new Button();
            SuspendLayout();
            // 
            // btnProduk
            // 
            btnProduk.BackColor = Color.Transparent;
            btnProduk.FlatAppearance.BorderSize = 0;
            btnProduk.FlatStyle = FlatStyle.Flat;
            btnProduk.Location = new Point(1153, 30);
            btnProduk.Name = "btnProduk";
            btnProduk.Size = new Size(219, 62);
            btnProduk.TabIndex = 0;
            btnProduk.UseVisualStyleBackColor = false;
            btnProduk.Click += btnProduk_Click;
            // 
            // btnTransaksi
            // 
            btnTransaksi.BackColor = Color.Transparent;
            btnTransaksi.FlatAppearance.BorderSize = 0;
            btnTransaksi.FlatStyle = FlatStyle.Flat;
            btnTransaksi.Location = new Point(943, 30);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(171, 62);
            btnTransaksi.TabIndex = 1;
            btnTransaksi.UseVisualStyleBackColor = false;
            btnTransaksi.Click += btnTransaksi_Click;
            // 
            // btnEmail
            // 
            btnEmail.BackColor = Color.Transparent;
            btnEmail.FlatAppearance.BorderSize = 0;
            btnEmail.FlatStyle = FlatStyle.Flat;
            btnEmail.Location = new Point(1423, 30);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(197, 62);
            btnEmail.TabIndex = 2;
            btnEmail.UseVisualStyleBackColor = false;
            btnEmail.Click += btnEmail_Click;
            // 
            // btnAkun
            // 
            btnAkun.BackColor = Color.Transparent;
            btnAkun.FlatAppearance.BorderSize = 0;
            btnAkun.FlatStyle = FlatStyle.Flat;
            btnAkun.Location = new Point(1663, 30);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(191, 62);
            btnAkun.TabIndex = 3;
            btnAkun.UseVisualStyleBackColor = false;
            btnAkun.Click += btnAkun_Click;
            // 
            // V_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1920, 937);
            Controls.Add(btnAkun);
            Controls.Add(btnEmail);
            Controls.Add(btnTransaksi);
            Controls.Add(btnProduk);
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_Dashboard";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnProduk;
        private Button btnTransaksi;
        private Button btnEmail;
        private Button btnAkun;
    }
}