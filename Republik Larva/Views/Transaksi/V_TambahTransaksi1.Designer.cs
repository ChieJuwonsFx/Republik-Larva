namespace Republik_Larva.Views.Transaksi
{
    partial class V_TambahTransaksi1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelProduk;

        /// <summary>
        /// Bersihkan sumber daya yang digunakan.
        /// </summary>
        /// <param name="disposing">true jika sumber daya dikelola harus dibuang; jika tidak, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Metode yang diperlukan untuk mendukung Designer
        /// </summary>
        private void InitializeComponent()
        {
            panelProduk = new Panel();
            SuspendLayout();
            // 
            // panelProduk
            // 
            panelProduk.AutoScroll = true;
            panelProduk.Dock = DockStyle.Fill;
            panelProduk.Location = new Point(0, 0);
            panelProduk.Margin = new Padding(4, 5, 4, 5);
            panelProduk.Name = "panelProduk";
            panelProduk.Size = new Size(533, 462);
            panelProduk.TabIndex = 0;
            // 
            // V_TambahTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelProduk);
            Margin = new Padding(4, 5, 4, 5);
            Name = "V_TambahTransaksi";
            Size = new Size(533, 462);
            ResumeLayout(false);
        }
    }
}
