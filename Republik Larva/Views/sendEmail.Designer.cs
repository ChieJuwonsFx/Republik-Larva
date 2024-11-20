namespace Republik_Larva.Views
{
    partial class sendEmail
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            txtNamaTujuan = new TextBox();
            txtEmailTujuan = new TextBox();
            txtSubject = new TextBox();
            txtPesanEmail = new TextBox();
            btnSendEmail = new Button();
            btnDashboard = new Button();
            btnTransaksi = new Button();
            btnProduk = new Button();
            btnAkun = new Button();
            SuspendLayout();
            // 
            // txtNamaTujuan
            // 
            txtNamaTujuan.BorderStyle = BorderStyle.None;
            txtNamaTujuan.Cursor = Cursors.IBeam;
            txtNamaTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaTujuan.ForeColor = Color.Black;
            txtNamaTujuan.Location = new Point(502, 282);
            txtNamaTujuan.Name = "txtNamaTujuan";
            txtNamaTujuan.Size = new Size(924, 36);
            txtNamaTujuan.TabIndex = 1;
            txtNamaTujuan.TextChanged += txtNamaTujuan_TextChanged;
            // 
            // txtEmailTujuan
            // 
            txtEmailTujuan.BorderStyle = BorderStyle.None;
            txtEmailTujuan.Cursor = Cursors.IBeam;
            txtEmailTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailTujuan.ForeColor = Color.Black;
            txtEmailTujuan.Location = new Point(502, 406);
            txtEmailTujuan.Name = "txtEmailTujuan";
            txtEmailTujuan.Size = new Size(924, 36);
            txtEmailTujuan.TabIndex = 3;
            txtEmailTujuan.TextChanged += txtEmailTujuan_TextChanged;
            // 
            // txtSubject
            // 
            txtSubject.BorderStyle = BorderStyle.None;
            txtSubject.Cursor = Cursors.IBeam;
            txtSubject.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSubject.Location = new Point(502, 529);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(924, 36);
            txtSubject.TabIndex = 5;
            txtSubject.TextChanged += txtSubject_TextChanged;
            // 
            // txtPesanEmail
            // 
            txtPesanEmail.BorderStyle = BorderStyle.None;
            txtPesanEmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPesanEmail.Location = new Point(502, 648);
            txtPesanEmail.Multiline = true;
            txtPesanEmail.Name = "txtPesanEmail";
            txtPesanEmail.ScrollBars = ScrollBars.Vertical;
            txtPesanEmail.Size = new Size(924, 184);
            txtPesanEmail.TabIndex = 7;
            txtPesanEmail.TextChanged += txtPesanEmail_TextChanged;
            // 
            // btnSendEmail
            // 
            btnSendEmail.BackColor = Color.Transparent;
            btnSendEmail.BackgroundImageLayout = ImageLayout.None;
            btnSendEmail.Cursor = Cursors.Hand;
            btnSendEmail.FlatAppearance.BorderSize = 0;
            btnSendEmail.FlatStyle = FlatStyle.Flat;
            btnSendEmail.Location = new Point(847, 884);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(259, 72);
            btnSendEmail.TabIndex = 8;
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btn_sendEmail_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.BackgroundImageLayout = ImageLayout.None;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Location = new Point(708, 25);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(201, 72);
            btnDashboard.TabIndex = 9;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnTransaksi
            // 
            btnTransaksi.BackColor = Color.Transparent;
            btnTransaksi.BackgroundImageLayout = ImageLayout.None;
            btnTransaksi.Cursor = Cursors.Hand;
            btnTransaksi.FlatAppearance.BorderSize = 0;
            btnTransaksi.FlatStyle = FlatStyle.Flat;
            btnTransaksi.Location = new Point(930, 25);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(201, 72);
            btnTransaksi.TabIndex = 10;
            btnTransaksi.UseVisualStyleBackColor = false;
            btnTransaksi.Click += btnTransaksi_Click;
            // 
            // btnProduk
            // 
            btnProduk.BackColor = Color.Transparent;
            btnProduk.BackgroundImageLayout = ImageLayout.None;
            btnProduk.Cursor = Cursors.Hand;
            btnProduk.FlatAppearance.BorderSize = 0;
            btnProduk.FlatStyle = FlatStyle.Flat;
            btnProduk.Location = new Point(1158, 25);
            btnProduk.Name = "btnProduk";
            btnProduk.Size = new Size(216, 72);
            btnProduk.TabIndex = 11;
            btnProduk.UseVisualStyleBackColor = false;
            btnProduk.Click += btnProduk_Click;
            // 
            // btnAkun
            // 
            btnAkun.BackColor = Color.Transparent;
            btnAkun.BackgroundImageLayout = ImageLayout.None;
            btnAkun.Cursor = Cursors.Hand;
            btnAkun.FlatAppearance.BorderSize = 0;
            btnAkun.FlatStyle = FlatStyle.Flat;
            btnAkun.Location = new Point(1656, 25);
            btnAkun.Name = "btnAkun";
            btnAkun.Size = new Size(201, 72);
            btnAkun.TabIndex = 12;
            btnAkun.UseVisualStyleBackColor = false;
            btnAkun.Click += btnAkun_Click;
            // 
            // sendEmail
            // 
            BackgroundImage = Properties.Resources.sendEMail;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1920, 1080);
            Controls.Add(btnAkun);
            Controls.Add(btnProduk);
            Controls.Add(btnTransaksi);
            Controls.Add(btnDashboard);
            Controls.Add(btnSendEmail);
            Controls.Add(txtPesanEmail);
            Controls.Add(txtSubject);
            Controls.Add(txtEmailTujuan);
            Controls.Add(txtNamaTujuan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "sendEmail";
            Text = "Kirim Email";
            Load += sendEmail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNamaTujuan;
        private TextBox txtEmailTujuan;
        private TextBox txtSubject;
        private TextBox txtPesanEmail;
        private Button btnSendEmail;
        private Label lblFooter;
        private Button btnDashboard;
        private Button btnTransaksi;
        private Button btnProduk;
        private Button btnAkun;
    }
}
