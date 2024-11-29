namespace Republik_Larva.Views
{
    partial class V_Produk
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
            pnProduk = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnProduk
            // 
            pnProduk.BackColor = Color.Transparent;
            pnProduk.Location = new Point(98, 184);
            pnProduk.Name = "pnProduk";
            pnProduk.Padding = new Padding(10);
            pnProduk.Size = new Size(1702, 550);
            pnProduk.TabIndex = 1;
            // 
            // V_Produk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.semuaProduk;
            Controls.Add(pnProduk);
            Name = "V_Produk";
            Size = new Size(1920, 937);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnProduk;
    }
}
