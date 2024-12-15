namespace Republik_Larva.Views.Akun
{
    partial class V_TambahAdmin
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
            lblNamaAdmin = new TextBox();
            lblUsername = new TextBox();
            lblPassword = new TextBox();
            lblKonfirmPassword = new TextBox();
            btnSimpan = new Button();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // lblNamaAdmin
            // 
            lblNamaAdmin.BorderStyle = BorderStyle.None;
            lblNamaAdmin.Cursor = Cursors.IBeam;
            lblNamaAdmin.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamaAdmin.Location = new Point(487, 206);
            lblNamaAdmin.Name = "lblNamaAdmin";
            lblNamaAdmin.Size = new Size(918, 36);
            lblNamaAdmin.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.BorderStyle = BorderStyle.None;
            lblUsername.Cursor = Cursors.IBeam;
            lblUsername.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(487, 330);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(918, 36);
            lblUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.BorderStyle = BorderStyle.None;
            lblPassword.Cursor = Cursors.IBeam;
            lblPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(487, 455);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(918, 36);
            lblPassword.TabIndex = 2;
            lblPassword.TextChanged += lblPassword_TextChanged;
            // 
            // lblKonfirmPassword
            // 
            lblKonfirmPassword.BorderStyle = BorderStyle.None;
            lblKonfirmPassword.Cursor = Cursors.IBeam;
            lblKonfirmPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKonfirmPassword.Location = new Point(487, 581);
            lblKonfirmPassword.Name = "lblKonfirmPassword";
            lblKonfirmPassword.Size = new Size(918, 36);
            lblKonfirmPassword.TabIndex = 3;
            lblKonfirmPassword.TextChanged += lblKonfirmPassword_TextChanged;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.BackgroundImageLayout = ImageLayout.Stretch;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(835, 752);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(250, 70);
            btnSimpan.TabIndex = 4;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            btnSimpan.MouseEnter += btnSimpan_MouseEnter;
            btnSimpan.MouseLeave += btnSimpan_MouseLeave;
            // 
            // btnKembali
            // 
            btnKembali.BackgroundImage = Properties.Resources.kembali;
            btnKembali.Cursor = Cursors.Hand;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnKembali.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Location = new Point(100, 812);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(216, 74);
            btnKembali.TabIndex = 5;
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            btnKembali.MouseEnter += btnKembali_MouseEnter;
            btnKembali.MouseLeave += btnKembali_MouseLeave;
            // 
            // V_TambahAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formTambahAdmin;
            Controls.Add(btnKembali);
            Controls.Add(btnSimpan);
            Controls.Add(lblKonfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblNamaAdmin);
            Name = "V_TambahAdmin";
            Size = new Size(1920, 937);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lblNamaAdmin;
        private TextBox lblUsername;
        private TextBox lblPassword;
        private TextBox lblKonfirmPassword;
        private Button btnSimpan;
        private Button btnKembali;
    }
}
