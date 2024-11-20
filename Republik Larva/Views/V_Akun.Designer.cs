namespace Republik_Larva.Views
{
    partial class V_Akun
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
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(294, 158);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(185, 29);
            btnExit.TabIndex = 0;
            btnExit.Text = "kabur sementara";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // akun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Name = "akun";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
    }
}