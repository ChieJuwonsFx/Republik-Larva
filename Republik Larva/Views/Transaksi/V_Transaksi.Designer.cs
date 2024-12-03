namespace Republik_Larva.Views
{
    partial class V_Transaksi
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
            dataGridView1 = new DataGridView();
            jumlahTransaksi = new Label();
            totalPenghasilan = new Label();
            jumlahMaggot = new Label();
            btnTambahTransaksi = new Button();
            btnRiwayat = new Button();
            btnBelumBayar = new Button();
            btnLihatSemua = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(245, 242, 214);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(295, 439);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1327, 241);
            dataGridView1.TabIndex = 0;
            // 
            // jumlahTransaksi
            // 
            jumlahTransaksi.BackColor = Color.Transparent;
            jumlahTransaksi.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jumlahTransaksi.Location = new Point(288, 184);
            jumlahTransaksi.Name = "jumlahTransaksi";
            jumlahTransaksi.Size = new Size(378, 81);
            jumlahTransaksi.TabIndex = 1;
            jumlahTransaksi.Text = "label1";
            jumlahTransaksi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalPenghasilan
            // 
            totalPenghasilan.BackColor = Color.Transparent;
            totalPenghasilan.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalPenghasilan.Location = new Point(786, 184);
            totalPenghasilan.Name = "totalPenghasilan";
            totalPenghasilan.Size = new Size(378, 81);
            totalPenghasilan.TabIndex = 2;
            totalPenghasilan.Text = "label2";
            totalPenghasilan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // jumlahMaggot
            // 
            jumlahMaggot.BackColor = Color.Transparent;
            jumlahMaggot.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jumlahMaggot.Location = new Point(1257, 184);
            jumlahMaggot.Name = "jumlahMaggot";
            jumlahMaggot.Size = new Size(378, 81);
            jumlahMaggot.TabIndex = 3;
            jumlahMaggot.Text = "label3";
            jumlahMaggot.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTambahTransaksi
            // 
            btnTambahTransaksi.BackColor = Color.Transparent;
            btnTambahTransaksi.Cursor = Cursors.Hand;
            btnTambahTransaksi.FlatAppearance.BorderSize = 0;
            btnTambahTransaksi.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTambahTransaksi.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTambahTransaksi.FlatStyle = FlatStyle.Flat;
            btnTambahTransaksi.Location = new Point(256, 759);
            btnTambahTransaksi.Name = "btnTambahTransaksi";
            btnTambahTransaksi.Size = new Size(330, 111);
            btnTambahTransaksi.TabIndex = 4;
            btnTambahTransaksi.UseVisualStyleBackColor = false;
            btnTambahTransaksi.Click += btnTambahTransaksi_Click;
            btnTambahTransaksi.MouseEnter += btnTambahTransaksi_MouseEnter;
            btnTambahTransaksi.MouseLeave += btnTambahTransaksi_MouseLeave;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Location = new Point(616, 759);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(330, 111);
            btnRiwayat.TabIndex = 5;
            btnRiwayat.UseVisualStyleBackColor = false;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnBelumBayar
            // 
            btnBelumBayar.BackColor = Color.Transparent;
            btnBelumBayar.FlatAppearance.BorderSize = 0;
            btnBelumBayar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBelumBayar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBelumBayar.FlatStyle = FlatStyle.Flat;
            btnBelumBayar.Location = new Point(975, 759);
            btnBelumBayar.Name = "btnBelumBayar";
            btnBelumBayar.Size = new Size(330, 111);
            btnBelumBayar.TabIndex = 6;
            btnBelumBayar.UseVisualStyleBackColor = false;
            btnBelumBayar.Click += btnBelumBayar_Click;
            // 
            // btnLihatSemua
            // 
            btnLihatSemua.BackColor = Color.Transparent;
            btnLihatSemua.FlatAppearance.BorderSize = 0;
            btnLihatSemua.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLihatSemua.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLihatSemua.FlatStyle = FlatStyle.Flat;
            btnLihatSemua.Location = new Point(1335, 759);
            btnLihatSemua.Name = "btnLihatSemua";
            btnLihatSemua.Size = new Size(330, 111);
            btnLihatSemua.TabIndex = 7;
            btnLihatSemua.UseVisualStyleBackColor = false;
            btnLihatSemua.Click += btnLihatSemua_Click;
            // 
            // V_Transaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.transaksi;
            Controls.Add(btnLihatSemua);
            Controls.Add(btnBelumBayar);
            Controls.Add(btnRiwayat);
            Controls.Add(btnTambahTransaksi);
            Controls.Add(jumlahMaggot);
            Controls.Add(totalPenghasilan);
            Controls.Add(jumlahTransaksi);
            Controls.Add(dataGridView1);
            Name = "V_Transaksi";
            Size = new Size(1920, 937);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private DataGridView dataGridView1;
        public Label jumlahTransaksi;
        public Label totalPenghasilan;
        public Label jumlahMaggot;
        private Button btnTambahTransaksi;
        private Button btnRiwayat;
        private Button btnBelumBayar;
        private Button btnLihatSemua;
    }
}
