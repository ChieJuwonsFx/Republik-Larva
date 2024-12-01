namespace Republik_Larva.Views
{
    partial class V_Akun
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClose = new Button();
            nama = new Label();
            username = new Label();
            btnLogout = new Button();
            btnTambahAdmin = new Button();
            btnEditAdmin = new Button();
            btnLihatSemua = new Button();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(94, 804);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(271, 76);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // nama
            // 
            nama.BackColor = Color.Transparent;
            nama.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nama.Location = new Point(827, 386);
            nama.Name = "nama";
            nama.Size = new Size(276, 44);
            nama.TabIndex = 1;
            nama.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            username.BackColor = Color.Transparent;
            username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(858, 433);
            username.Name = "username";
            username.Size = new Size(211, 30);
            username.TabIndex = 2;
            username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(1555, 804);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(271, 76);
            btnLogout.TabIndex = 3;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            btnLogout.MouseEnter += btnLogout_MouseEnter;
            btnLogout.MouseLeave += btnLogout_MouseLeave;
            // 
            // btnTambahAdmin
            // 
            btnTambahAdmin.BackColor = Color.Transparent;
            btnTambahAdmin.BackgroundImageLayout = ImageLayout.Stretch;
            btnTambahAdmin.Cursor = Cursors.Hand;
            btnTambahAdmin.FlatAppearance.BorderSize = 0;
            btnTambahAdmin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTambahAdmin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTambahAdmin.FlatStyle = FlatStyle.Flat;
            btnTambahAdmin.Location = new Point(1142, 553);
            btnTambahAdmin.Name = "btnTambahAdmin";
            btnTambahAdmin.Size = new Size(303, 98);
            btnTambahAdmin.TabIndex = 4;
            btnTambahAdmin.UseVisualStyleBackColor = false;
            btnTambahAdmin.Click += btnTambahAdmin_Click;
            btnTambahAdmin.MouseEnter += btnTambahAdmin_MouseEnter;
            btnTambahAdmin.MouseLeave += btnTambahAdmin_MouseLeave;
            // 
            // btnEditAdmin
            // 
            btnEditAdmin.BackColor = Color.Transparent;
            btnEditAdmin.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditAdmin.Cursor = Cursors.Hand;
            btnEditAdmin.FlatAppearance.BorderSize = 0;
            btnEditAdmin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEditAdmin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEditAdmin.FlatStyle = FlatStyle.Flat;
            btnEditAdmin.Location = new Point(826, 553);
            btnEditAdmin.Name = "btnEditAdmin";
            btnEditAdmin.Size = new Size(286, 98);
            btnEditAdmin.TabIndex = 5;
            btnEditAdmin.UseVisualStyleBackColor = false;
            btnEditAdmin.Click += btnEditAdmin_Click;
            btnEditAdmin.MouseEnter += btnEditAdmin_MouseEnter;
            btnEditAdmin.MouseLeave += btnEditAdmin_MouseLeave;
            // 
            // btnLihatSemua
            // 
            btnLihatSemua.BackColor = Color.Transparent;
            btnLihatSemua.BackgroundImageLayout = ImageLayout.Stretch;
            btnLihatSemua.Cursor = Cursors.Hand;
            btnLihatSemua.FlatAppearance.BorderSize = 0;
            btnLihatSemua.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLihatSemua.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLihatSemua.FlatStyle = FlatStyle.Flat;
            btnLihatSemua.Location = new Point(475, 553);
            btnLihatSemua.Name = "btnLihatSemua";
            btnLihatSemua.Size = new Size(321, 98);
            btnLihatSemua.TabIndex = 6;
            btnLihatSemua.UseVisualStyleBackColor = false;
            btnLihatSemua.Click += btnLihatSemua_Click;
            btnLihatSemua.MouseEnter += btnLihatSemua_MouseEnter;
            btnLihatSemua.MouseLeave += btnLihatSemua_MouseLeave;
            // 
            // V_Akun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.akun;
            Controls.Add(btnLihatSemua);
            Controls.Add(btnEditAdmin);
            Controls.Add(btnTambahAdmin);
            Controls.Add(btnLogout);
            Controls.Add(username);
            Controls.Add(nama);
            Controls.Add(btnClose);
            Name = "V_Akun";
            Size = new Size(1920, 937);
            Load += V_Akun_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Label nama;
        private Label username;
        private Button btnLogout;
        private Button btnTambahAdmin;
        private Button btnEditAdmin;
        private Button btnLihatSemua;
    }
}
