namespace Republik_Larva.Views.Akun
{
    partial class cardAdmin
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
            namaAdmin = new Label();
            username = new Label();
            adminId = new Label();
            label1 = new Label();
            btnHapus = new Button();
            SuspendLayout();
            // 
            // namaAdmin
            // 
            namaAdmin.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namaAdmin.Location = new Point(60, 340);
            namaAdmin.Name = "namaAdmin";
            namaAdmin.Size = new Size(309, 40);
            namaAdmin.TabIndex = 0;
            namaAdmin.Text = "Nama";
            namaAdmin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(60, 380);
            username.Name = "username";
            username.Size = new Size(309, 40);
            username.TabIndex = 1;
            username.Text = "username";
            username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminId
            // 
            adminId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminId.Location = new Point(60, 292);
            adminId.Name = "adminId";
            adminId.Size = new Size(309, 40);
            adminId.TabIndex = 2;
            adminId.Text = "id";
            adminId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(92, 502);
            label1.Name = "label1";
            label1.Size = new Size(240, 28);
            label1.TabIndex = 3;
            label1.Text = "~ Admin Republik Larva ~";
            // 
            // button1
            // 
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHapus.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Location = new Point(346, 16);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(69, 69);
            btnHapus.TabIndex = 4;
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += this.btnHapus_Click;
            // 
            // cardAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = Properties.Resources.cardAdmin;
            Controls.Add(btnHapus);
            Controls.Add(label1);
            Controls.Add(adminId);
            Controls.Add(username);
            Controls.Add(namaAdmin);
            Name = "cardAdmin";
            Size = new Size(430, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label namaAdmin;
        private Label username;
        private Label adminId;
        private Label label1;
        public Button btnHapus;
    }
}
