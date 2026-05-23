namespace GameRentalSystem
{
    partial class frmRentalManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRefreshRental = new System.Windows.Forms.Button();
            this.btnRefundGame = new System.Windows.Forms.Button();
            this.lblRentingGames = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchRental = new System.Windows.Forms.TextBox();
            this.dgvRentingGames = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnRentGame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentingGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefreshRental
            // 
            this.btnRefreshRental.Location = new System.Drawing.Point(1050, 609);
            this.btnRefreshRental.Name = "btnRefreshRental";
            this.btnRefreshRental.Size = new System.Drawing.Size(126, 45);
            this.btnRefreshRental.TabIndex = 17;
            this.btnRefreshRental.Text = "Refresh";
            this.btnRefreshRental.UseVisualStyleBackColor = true;
            this.btnRefreshRental.Click += new System.EventHandler(this.btnRefreshRental_Click);
            // 
            // btnRefundGame
            // 
            this.btnRefundGame.Location = new System.Drawing.Point(900, 609);
            this.btnRefundGame.Name = "btnRefundGame";
            this.btnRefundGame.Size = new System.Drawing.Size(126, 45);
            this.btnRefundGame.TabIndex = 16;
            this.btnRefundGame.Text = "Refund Game";
            this.btnRefundGame.UseVisualStyleBackColor = true;
            this.btnRefundGame.Click += new System.EventHandler(this.btnRefundGame_Click);
            // 
            // lblRentingGames
            // 
            this.lblRentingGames.AutoSize = true;
            this.lblRentingGames.Location = new System.Drawing.Point(32, 17);
            this.lblRentingGames.Name = "lblRentingGames";
            this.lblRentingGames.Size = new System.Drawing.Size(111, 13);
            this.lblRentingGames.TabIndex = 6;
            this.lblRentingGames.Text = "Danh sách đơn hàng:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(857, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 27);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
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
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(581, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearchRental
            // 
            this.txtSearchRental.Location = new System.Drawing.Point(639, 14);
            this.txtSearchRental.Name = "txtSearchRental";
            this.txtSearchRental.Size = new System.Drawing.Size(212, 20);
            this.txtSearchRental.TabIndex = 3;
            // 
            // dgvRentingGames
            // 
            this.dgvRentingGames.AllowUserToAddRows = false;
            this.dgvRentingGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentingGames.BackgroundColor = System.Drawing.Color.White;
            this.dgvRentingGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentingGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRentingGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentingGames.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRentingGames.EnableHeadersVisualStyles = false;
            this.dgvRentingGames.Location = new System.Drawing.Point(3, 50);
            this.dgvRentingGames.MultiSelect = false;
            this.dgvRentingGames.Name = "dgvRentingGames";
            this.dgvRentingGames.ReadOnly = true;
            this.dgvRentingGames.RowHeadersVisible = false;
            this.dgvRentingGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentingGames.Size = new System.Drawing.Size(938, 517);
            this.dgvRentingGames.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 32);
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
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnRentGame
            // 
            this.btnRentGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnRentGame.FlatAppearance.BorderSize = 0;
            this.btnRentGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentGame.ForeColor = System.Drawing.Color.White;
            this.btnRentGame.Location = new System.Drawing.Point(12, 353);
            this.btnRentGame.Name = "btnRentGame";
            this.btnRentGame.Size = new System.Drawing.Size(180, 45);
            this.btnRentGame.TabIndex = 3;
            this.btnRentGame.Text = "Rent Game";
            this.btnRentGame.UseVisualStyleBackColor = false;
            this.btnRentGame.Click += new System.EventHandler(this.btnRentGame_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblRentingGames);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.txtSearchRental);
            this.panel1.Controls.Add(this.dgvRentingGames);
            this.panel1.Location = new System.Drawing.Point(234, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 572);
            this.panel1.TabIndex = 14;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.panelLeft.Controls.Add(this.label8);
            this.panelLeft.Controls.Add(this.label4);
            this.panelLeft.Controls.Add(this.pictureBox2);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Controls.Add(this.btnCustomers);
            this.panelLeft.Controls.Add(this.btnRentGame);
            this.panelLeft.Controls.Add(this.btnGames);
            this.panelLeft.Controls.Add(this.btnDashboard);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(220, 661);
            this.panelLeft.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(15, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "MANAGEMENT SYSTEM";
            // 
            // frmRentalManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnRefreshRental);
            this.Controls.Add(this.btnRefundGame);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLeft);
            this.Name = "frmRentalManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRentalManagement";
            this.Load += new System.EventHandler(this.frmRentalManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentingGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefreshRental;
        private System.Windows.Forms.Button btnRefundGame;
        private System.Windows.Forms.Label lblRentingGames;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchRental;
        private System.Windows.Forms.DataGridView dgvRentingGames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnRentGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label8;
    }
}