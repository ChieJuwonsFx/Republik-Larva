namespace Republik_Larva.Views.Transaksi
{
    partial class V_BatalkanTransaksi
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
            dataGridTransaksi = new DataGridView();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridTransaksi).BeginInit();
            SuspendLayout();
            // 
            // dataGridTransaksi
            // 
            dataGridTransaksi.BackgroundColor = Color.FromArgb(245, 242, 214);
            dataGridTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTransaksi.Location = new Point(159, 167);
            dataGridTransaksi.Margin = new Padding(4, 5, 4, 5);
            dataGridTransaksi.Name = "dataGridTransaksi";
            dataGridTransaksi.RowHeadersWidth = 51;
            dataGridTransaksi.Size = new Size(1598, 580);
            dataGridTransaksi.TabIndex = 0;
            dataGridTransaksi.CellContentClick += dataGridTransaksi_CellContentClick;
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
            btnKembali.TabIndex = 1;
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            btnKembali.MouseEnter += btnKembali_MouseEnter;
            btnKembali.MouseLeave += btnKembali_MouseLeave;
            // 
            // V_BatalkanTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.batalkanTransaksi;
            Controls.Add(dataGridTransaksi);
            Controls.Add(btnKembali);
            Margin = new Padding(4, 5, 4, 5);
            Name = "V_BatalkanTransaksi";
            Size = new Size(2560, 1442);
            ((System.ComponentModel.ISupportInitialize)dataGridTransaksi).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridTransaksi;
        private Button btnKembali;
    }
}
