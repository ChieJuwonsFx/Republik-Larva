namespace Republik_Larva.Views.Transaksi
{
    partial class V_TambahTransaksi
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
            statusPembayaran = new ComboBox();
            namaCustomer = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            email = new TextBox();
            metodePembayaran = new ComboBox();
            listPreview = new ListBox();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // statusPembayaran
            // 
            statusPembayaran.FlatStyle = FlatStyle.Flat;
            statusPembayaran.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusPembayaran.FormattingEnabled = true;
            statusPembayaran.Location = new Point(191, 589);
            statusPembayaran.Name = "statusPembayaran";
            statusPembayaran.Size = new Size(932, 45);
            statusPembayaran.TabIndex = 0;
            // 
            // namaCustomer
            // 
            namaCustomer.BorderStyle = BorderStyle.None;
            namaCustomer.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaCustomer.Location = new Point(191, 187);
            namaCustomer.Name = "namaCustomer";
            namaCustomer.Size = new Size(936, 36);
            namaCustomer.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(182, 418);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(952, 113);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // email
            // 
            email.BorderStyle = BorderStyle.None;
            email.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            email.Location = new Point(191, 313);
            email.Name = "email";
            email.Size = new Size(936, 36);
            email.TabIndex = 3;
            // 
            // metodePembayaran
            // 
            metodePembayaran.FlatStyle = FlatStyle.Flat;
            metodePembayaran.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            metodePembayaran.FormattingEnabled = true;
            metodePembayaran.Location = new Point(191, 712);
            metodePembayaran.Name = "metodePembayaran";
            metodePembayaran.Size = new Size(932, 45);
            metodePembayaran.TabIndex = 4;
            // 
            // listPreview
            // 
            listPreview.BackColor = Color.FromArgb(230, 215, 184);
            listPreview.BorderStyle = BorderStyle.None;
            listPreview.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listPreview.FormattingEnabled = true;
            listPreview.ItemHeight = 37;
            listPreview.Location = new Point(1309, 112);
            listPreview.Name = "listPreview";
            listPreview.Size = new Size(531, 333);
            listPreview.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(177, 802);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(250, 70);
            btnSimpan.TabIndex = 6;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // V_TambahTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formTambahTransaksi;
            Controls.Add(btnSimpan);
            Controls.Add(listPreview);
            Controls.Add(metodePembayaran);
            Controls.Add(email);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(namaCustomer);
            Controls.Add(statusPembayaran);
            Name = "V_TambahTransaksi";
            Size = new Size(1920, 937);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox statusPembayaran;
        private TextBox namaCustomer;
        public FlowLayoutPanel flowLayoutPanel1;
        private TextBox email;
        private ComboBox metodePembayaran;
        public ListBox listPreview;
        private Button btnSimpan;
    }
}
