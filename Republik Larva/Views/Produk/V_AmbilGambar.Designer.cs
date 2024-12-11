namespace Republik_Larva.Views.Produk
{
    partial class V_AmbilGambar
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
            btnCapture = new Button();
            comboBox1 = new ComboBox();
            btnSimpan = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(406, 138);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1108, 623);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.Transparent;
            btnCapture.BackgroundImage = Properties.Resources.capture;
            btnCapture.FlatAppearance.BorderSize = 0;
            btnCapture.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCapture.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCapture.FlatStyle = FlatStyle.Flat;
            btnCapture.Location = new Point(895, 767);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(119, 119);
            btnCapture.TabIndex = 1;
            btnCapture.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(406, 138);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(352, 45);
            comboBox1.TabIndex = 2;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(1263, 788);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(250, 70);
            btnSimpan.TabIndex = 3;
            btnSimpan.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(406, 787);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(250, 70);
            btnExit.TabIndex = 4;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // V_AmbilGambar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.webcapture;
            Controls.Add(btnExit);
            Controls.Add(btnSimpan);
            Controls.Add(comboBox1);
            Controls.Add(btnCapture);
            Controls.Add(pictureBox1);
            Name = "V_AmbilGambar";
            Size = new Size(1920, 937);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnCapture;
        private ComboBox comboBox1;
        private Button btnSimpan;
        private Button btnExit;
    }
}
