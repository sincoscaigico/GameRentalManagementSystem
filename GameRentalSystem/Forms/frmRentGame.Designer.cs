namespace GameRentalSystem
{
    partial class frmRentGame
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
            this.cboWishlist = new System.Windows.Forms.ComboBox();
            this.btnViewWishlist = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnConfirmRent = new System.Windows.Forms.Button();
            this.btnCancelRent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picGame = new System.Windows.Forms.PictureBox();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.grpDuration = new System.Windows.Forms.GroupBox();
            this.rdo30Days = new System.Windows.Forms.RadioButton();
            this.rdo10Days = new System.Windows.Forms.RadioButton();
            this.rdo7Days = new System.Windows.Forms.RadioButton();
            this.rdo3Days = new System.Windows.Forms.RadioButton();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSummaryPrice = new System.Windows.Forms.Label();
            this.lblSummaryDuration = new System.Windows.Forms.Label();
            this.lblSummaryGame = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.grpDuration.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboWishlist
            // 
            this.cboWishlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWishlist.FormattingEnabled = true;
            this.cboWishlist.Location = new System.Drawing.Point(905, 23);
            this.cboWishlist.Name = "cboWishlist";
            this.cboWishlist.Size = new System.Drawing.Size(270, 21);
            this.cboWishlist.TabIndex = 23;
            this.cboWishlist.Visible = false;
            // 
            // btnViewWishlist
            // 
            this.btnViewWishlist.Location = new System.Drawing.Point(899, 12);
            this.btnViewWishlist.Name = "btnViewWishlist";
            this.btnViewWishlist.Size = new System.Drawing.Size(280, 40);
            this.btnViewWishlist.TabIndex = 22;
            this.btnViewWishlist.Text = "Wishlist";
            this.btnViewWishlist.UseVisualStyleBackColor = true;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.panelLeft.Controls.Add(this.label4);
            this.panelLeft.Controls.Add(this.pictureBox2);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Controls.Add(this.btnCustomers);
            this.panelLeft.Controls.Add(this.btnRent);
            this.panelLeft.Controls.Add(this.btnGames);
            this.panelLeft.Controls.Add(this.btnDashboard);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(220, 661);
            this.panelLeft.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(26, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "GAME RENTAL";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(32, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 126);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(12, 461);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(12, 410);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(180, 45);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnRent
            // 
            this.btnRent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnRent.FlatAppearance.BorderSize = 0;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.ForeColor = System.Drawing.Color.White;
            this.btnRent.Location = new System.Drawing.Point(12, 353);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(180, 45);
            this.btnRent.TabIndex = 3;
            this.btnRent.Text = "Rent Game";
            this.btnRent.UseVisualStyleBackColor = false;
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnGames.FlatAppearance.BorderSize = 0;
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.ForeColor = System.Drawing.Color.White;
            this.btnGames.Location = new System.Drawing.Point(12, 297);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(180, 45);
            this.btnGames.TabIndex = 2;
            this.btnGames.Text = "Games";
            this.btnGames.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(12, 240);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnConfirmRent
            // 
            this.btnConfirmRent.Location = new System.Drawing.Point(858, 593);
            this.btnConfirmRent.Name = "btnConfirmRent";
            this.btnConfirmRent.Size = new System.Drawing.Size(126, 45);
            this.btnConfirmRent.TabIndex = 20;
            this.btnConfirmRent.Text = "Confirm";
            this.btnConfirmRent.UseVisualStyleBackColor = true;
            this.btnConfirmRent.Click += new System.EventHandler(this.btnConfirmRent_Click);
            // 
            // btnCancelRent
            // 
            this.btnCancelRent.Location = new System.Drawing.Point(1016, 593);
            this.btnCancelRent.Name = "btnCancelRent";
            this.btnCancelRent.Size = new System.Drawing.Size(126, 45);
            this.btnCancelRent.TabIndex = 21;
            this.btnCancelRent.Text = "Cancel";
            this.btnCancelRent.UseVisualStyleBackColor = true;
            this.btnCancelRent.Click += new System.EventHandler(this.btnCancelRent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "GAME RENTAL";
            // 
            // picGame
            // 
            this.picGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGame.Location = new System.Drawing.Point(291, 89);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(184, 229);
            this.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGame.TabIndex = 25;
            this.picGame.TabStop = false;
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(635, 144);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(35, 13);
            this.lblGameName.TabIndex = 26;
            this.lblGameName.Text = "label2";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(635, 199);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(35, 13);
            this.lblGenre.TabIndex = 27;
            this.lblGenre.Text = "label2";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(635, 256);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 13);
            this.lblPrice.TabIndex = 28;
            this.lblPrice.Text = "label2";
            // 
            // grpDuration
            // 
            this.grpDuration.Controls.Add(this.rdo30Days);
            this.grpDuration.Controls.Add(this.rdo10Days);
            this.grpDuration.Controls.Add(this.rdo7Days);
            this.grpDuration.Controls.Add(this.rdo3Days);
            this.grpDuration.Location = new System.Drawing.Point(291, 367);
            this.grpDuration.Name = "grpDuration";
            this.grpDuration.Size = new System.Drawing.Size(184, 207);
            this.grpDuration.TabIndex = 29;
            this.grpDuration.TabStop = false;
            this.grpDuration.Text = "Rental Duration";
            // 
            // rdo30Days
            // 
            this.rdo30Days.AutoSize = true;
            this.rdo30Days.Location = new System.Drawing.Point(19, 160);
            this.rdo30Days.Name = "rdo30Days";
            this.rdo30Days.Size = new System.Drawing.Size(64, 17);
            this.rdo30Days.TabIndex = 3;
            this.rdo30Days.TabStop = true;
            this.rdo30Days.Text = "30 Days";
            this.rdo30Days.UseVisualStyleBackColor = true;
            this.rdo30Days.CheckedChanged += new System.EventHandler(this.rdo30Days_CheckedChanged);
            // 
            // rdo10Days
            // 
            this.rdo10Days.AutoSize = true;
            this.rdo10Days.Location = new System.Drawing.Point(19, 122);
            this.rdo10Days.Name = "rdo10Days";
            this.rdo10Days.Size = new System.Drawing.Size(64, 17);
            this.rdo10Days.TabIndex = 2;
            this.rdo10Days.TabStop = true;
            this.rdo10Days.Text = "10 Days";
            this.rdo10Days.UseVisualStyleBackColor = true;
            this.rdo10Days.CheckedChanged += new System.EventHandler(this.rdo10Days_CheckedChanged);
            // 
            // rdo7Days
            // 
            this.rdo7Days.AutoSize = true;
            this.rdo7Days.Location = new System.Drawing.Point(19, 83);
            this.rdo7Days.Name = "rdo7Days";
            this.rdo7Days.Size = new System.Drawing.Size(58, 17);
            this.rdo7Days.TabIndex = 1;
            this.rdo7Days.TabStop = true;
            this.rdo7Days.Text = "7 Days";
            this.rdo7Days.UseVisualStyleBackColor = true;
            this.rdo7Days.CheckedChanged += new System.EventHandler(this.rdo7Days_CheckedChanged);
            // 
            // rdo3Days
            // 
            this.rdo3Days.AutoSize = true;
            this.rdo3Days.Location = new System.Drawing.Point(19, 43);
            this.rdo3Days.Name = "rdo3Days";
            this.rdo3Days.Size = new System.Drawing.Size(58, 17);
            this.rdo3Days.TabIndex = 0;
            this.rdo3Days.TabStop = true;
            this.rdo3Days.Text = "3 Days";
            this.rdo3Days.UseVisualStyleBackColor = true;
            this.rdo3Days.CheckedChanged += new System.EventHandler(this.rdo3Days_CheckedChanged);
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblTotal);
            this.grpSummary.Controls.Add(this.lblSummaryPrice);
            this.grpSummary.Controls.Add(this.lblSummaryDuration);
            this.grpSummary.Controls.Add(this.lblSummaryGame);
            this.grpSummary.Location = new System.Drawing.Point(811, 368);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(331, 206);
            this.grpSummary.TabIndex = 30;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Rental Summary";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(44, 162);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "label2";
            // 
            // lblSummaryPrice
            // 
            this.lblSummaryPrice.AutoSize = true;
            this.lblSummaryPrice.Location = new System.Drawing.Point(44, 124);
            this.lblSummaryPrice.Name = "lblSummaryPrice";
            this.lblSummaryPrice.Size = new System.Drawing.Size(35, 13);
            this.lblSummaryPrice.TabIndex = 29;
            this.lblSummaryPrice.Text = "label2";
            // 
            // lblSummaryDuration
            // 
            this.lblSummaryDuration.AutoSize = true;
            this.lblSummaryDuration.Location = new System.Drawing.Point(44, 85);
            this.lblSummaryDuration.Name = "lblSummaryDuration";
            this.lblSummaryDuration.Size = new System.Drawing.Size(35, 13);
            this.lblSummaryDuration.TabIndex = 28;
            this.lblSummaryDuration.Text = "label2";
            // 
            // lblSummaryGame
            // 
            this.lblSummaryGame.AutoSize = true;
            this.lblSummaryGame.Location = new System.Drawing.Point(44, 45);
            this.lblSummaryGame.Name = "lblSummaryGame";
            this.lblSummaryGame.Size = new System.Drawing.Size(35, 13);
            this.lblSummaryGame.TabIndex = 27;
            this.lblSummaryGame.Text = "label2";
            // 
            // frmRentGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpDuration);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.picGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboWishlist);
            this.Controls.Add(this.btnViewWishlist);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.btnConfirmRent);
            this.Controls.Add(this.btnCancelRent);
            this.Name = "frmRentGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRentGame";
            this.Load += new System.EventHandler(this.frmRentGame_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.grpDuration.ResumeLayout(false);
            this.grpDuration.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboWishlist;
        private System.Windows.Forms.Button btnViewWishlist;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnConfirmRent;
        private System.Windows.Forms.Button btnCancelRent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picGame;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.GroupBox grpDuration;
        private System.Windows.Forms.RadioButton rdo30Days;
        private System.Windows.Forms.RadioButton rdo10Days;
        private System.Windows.Forms.RadioButton rdo7Days;
        private System.Windows.Forms.RadioButton rdo3Days;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSummaryPrice;
        private System.Windows.Forms.Label lblSummaryDuration;
        private System.Windows.Forms.Label lblSummaryGame;
    }
}