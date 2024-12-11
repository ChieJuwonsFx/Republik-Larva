using System.Drawing;
using System.Windows.Forms;

namespace Republik_Larva.Views.Produk
{
    partial class cardProduk
    {
        private PictureBox imageProduk;
        private Label namaProduk;
        private Label harga;
        private Button btnEditProduk;
        private Label stok;

        private void InitializeComponent()
        {
            imageProduk = new PictureBox();
            namaProduk = new Label();
            harga = new Label();
            stok = new Label();
            btnEdit = new Button();
            btnHapus = new Button();
            ((System.ComponentModel.ISupportInitialize)imageProduk).BeginInit();
            SuspendLayout();
            // 
            // imageProduk
            // 
            imageProduk.Location = new Point(32, 33);
            imageProduk.Name = "imageProduk";
            imageProduk.Size = new Size(466, 262);
            imageProduk.SizeMode = PictureBoxSizeMode.Zoom;
            imageProduk.TabIndex = 0;
            imageProduk.TabStop = false;
            // 
            // namaProduk
            // 
            namaProduk.BackColor = Color.Transparent;
            namaProduk.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            namaProduk.Location = new Point(29, 329);
            namaProduk.Name = "namaProduk";
            namaProduk.Size = new Size(469, 42);
            namaProduk.TabIndex = 1;
            namaProduk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // harga
            // 
            harga.BackColor = Color.Transparent;
            harga.Font = new Font("Segoe UI", 13.8F);
            harga.Location = new Point(29, 375);
            harga.Name = "harga";
            harga.Size = new Size(469, 34);
            harga.TabIndex = 2;
            harga.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stok
            // 
            stok.BackColor = Color.Transparent;
            stok.Font = new Font("Segoe UI", 10.2F);
            stok.Location = new Point(33, 417);
            stok.Name = "stok";
            stok.Size = new Size(465, 25);
            stok.TabIndex = 4;
            // 
            // btnEdit
            // 
            btnEdit.BackgroundImage = Properties.Resources.editProduk;
            btnEdit.BackgroundImageLayout = ImageLayout.Stretch;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(429, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(69, 69);
            btnEdit.TabIndex = 5;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.MouseEnter += btnEdit_MouseEnter;
            btnEdit.MouseLeave += btnEdit_MouseLeave;
            // 
            // btnHapus
            // 
            btnHapus.BackgroundImage = Properties.Resources.hapusProduk;
            btnHapus.BackgroundImageLayout = ImageLayout.Stretch;
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Location = new Point(32, 226);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(69, 69);
            btnHapus.TabIndex = 6;
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.MouseLeave += btnHapus_MouseLeave;
            btnHapus.MouseEnter += btnHapus_MouseEnter;
            // 
            // cardProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.cardProduk;
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(stok);
            Controls.Add(harga);
            Controls.Add(namaProduk);
            Controls.Add(imageProduk);
            Margin = new Padding(30, 30, 3, 3);
            Name = "cardProduk";
            Size = new Size(531, 550);
            ((System.ComponentModel.ISupportInitialize)imageProduk).EndInit();
            ResumeLayout(false);
        }

        public Button btnEdit;
        public PictureBox pictureBox1;
        public Button btnHapus;
    }
}
