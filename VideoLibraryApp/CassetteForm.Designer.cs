namespace VideoLibraryApp
{
    partial class CassetteForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(140, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Добавяне на касета";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(140, 75);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Заглавие на филма";
            this.txtTitle.Size = new System.Drawing.Size(275, 25);
            this.txtTitle.TabIndex = 1;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.lblDirector.Location = new System.Drawing.Point(140, 110);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(58, 15);
            this.lblDirector.TabIndex = 2;
            this.lblDirector.Text = "Режисьор";
            // 
            // txtDirector
            // 
            this.txtDirector.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDirector.Location = new System.Drawing.Point(140, 128);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(275, 25);
            this.txtDirector.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.lblYear.Location = new System.Drawing.Point(140, 163);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(43, 15);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Година";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYear.Location = new System.Drawing.Point(140, 181);
            this.txtYear.Name = "txtYear";
            this.txtYear.PlaceholderText = "напр. 1999";
            this.txtYear.Size = new System.Drawing.Size(120, 25);
            this.txtYear.TabIndex = 5;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.lblGenre.Location = new System.Drawing.Point(140, 216);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(35, 15);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Жанр";
            // 
            // txtGenre
            // 
            this.txtGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGenre.Location = new System.Drawing.Point(140, 234);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.PlaceholderText = "екшън, комедия, драма...";
            this.txtGenre.Size = new System.Drawing.Size(275, 25);
            this.txtGenre.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.lblDescription.Location = new System.Drawing.Point(140, 269);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Описание";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(140, 287);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(275, 80);
            this.txtDescription.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(36)))));
            this.btnSave.Location = new System.Drawing.Point(25, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Запази";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.btnCancel.Location = new System.Drawing.Point(235, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отказ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(25, 50);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 130);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 12;
            this.picImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.btnSelectImage.Location = new System.Drawing.Point(25, 185);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(100, 28);
            this.btnSelectImage.TabIndex = 13;
            this.btnSelectImage.Text = "Избери снимка";
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.BtnSelectImage_Click);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblImage.Location = new System.Drawing.Point(25, 32);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(45, 15);
            this.lblImage.TabIndex = 14;
            this.lblImage.Text = "Снимка";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(48)))));
            this.pnlMain.Controls.Add(this.picImage);
            this.pnlMain.Controls.Add(this.btnSelectImage);
            this.pnlMain.Controls.Add(this.lblImage);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.txtTitle);
            this.pnlMain.Controls.Add(this.lblDirector);
            this.pnlMain.Controls.Add(this.txtDirector);
            this.pnlMain.Controls.Add(this.lblYear);
            this.pnlMain.Controls.Add(this.txtYear);
            this.pnlMain.Controls.Add(this.lblGenre);
            this.pnlMain.Controls.Add(this.txtGenre);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(450, 470);
            this.pnlMain.TabIndex = 0;
            // 
            // CassetteForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(450, 470);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CassetteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Касета";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblImage;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
    }
}
