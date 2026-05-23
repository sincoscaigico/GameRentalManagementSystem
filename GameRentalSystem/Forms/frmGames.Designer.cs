namespace GameRentalSystem
{
    partial class frmGames
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRentNow = new System.Windows.Forms.Button();
            this.btnAddWishlist = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnViewWishlist = new System.Windows.Forms.Button();
            this.cboWishlist = new System.Windows.Forms.ComboBox();
            this.dgvTopGames = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopGames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRentNow
            // 
            this.btnRentNow.Location = new System.Drawing.Point(1050, 609);
            this.btnRentNow.Name = "btnRentNow";
            this.btnRentNow.Size = new System.Drawing.Size(126, 45);
            this.btnRentNow.TabIndex = 15;
            this.btnRentNow.Text = "Play now";
            this.btnRentNow.UseVisualStyleBackColor = true;
            this.btnRentNow.Click += new System.EventHandler(this.btnRentNow_Click);
            // 
            // btnAddWishlist
            // 
            this.btnAddWishlist.Location = new System.Drawing.Point(908, 609);
            this.btnAddWishlist.Name = "btnAddWishlist";
            this.btnAddWishlist.Size = new System.Drawing.Size(126, 45);
            this.btnAddWishlist.TabIndex = 12;
            this.btnAddWishlist.Text = "Add To Wishlist";
            this.btnAddWishlist.UseVisualStyleBackColor = true;
            this.btnAddWishlist.Click += new System.EventHandler(this.btnAddWishlist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Danh sách game:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(883, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 27);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(665, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(212, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // dgvGames
            // 
            this.dgvGames.AllowUserToAddRows = false;
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGames.BackgroundColor = System.Drawing.Color.White;
            this.dgvGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGames.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGames.EnableHeadersVisualStyles = false;
            this.dgvGames.Location = new System.Drawing.Point(3, 50);
            this.dgvGames.MultiSelect = false;
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            this.dgvGames.RowHeadersVisible = false;
            this.dgvGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGames.Size = new System.Drawing.Size(938, 385);
            this.dgvGames.TabIndex = 3;
            this.dgvGames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGames_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dgvGames);
            this.panel1.Location = new System.Drawing.Point(226, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 306);
            this.panel1.TabIndex = 11;
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
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
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
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.panelLeft.Controls.Add(this.label8);
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
            this.panelLeft.TabIndex = 10;
            // 
            // btnViewWishlist
            // 
            this.btnViewWishlist.Location = new System.Drawing.Point(961, 12);
            this.btnViewWishlist.Name = "btnViewWishlist";
            this.btnViewWishlist.Size = new System.Drawing.Size(215, 40);
            this.btnViewWishlist.TabIndex = 16;
            this.btnViewWishlist.Text = "Wishlist";
            this.btnViewWishlist.UseVisualStyleBackColor = true;
            this.btnViewWishlist.Click += new System.EventHandler(this.btnViewWishlist_Click);
            // 
            // cboWishlist
            // 
            this.cboWishlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWishlist.FormattingEnabled = true;
            this.cboWishlist.Location = new System.Drawing.Point(970, 23);
            this.cboWishlist.Name = "cboWishlist";
            this.cboWishlist.Size = new System.Drawing.Size(202, 21);
            this.cboWishlist.TabIndex = 17;
            this.cboWishlist.Visible = false;
            this.cboWishlist.SelectedIndexChanged += new System.EventHandler(this.cboWishlist_SelectedIndexChanged);
            // 
            // dgvTopGames
            // 
            this.dgvTopGames.AllowUserToAddRows = false;
            this.dgvTopGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopGames.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTopGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopGames.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTopGames.EnableHeadersVisualStyles = false;
            this.dgvTopGames.Location = new System.Drawing.Point(230, 58);
            this.dgvTopGames.MultiSelect = false;
            this.dgvTopGames.Name = "dgvTopGames";
            this.dgvTopGames.ReadOnly = true;
            this.dgvTopGames.RowHeadersVisible = false;
            this.dgvTopGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopGames.Size = new System.Drawing.Size(275, 233);
            this.dgvTopGames.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "🔥 TOP TRENDING GAMES";
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
            // frmGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTopGames);
            this.Controls.Add(this.cboWishlist);
            this.Controls.Add(this.btnViewWishlist);
            this.Controls.Add(this.btnRentNow);
            this.Controls.Add(this.btnAddWishlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLeft);
            this.Name = "frmGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGames";
            this.Load += new System.EventHandler(this.frmGames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRentNow;
        private System.Windows.Forms.Button btnAddWishlist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnViewWishlist;
        private System.Windows.Forms.ComboBox cboWishlist;
        private System.Windows.Forms.DataGridView dgvTopGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
    }
}