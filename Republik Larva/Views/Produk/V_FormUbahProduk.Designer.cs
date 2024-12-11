namespace Republik_Larva.Views.Produk
{
    partial class V_FormUbahProduk
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
            pictureBox1 = new PictureBox();
            uploadGambar = new Button();
            namaProduk = new TextBox();
            harga = new TextBox();
            stok = new TextBox();
            btnSimpan = new Button();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(753, 142);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(415, 238);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            uploadGambar.TabIndex = 1;
            uploadGambar.UseVisualStyleBackColor = false;
            uploadGambar.Click += uploadGambar_Click;
            // 
            // namaProduk
            // 
            namaProduk.BorderStyle = BorderStyle.None;
            namaProduk.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namaProduk.Location = new Point(502, 473);
            namaProduk.Name = "namaProduk";
            namaProduk.Size = new Size(922, 36);
            namaProduk.TabIndex = 3;
            // 
            // harga
            // 
            harga.BorderStyle = BorderStyle.None;
            harga.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            harga.Location = new Point(502, 595);
            harga.Name = "harga";
            harga.Size = new Size(922, 36);
            harga.TabIndex = 4;
            // 
            // stok
            // 
            stok.BorderStyle = BorderStyle.None;
            stok.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stok.Location = new Point(502, 719);
            stok.Name = "stok";
            stok.Size = new Size(922, 36);
            stok.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(835, 804);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(250, 70);
            btnSimpan.TabIndex = 7;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            btnSimpan.MouseLeave += btnSimpan_MouseLeave;
            btnSimpan.MouseEnter += btnSimpan_MouseEnter;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Transparent;
            btnKembali.Cursor = Cursors.Hand;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnKembali.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Location = new Point(117, 818);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(216, 74);
            btnKembali.TabIndex = 8;
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            btnKembali.MouseEnter += btnKembali_MouseEnter;
            btnKembali.MouseLeave += btnKembali_MouseLeave;
            // 
            // V_FormUbahProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.formEditProduk;
            Controls.Add(btnKembali);
            Controls.Add(btnSimpan);
            Controls.Add(stok);
            Controls.Add(harga);
            Controls.Add(namaProduk);
            Controls.Add(uploadGambar);
            Controls.Add(pictureBox1);
            Name = "V_FormUbahProduk";
            Size = new Size(1920, 937);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private PictureBox pictureBox1;
        private Button uploadGambar;
        private TextBox namaProduk;
        private TextBox harga;
        private TextBox stok;
        private Button btnSimpan;
        private Button btnKembali;
    }
}
