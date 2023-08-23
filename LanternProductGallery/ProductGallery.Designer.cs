namespace Lanternsoft
{
    partial class ProductGallery
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
            this.pnlGallery = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlGallery
            // 
            this.pnlGallery.AutoScroll = true;
            this.pnlGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGallery.Location = new System.Drawing.Point(0, 0);
            this.pnlGallery.Name = "pnlGallery";
            this.pnlGallery.Size = new System.Drawing.Size(610, 144);
            this.pnlGallery.TabIndex = 0;
            this.pnlGallery.SizeChanged += new System.EventHandler(this.pnlGallery_SizeChanged);
            // 
            // ProductGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGallery);
            this.Name = "ProductGallery";
            this.Size = new System.Drawing.Size(610, 144);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGallery;
    }
}
