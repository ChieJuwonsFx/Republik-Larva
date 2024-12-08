﻿using System.Drawing;
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
            btnEditProduk = new Button();
            stok = new Label();
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
            imageProduk.Click += imageProduk_Click;
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
            // btnEditProduk
            // 
            btnEditProduk.BackgroundImage = Properties.Resources.editProduk;
            btnEditProduk.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditProduk.FlatAppearance.BorderSize = 0;
            btnEditProduk.FlatStyle = FlatStyle.Flat;
            btnEditProduk.Location = new Point(429, 226);
            btnEditProduk.Name = "btnEditProduk";
            btnEditProduk.Size = new Size(69, 69);
            btnEditProduk.TabIndex = 3;
            btnEditProduk.UseVisualStyleBackColor = true;
            btnEditProduk.Click += btnEditProduk_Click;
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
            // cardProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.cardProduk;
            Controls.Add(stok);
            Controls.Add(btnEditProduk);
            Controls.Add(harga);
            Controls.Add(namaProduk);
            Controls.Add(imageProduk);
            Margin = new Padding(30, 30, 3, 3);
            Name = "cardProduk";
            Size = new Size(531, 550);
            ((System.ComponentModel.ISupportInitialize)imageProduk).EndInit();
            ResumeLayout(false);
        }
    }
}
