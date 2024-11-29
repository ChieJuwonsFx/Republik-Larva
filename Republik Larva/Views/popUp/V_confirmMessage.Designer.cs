namespace Republik_Larva.Views.popUp
{
    partial class V_confirmMessage
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
            konfirm = new Button();
            batal = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // konfirm
            // 
            konfirm.BackColor = Color.Transparent;
            konfirm.BackgroundImageLayout = ImageLayout.Stretch;
            konfirm.FlatAppearance.BorderSize = 0;
            konfirm.FlatStyle = FlatStyle.Flat;
            konfirm.Location = new Point(420, 334);
            konfirm.Name = "konfirm";
            konfirm.Size = new Size(216, 74);
            konfirm.TabIndex = 0;
            konfirm.UseVisualStyleBackColor = false;
            konfirm.Click += konfirm_Click;
            konfirm.MouseEnter += konfirm_MouseEnter;
            konfirm.MouseLeave += konfirm_MouseLeave;
            // 
            // batal
            // 
            batal.BackColor = Color.Transparent;
            batal.BackgroundImageLayout = ImageLayout.Stretch;
            batal.FlatAppearance.BorderSize = 0;
            batal.FlatStyle = FlatStyle.Flat;
            batal.Location = new Point(117, 333);
            batal.Name = "batal";
            batal.Size = new Size(216, 74);
            batal.TabIndex = 1;
            batal.UseVisualStyleBackColor = false;
            batal.Click += batal_Click;
            batal.MouseLeave += batal_MouseLeave;
            batal.MouseEnter += batal_MouseEnter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 221);
            label1.Name = "label1";
            label1.Size = new Size(684, 74);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // V_confirmMessage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.confirmMessage;
            ClientSize = new Size(754, 469);
            Controls.Add(batal);
            Controls.Add(konfirm);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_confirmMessage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += V_confirmMessage_Load;
            ResumeLayout(false);
        }

        #endregion

        public Button konfirm;
        public Button batal;
        private Label label1;
    }
}