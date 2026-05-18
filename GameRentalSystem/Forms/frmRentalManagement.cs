using System;
using System.Data;
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
            LoadRentingGames();
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

                // LINQ SEARCH
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
                // CHECK SELECT
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

                // CONFIRM
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

                // GET RENTAL ID
                int rentalID =
                    Convert.ToInt32(
                        dgvRentingGames
                        .SelectedRows[0]
                        .Cells["RentalID"]
                        .Value
                    );

                // BUS
                RentalBUS bus =
                    new RentalBUS();

                // RETURN GAME
                bus.ReturnGame(
                    rentalID
                );

                MessageBox.Show(
                    "Refund game thành công!"
                );

                // RELOAD
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
            frmGames f =
                new frmGames();

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