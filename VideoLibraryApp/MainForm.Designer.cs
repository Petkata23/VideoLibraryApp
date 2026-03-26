namespace VideoLibraryApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnMyFilms = new System.Windows.Forms.Button();
            this.btnCassettes = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblContentSubtitle = new System.Windows.Forms.Label();
            this.lblContentTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(36)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 100);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHeader_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtitle.Location = new System.Drawing.Point(95, 58);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 28);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Subtitle";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblWelcome.Location = new System.Drawing.Point(780, 35);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(308, 30);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(95, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 51);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TITLE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 36F);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblLogo.Location = new System.Drawing.Point(25, 22);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(65, 65);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnMyFilms);
            this.pnlSidebar.Controls.Add(this.btnCassettes);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 100);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);
            this.pnlSidebar.TabIndex = 1;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlSidebar_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnLogout.Location = new System.Drawing.Point(22, 640);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(206, 45);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.btnUsers.Location = new System.Drawing.Point(22, 220);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(206, 48);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            // 
            // btnMyFilms
            // 
            this.btnMyFilms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.btnMyFilms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyFilms.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.btnMyFilms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyFilms.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMyFilms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.btnMyFilms.Location = new System.Drawing.Point(22, 166);
            this.btnMyFilms.Name = "btnMyFilms";
            this.btnMyFilms.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMyFilms.Size = new System.Drawing.Size(206, 48);
            this.btnMyFilms.TabIndex = 2;
            this.btnMyFilms.Text = "My Films";
            this.btnMyFilms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyFilms.UseVisualStyleBackColor = false;
            this.btnMyFilms.Click += new System.EventHandler(this.BtnMyFilms_Click);
            // 
            // btnCassettes
            // 
            this.btnCassettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.btnCassettes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCassettes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(60)))));
            this.btnCassettes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCassettes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCassettes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(36)))));
            this.btnCassettes.Location = new System.Drawing.Point(22, 112);
            this.btnCassettes.Name = "btnCassettes";
            this.btnCassettes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCassettes.Size = new System.Drawing.Size(206, 48);
            this.btnCassettes.TabIndex = 1;
            this.btnCassettes.Text = "Cassettes";
            this.btnCassettes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCassettes.UseVisualStyleBackColor = false;
            this.btnCassettes.Click += new System.EventHandler(this.BtnCassettes_Click);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(22, 35);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(206, 35);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "MENU";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(42)))));
            this.pnlContent.Controls.Add(this.pnlWelcome);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 100);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(40);
            this.pnlContent.Size = new System.Drawing.Size(850, 700);
            this.pnlContent.TabIndex = 2;
            //
            // pnlWelcome
            //
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.Controls.Add(this.lblContentSubtitle);
            this.pnlWelcome.Controls.Add(this.lblContentTitle);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(40, 40);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Padding = new System.Windows.Forms.Padding(20);
            this.pnlWelcome.Size = new System.Drawing.Size(770, 470);
            this.pnlWelcome.TabIndex = 0;
            //
            // lblContentTitle
            // 
            this.lblContentTitle.AutoSize = true;
            this.lblContentTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblContentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.lblContentTitle.Location = new System.Drawing.Point(23, 30);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(300, 47);
            this.lblContentTitle.TabIndex = 0;
            this.lblContentTitle.Text = "Content Title";
            // 
            // lblContentSubtitle
            // 
            this.lblContentSubtitle.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblContentSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(192)))), ((int)(((byte)(210)))));
            this.lblContentSubtitle.Location = new System.Drawing.Point(26, 95);
            this.lblContentSubtitle.Name = "lblContentSubtitle";
            this.lblContentSubtitle.Size = new System.Drawing.Size(720, 180);
            this.lblContentSubtitle.TabIndex = 1;
            this.lblContentSubtitle.Text = "Content subtitle text.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Library";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnCassettes;
        private System.Windows.Forms.Button btnMyFilms;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblContentTitle;
        private System.Windows.Forms.Label lblContentSubtitle;
    }
}
