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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridProduk = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridProduk).BeginInit();
            SuspendLayout();
            // 
            // dataGridProduk
            // 
            dataGridProduk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProduk.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridProduk.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridProduk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridProduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProduk.GridColor = SystemColors.HighlightText;
            dataGridProduk.Location = new Point(201, 282);
            dataGridProduk.Name = "dataGridProduk";
            dataGridProduk.RowHeadersWidth = 51;
            dataGridProduk.Size = new Size(1536, 567);
            dataGridProduk.TabIndex = 0;
            dataGridProduk.CellContentClick += dataGridProduk_CellContentClick;
            // 
            // V_Produk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.kelolaProduk;
            ClientSize = new Size(1920, 1080);
            Controls.Add(dataGridProduk);
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_Produk";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridProduk).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridProduk;
    }
}