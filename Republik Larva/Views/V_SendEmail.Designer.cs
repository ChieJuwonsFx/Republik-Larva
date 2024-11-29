namespace Republik_Larva.Views
{
    partial class V_SendEmail
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
            namaTujuan = new TextBox();
            emailTujuan = new TextBox();
            subject = new TextBox();
            pesan = new RichTextBox();
            btnSendEmail = new Button();
            SuspendLayout();
            // 
            // namaTujuan
            // 
            namaTujuan.BorderStyle = BorderStyle.None;
            namaTujuan.Cursor = Cursors.IBeam;
            namaTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaTujuan.Location = new Point(489, 206);
            namaTujuan.Name = "namaTujuan";
            namaTujuan.Size = new Size(917, 36);
            namaTujuan.TabIndex = 0;
            namaTujuan.TextChanged += namaTujuan_TextChanged;
            // 
            // emailTujuan
            // 
            emailTujuan.BorderStyle = BorderStyle.None;
            emailTujuan.Cursor = Cursors.IBeam;
            emailTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTujuan.Location = new Point(489, 331);
            emailTujuan.Name = "emailTujuan";
            emailTujuan.Size = new Size(917, 36);
            emailTujuan.TabIndex = 1;
            emailTujuan.TextChanged += emailTujuan_TextChanged;
            // 
            // subject
            // 
            subject.BorderStyle = BorderStyle.None;
            subject.Cursor = Cursors.IBeam;
            subject.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subject.Location = new Point(489, 456);
            subject.Name = "subject";
            subject.Size = new Size(917, 36);
            subject.TabIndex = 2;
            subject.TextChanged += subject_TextChanged;
            // 
            // pesan
            // 
            pesan.BorderStyle = BorderStyle.None;
            pesan.Cursor = Cursors.IBeam;
            pesan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pesan.Location = new Point(489, 575);
            pesan.Name = "pesan";
            pesan.ScrollBars = RichTextBoxScrollBars.Vertical;
            pesan.Size = new Size(917, 186);
            pesan.TabIndex = 3;
            pesan.Text = "";
            pesan.TextChanged += pesan_TextChanged;
            // 
            // btnSendEmail
            // 
            btnSendEmail.BackColor = Color.Transparent;
            btnSendEmail.BackgroundImageLayout = ImageLayout.Stretch;
            btnSendEmail.Cursor = Cursors.Hand;
            btnSendEmail.FlatAppearance.BorderSize = 0;
            btnSendEmail.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSendEmail.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSendEmail.FlatStyle = FlatStyle.Flat;
            btnSendEmail.Location = new Point(835, 808);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(250, 70);
            btnSendEmail.TabIndex = 4;
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // V_SendEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.sendEmail;
            Controls.Add(btnSendEmail);
            Controls.Add(pesan);
            Controls.Add(subject);
            Controls.Add(emailTujuan);
            Controls.Add(namaTujuan);
            Name = "V_SendEmail";
            Size = new Size(1920, 937);
            Load += V_SendEmail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox namaTujuan;
        private TextBox emailTujuan;
        private TextBox subject;
        private RichTextBox pesan;
        private Button btnSendEmail;
    }
}
