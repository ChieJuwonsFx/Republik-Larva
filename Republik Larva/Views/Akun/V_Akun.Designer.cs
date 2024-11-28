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
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.close;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
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
            // 
            // nama
            // 
            nama.BackColor = Color.Transparent;
            nama.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nama.Location = new Point(827, 386);
            nama.Name = "nama";
            nama.Size = new Size(276, 44);
            nama.TabIndex = 1;
            nama.Text = "label1";
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
            username.Text = "label2";
            username.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // V_Akun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.akun;
            Controls.Add(username);
            Controls.Add(nama);
            Controls.Add(btnClose);
            Name = "V_Akun";
            Size = new Size(1920, 937);
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Label nama;
        private Label username;
    }
}
