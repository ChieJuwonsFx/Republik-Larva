namespace Republik_Larva.Views.popUp
{
    partial class V_okMessage
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
            label1 = new Label();
            SuspendLayout();
            // 
            // konfirm
            // 
            konfirm.BackColor = Color.Transparent;
            konfirm.FlatAppearance.BorderSize = 0;
            konfirm.FlatStyle = FlatStyle.Flat;
            konfirm.Location = new Point(269, 334);
            konfirm.Name = "konfirm";
            konfirm.Size = new Size(216, 74);
            konfirm.TabIndex = 0;
            konfirm.UseVisualStyleBackColor = false;
            konfirm.Click += konfirm_Click;
            konfirm.MouseEnter += konfirm_MouseEnter;
            konfirm.MouseLeave += konfirm_MouseLeave;
            konfirm.MouseHover += konfirm_MouseHover;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 234);
            label1.Name = "label1";
            label1.Size = new Size(691, 71);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // V_okMessage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.okMessage;
            ClientSize = new Size(754, 469);
            Controls.Add(label1);
            Controls.Add(konfirm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_okMessage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += V_okMessage_Load_1;
            ResumeLayout(false);
        }



        #endregion

        private Button konfirm;
        private Label label1;
    }
}