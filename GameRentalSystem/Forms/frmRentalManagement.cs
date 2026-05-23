using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameRentalSystem.BUS;

namespace GameRentalSystem
{
    public partial class frmRentalManagement : Form
    {
        public frmRentalManagement()
        {
            InitializeComponent();
        }

        // ================================
        // FORM LOAD
        // ================================
        private void frmRentalManagement_Load(
            object sender,
            EventArgs e
        )
        {
            ApplyModernUI();

            LoadRentingGames();
        }

        // ================================
        // MODERN UI
        // ================================
        private void ApplyModernUI()
        {
            // FORM
            this.BackColor =
                Color.FromArgb(15, 15, 35);

            this.StartPosition =
                FormStartPosition.CenterScreen;

            // LEFT PANEL
            panelLeft.BackColor =
                Color.FromArgb(10, 10, 35);

            // SEARCH BOX
            txtSearchRental.BackColor =
                Color.FromArgb(25, 25, 50);

            txtSearchRental.ForeColor =
                Color.White;

            txtSearchRental.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearchRental.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Regular
                );

            // GRID
            StyleGrid(dgvRentingGames);

            // MENU BUTTONS
            StyleMenuButton(btnDashboard);
            StyleMenuButton(btnGames);
            StyleMenuButton(btnRentGame);
            StyleMenuButton(btnCustomers);
            StyleMenuButton(btnLogout);

            // ACTION BUTTONS
            StyleActionButton(btnSearch);
            StyleActionButton(btnRefreshRental);
            StyleActionButton(btnRefundGame);

            // HOVER
            AddHover(btnDashboard);
            AddHover(btnGames);
            AddHover(btnRentGame);
            AddHover(btnCustomers);
            AddHover(btnLogout);

            AddHover(btnSearch);
            AddHover(btnRefreshRental);
            AddHover(btnRefundGame);
        }

        // ================================
        // GRID STYLE
        // ================================
        private void StyleGrid(
            DataGridView dgv
        )
        {
            dgv.BackgroundColor =
                Color.FromArgb(20, 20, 45);

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.EnableHeadersVisualStyles =
                false;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(124, 58, 237);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgv.ColumnHeadersHeight =
                42;

            dgv.DefaultCellStyle.BackColor =
                Color.FromArgb(25, 25, 50);

            dgv.DefaultCellStyle.ForeColor =
                Color.White;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(139, 92, 246);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular
                );

            dgv.RowHeadersVisible =
                false;

            dgv.GridColor =
                Color.FromArgb(45, 45, 75);

            dgv.RowTemplate.Height =
                38;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================================
        // MENU BUTTON STYLE
        // ================================
        private void StyleMenuButton(
            Button btn
        )
        {
            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.BackColor =
                Color.FromArgb(10, 10, 35);

            btn.ForeColor =
                Color.White;

            btn.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            btn.Height = 52;

            btn.Cursor =
                Cursors.Hand;
        }

        // ================================
        // ACTION BUTTON STYLE
        // ================================
        private void StyleActionButton(
            Button btn
        )
        {
            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.BackColor =
                Color.FromArgb(124, 58, 237);

            btn.ForeColor =
                Color.White;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btn.Cursor =
                Cursors.Hand;

            btn.Height = 42;
        }

        // ================================
        // BUTTON HOVER EFFECT
        // ================================
        private void AddHover(
            Button btn
        )
        {
            btn.MouseEnter +=
                (s, e) =>
                {
                    btn.BackColor =
                        Color.FromArgb(139, 92, 246);
                };

            btn.MouseLeave +=
                (s, e) =>
                {
                    if (
                        btn == btnSearch ||
                        btn == btnRefundGame ||
                        btn == btnRefreshRental
                    )
                    {
                        btn.BackColor =
                            Color.FromArgb(124, 58, 237);
                    }
                    else
                    {
                        btn.BackColor =
                            Color.FromArgb(10, 10, 35);
                    }
                };
        }

        // ================================
        // LOAD RENTING GAMES
        // ================================
        private void LoadRentingGames()
        {
            try
            {
                RentalBUS bus =
                    new RentalBUS();

                dgvRentingGames.DataSource =
                    bus.GetRentals();

                dgvRentingGames.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvRentingGames.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvRentingGames.MultiSelect =
                    false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // ================================
        // SEARCH RENTAL
        // ================================
        private void btnSearch_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                RentalBUS bus =
                    new RentalBUS();

                DataTable dt =
                    bus.GetRentals();

                var filtered =
                    dt.AsEnumerable()
                    .Where(
                        x =>
                        x["FullName"]
                        .ToString()
                        .ToLower()
                        .Contains(
                            txtSearchRental.Text
                            .ToLower()
                        )
                        ||
                        x["GameName"]
                        .ToString()
                        .ToLower()
                        .Contains(
                            txtSearchRental.Text
                            .ToLower()
                        )
                    );

                if (filtered.Any())
                {
                    dgvRentingGames.DataSource =
                        filtered.CopyToDataTable();
                }
                else
                {
                    dgvRentingGames.DataSource =
                        null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // ================================
        // REFRESH
        // ================================
        private void btnRefreshRental_Click(
            object sender,
            EventArgs e
        )
        {
            txtSearchRental.Clear();

            LoadRentingGames();
        }

        // ================================
        // REFUND GAME
        // ================================
        private void btnRefundGame_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (
                    dgvRentingGames.SelectedRows.Count
                    == 0
                )
                {
                    MessageBox.Show(
                        "Vui lòng chọn rental!"
                    );

                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "Xác nhận refund game?",
                        "Refund",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (
                    result == DialogResult.No
                )
                {
                    return;
                }

                int rentalID =
                    Convert.ToInt32(
                        dgvRentingGames
                        .SelectedRows[0]
                        .Cells["RentalID"]
                        .Value
                    );

                RentalBUS bus =
                    new RentalBUS();

                bus.ReturnGame(
                    rentalID
                );

                MessageBox.Show(
                    "Refund game thành công!"
                );

                LoadRentingGames();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // ================================
        // SIDEBAR - DASHBOARD
        // ================================
        private void btnDashboard_Click(
            object sender,
            EventArgs e
        )
        {
            frmDashboard f =
                new frmDashboard();

            f.Show();

            this.Hide();
        }

        // ================================
        // SIDEBAR - GAMES
        // ================================
        private void btnGames_Click(
            object sender,
            EventArgs e
        )
        {
            frmGames f =
                new frmGames();

            f.Show();

            this.Hide();
        }

        // ================================
        // SIDEBAR - RENT GAME
        // ================================
        private void btnRentGame_Click(
            object sender,
            EventArgs e
        )
        {
            frmRentGame f =
                new frmRentGame();

            f.Show();

            this.Hide();
        }

        // ================================
        // SIDEBAR - CUSTOMERS
        // ================================
        private void btnCustomers_Click(
            object sender,
            EventArgs e
        )
        {
            frmCustomer f =
                new frmCustomer();

            f.Show();

            this.Hide();
        }

        // ================================
        // SIDEBAR - LOGOUT
        // ================================
        private void btnLogout_Click(
            object sender,
            EventArgs e
        )
        {
            DialogResult result =
                MessageBox.Show(
                    "Bạn có muốn đăng xuất?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (
                result == DialogResult.Yes
            )
            {
                frmLogin f =
                    new frmLogin();

                f.Show();

                this.Hide();
            }
        }
    }
}