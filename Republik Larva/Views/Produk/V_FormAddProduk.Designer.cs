namespace Republik_Larva.Views.Produk
{
    partial class V_FormAddProduk
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
            uploadGambar = new Button();
            ambilGambar = new Button();
            namaProduk = new TextBox();
            harga = new TextBox();
            stok = new TextBox();
            btnKembali = new Button();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // uploadGambar
            // 
            uploadGambar.BackColor = Color.Transparent;
            uploadGambar.Cursor = Cursors.Hand;
            uploadGambar.FlatAppearance.BorderSize = 0;
            uploadGambar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            uploadGambar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            uploadGambar.FlatStyle = FlatStyle.Flat;
            uploadGambar.Location = new Point(853, 388);
            uploadGambar.Name = "uploadGambar";
            uploadGambar.Size = new Size(217, 29);
            uploadGambar.TabIndex = 0;
            uploadGambar.UseVisualStyleBackColor = false;
            // 
            // ambilGambar
            // 
            ambilGambar.BackColor = Color.Transparent;
            ambilGambar.Cursor = Cursors.Hand;
            ambilGambar.FlatAppearance.BorderSize = 0;
            ambilGambar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ambilGambar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ambilGambar.FlatStyle = FlatStyle.Flat;
            ambilGambar.Location = new Point(751, 145);
            ambilGambar.Name = "ambilGambar";
            ambilGambar.Size = new Size(420, 237);
            ambilGambar.TabIndex = 1;
            ambilGambar.UseVisualStyleBackColor = false;
            // 
            // namaProduk
            // 
            namaProduk.BorderStyle = BorderStyle.None;
            namaProduk.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaProduk.Location = new Point(502, 473);
            namaProduk.Name = "namaProduk";
            namaProduk.Size = new Size(922, 36);
            namaProduk.TabIndex = 2;
            // 
            // harga
            // 
            harga.BorderStyle = BorderStyle.None;
            harga.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            harga.Location = new Point(502, 595);
            harga.Name = "harga";
            harga.Size = new Size(922, 36);
            harga.TabIndex = 3;
            // 
            // stok
            // 
            stok.BorderStyle = BorderStyle.None;
            stok.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stok.Location = new Point(502, 719);
            stok.Name = "stok";
            stok.Size = new Size(922, 36);
            stok.TabIndex = 4;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Transparent;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnKembali.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Location = new Point(117, 818);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(216, 74);
            btnKembali.TabIndex = 5;
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(835, 804);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(250, 70);
            btnSimpan.TabIndex = 6;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // V_FormAddProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formTambahProduk;
            Controls.Add(btnSimpan);
            Controls.Add(btnKembali);
            Controls.Add(stok);
            Controls.Add(harga);
            Controls.Add(namaProduk);
            Controls.Add(ambilGambar);
            Controls.Add(uploadGambar);
            Name = "V_FormAddProduk";
            Size = new Size(1920, 937);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button uploadGambar;
        private Button ambilGambar;
        private TextBox namaProduk;
        private TextBox harga;
        private TextBox stok;
        private Button btnKembali;
        private Button btnSimpan;
    }
}
