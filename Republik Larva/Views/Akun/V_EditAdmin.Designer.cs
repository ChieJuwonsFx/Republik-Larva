namespace Republik_Larva.Views.Akun
{
    partial class V_EditAdmin
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
            namaAdmin = new TextBox();
            password = new TextBox();
            konfirmPassword = new TextBox();
            username = new Label();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // namaAdmin
            // 
            namaAdmin.BorderStyle = BorderStyle.None;
            namaAdmin.Cursor = Cursors.IBeam;
            namaAdmin.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaAdmin.Location = new Point(485, 206);
            namaAdmin.Name = "namaAdmin";
            namaAdmin.Size = new Size(922, 36);
            namaAdmin.TabIndex = 0;
            // 
            // password
            // 
            password.BorderStyle = BorderStyle.None;
            password.Cursor = Cursors.IBeam;
            password.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password.Location = new Point(485, 455);
            password.Name = "password";
            password.Size = new Size(922, 36);
            password.TabIndex = 1;
            password.TextChanged += password_TextChanged;
            // 
            // konfirmPassword
            // 
            konfirmPassword.BorderStyle = BorderStyle.None;
            konfirmPassword.Cursor = Cursors.IBeam;
            konfirmPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            konfirmPassword.Location = new Point(485, 581);
            konfirmPassword.Name = "konfirmPassword";
            konfirmPassword.Size = new Size(922, 36);
            konfirmPassword.TabIndex = 2;
            konfirmPassword.TextChanged += konfirmPassword_TextChanged;
            // 
            // username
            // 
            username.BackColor = Color.Transparent;
            username.FlatStyle = FlatStyle.Flat;
            username.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(485, 329);
            username.Name = "username";
            username.Size = new Size(922, 38);
            username.TabIndex = 3;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
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
            // 
            // V_EditAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formEditAdmin;
            Controls.Add(btnSimpan);
            Controls.Add(username);
            Controls.Add(konfirmPassword);
            Controls.Add(password);
            Controls.Add(namaAdmin);
            Name = "V_EditAdmin";
            Size = new Size(1920, 937);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox namaAdmin;
        private TextBox password;
        private TextBox konfirmPassword;
        private Label username;
        private Button btnSimpan;
    }
}
