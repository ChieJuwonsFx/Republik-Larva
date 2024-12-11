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
            dataGridView1 = new DataGridView();
            uploadFile = new Button();
            namaFile = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // namaTujuan
            // 
            namaTujuan.BorderStyle = BorderStyle.None;
            namaTujuan.Cursor = Cursors.IBeam;
            namaTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaTujuan.Location = new Point(320, 206);
            namaTujuan.Name = "namaTujuan";
            namaTujuan.Size = new Size(917, 36);
            namaTujuan.TabIndex = 0;
            // 
            // emailTujuan
            // 
            emailTujuan.BorderStyle = BorderStyle.None;
            emailTujuan.Cursor = Cursors.IBeam;
            emailTujuan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTujuan.Location = new Point(320, 330);
            emailTujuan.Name = "emailTujuan";
            emailTujuan.Size = new Size(917, 36);
            emailTujuan.TabIndex = 1;
            // 
            // subject
            // 
            subject.BorderStyle = BorderStyle.None;
            subject.Cursor = Cursors.IBeam;
            subject.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subject.Location = new Point(320, 456);
            subject.Name = "subject";
            subject.Size = new Size(917, 36);
            subject.TabIndex = 2;
            // 
            // pesan
            // 
            pesan.BorderStyle = BorderStyle.None;
            pesan.Cursor = Cursors.IBeam;
            pesan.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pesan.Location = new Point(320, 577);
            pesan.Name = "pesan";
            pesan.ScrollBars = RichTextBoxScrollBars.Vertical;
            pesan.Size = new Size(917, 128);
            pesan.TabIndex = 3;
            pesan.Text = "";
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
            btnSendEmail.Location = new Point(669, 808);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(250, 70);
            btnSendEmail.TabIndex = 4;
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btnSendEmail_Click;
            btnSendEmail.MouseEnter += btnSendEmail_MouseEnter;
            btnSendEmail.MouseLeave += btnSendEmail_MouseLeave;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(245, 242, 214);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1382, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(486, 855);
            dataGridView1.TabIndex = 5;
            // 
            // uploadFile
            // 
            uploadFile.BackColor = Color.Transparent;
            uploadFile.FlatAppearance.BorderSize = 0;
            uploadFile.FlatAppearance.MouseDownBackColor = Color.Transparent;
            uploadFile.FlatAppearance.MouseOverBackColor = Color.Transparent;
            uploadFile.FlatStyle = FlatStyle.Flat;
            uploadFile.Location = new Point(292, 735);
            uploadFile.Name = "uploadFile";
            uploadFile.Size = new Size(282, 29);
            uploadFile.TabIndex = 6;
            uploadFile.UseVisualStyleBackColor = false;
            uploadFile.Click += uploadFile_Click;
            // 
            // namaFile
            // 
            namaFile.BackColor = Color.Transparent;
            namaFile.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaFile.Location = new Point(594, 735);
            namaFile.Name = "namaFile";
            namaFile.Size = new Size(672, 39);
            namaFile.TabIndex = 7;
            // 
            // V_SendEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.sendEmail;
            Controls.Add(namaFile);
            Controls.Add(uploadFile);
            Controls.Add(dataGridView1);
            Controls.Add(btnSendEmail);
            Controls.Add(pesan);
            Controls.Add(subject);
            Controls.Add(emailTujuan);
            Controls.Add(namaTujuan);
            Name = "V_SendEmail";
            Size = new Size(1920, 937);
            Load += V_SendEmail_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox namaTujuan;
        private TextBox emailTujuan;
        private TextBox subject;
        private RichTextBox pesan;
        private Button btnSendEmail;
        private DataGridView dataGridView1;
        private Button uploadFile;
        private Label namaFile;
    }
}
