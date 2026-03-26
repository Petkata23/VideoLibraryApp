namespace VideoLibraryApp
{
    partial class MyFilmsView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(22, 30, 48);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(600, 50);
            this.pnlTop.TabIndex = 0;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(220, 220, 235);
            this.btnRefresh.Location = new System.Drawing.Point(490, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Обнови";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 200, 100);
            this.lblTitle.Location = new System.Drawing.Point(10, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Моите запазени филми";
            //
            // flowPanel
            //
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.Color.FromArgb(18, 26, 42);
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Padding = new System.Windows.Forms.Padding(12);
            this.flowPanel.Size = new System.Drawing.Size(600, 400);
            this.flowPanel.TabIndex = 1;
            this.flowPanel.WrapContents = true;
            //
            // scrollPanel
            //
            this.scrollPanel.Controls.Add(this.flowPanel);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 50);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(600, 400);
            this.scrollPanel.TabIndex = 2;
            //
            // MyFilmsView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 26, 42);
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.pnlTop);
            this.Name = "MyFilmsView";
            this.Size = new System.Drawing.Size(600, 450);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.scrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Panel scrollPanel;
    }
}
