namespace Republik_Larva.Views.Transaksi
{
    partial class V_BelumLunas
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
            dataGridBelumLunas = new DataGridView();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridBelumLunas).BeginInit();
            SuspendLayout();
            // 
            // dataGridBelumLunas
            // 
            dataGridBelumLunas.BackgroundColor = Color.FromArgb(245, 242, 214);
            dataGridBelumLunas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBelumLunas.Location = new Point(159, 167);
            dataGridBelumLunas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBelumLunas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridBelumLunas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridBelumLunas.Name = "dataGridBelumLunas";
            dataGridBelumLunas.RowHeadersWidth = 51;
            dataGridBelumLunas.Size = new Size(1598, 580);
            dataGridBelumLunas.TabIndex = 0;
            dataGridBelumLunas.CellContentClick += dataGridBelumLunas_CellContentClick;
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
            btnKembali.TabIndex = 2;
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += this.btnKembali_Click;
            btnKembali.MouseEnter += btnKembali_MouseEnter;
            btnKembali.MouseLeave += btnKembali_MouseLeave;
            // 
            // V_BelumLunas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.belumLunas;
            Controls.Add(btnKembali);
            Controls.Add(dataGridBelumLunas);
            Name = "V_BelumLunas";
            Size = new Size(1920, 937);
            ((System.ComponentModel.ISupportInitialize)dataGridBelumLunas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView dataGridBelumLunas;
        private Button btnKembali;
    }
}
