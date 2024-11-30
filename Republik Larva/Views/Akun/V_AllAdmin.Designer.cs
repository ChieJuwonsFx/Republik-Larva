namespace Republik_Larva.Views
{
    partial class V_AllAdmin
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
            pnAdmin = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnAdmin
            // 
            pnAdmin.AutoScroll = true;
            pnAdmin.BackColor = Color.Transparent;
            pnAdmin.BackgroundImageLayout = ImageLayout.None;
            pnAdmin.FlowDirection = FlowDirection.TopDown;
            pnAdmin.Location = new Point(98, 184);
            pnAdmin.Name = "pnAdmin";
            pnAdmin.Padding = new Padding(10);
            pnAdmin.Size = new Size(1702, 578);
            pnAdmin.TabIndex = 1;
            // 
            // V_AllAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = Properties.Resources.AllAdmin;
            Controls.Add(pnAdmin);
            Name = "V_AllAdmin";
            Size = new Size(1920, 937);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnAdmin;
    }
}
