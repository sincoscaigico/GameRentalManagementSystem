using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GameRentalSystem.BUS;

namespace GameRentalSystem
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        // =========================
        // LOAD GAMES
        // =========================
        private void LoadGames()
        {
            try
            {
                GameBUS bus =
                    new GameBUS();

                dgvGames.DataSource =
                    bus.GetGames();

                dgvGames.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // LOAD STATISTICS
        // =========================
        private void LoadStatistics()
        {
            try
            {
                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                // TOTAL GAMES
                SqlCommand cmdGames =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Games",
                        conn
                    );

                lblTotalGames.Text =
                    cmdGames.ExecuteScalar()
                    .ToString();

                // TOTAL CUSTOMERS
                SqlCommand cmdCustomers =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Customers",
                        conn
                    );

                lblTotalCustomers.Text =
                    cmdCustomers.ExecuteScalar()
                    .ToString();

                // TOTAL RENTALS
                SqlCommand cmdRentals =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Rentals",
                        conn
                    );

                lblTotalRentals.Text =
                    cmdRentals.ExecuteScalar()
                    .ToString();

                // AVAILABLE GAMES
                SqlCommand cmdAvailable =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                          FROM Games
                          WHERE StockQuantity > 0",
                        conn
                    );

                lblAvailableGames.Text =
                    cmdAvailable.ExecuteScalar()
                    .ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmDashboard_Load(
            object sender,
            EventArgs e
        )
        {
            LoadGames();

            LoadStatistics();

            dgvGames.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvGames.MultiSelect =
                false;
        }

        // =========================
        // ADD GAME
        // =========================
        private void btnAddGame_Click(
            object sender,
            EventArgs e
        )
        {
            frmAddGame f =
                new frmAddGame();

            f.ShowDialog();

            LoadGames();

            LoadStatistics();
        }

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(
            object sender,
            EventArgs e
        )
        {
            LoadGames();

            LoadStatistics();
        }

        // =========================
        // EDIT GAME
        // =========================
        private void btnEdit_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn game!"
                );

                return;
            }

            frmAddGame f =
                new frmAddGame();

            f.GameID =
                Convert.ToInt32(
                    dgvGames.SelectedRows[0]
                    .Cells["GameID"]
                    .Value
                );

            f.txtGameName.Text =
                dgvGames.SelectedRows[0]
                .Cells["GameName"]
                .Value
                .ToString();

            f.txtGenre.Text =
                dgvGames.SelectedRows[0]
                .Cells["Genre"]
                .Value
                .ToString();

            f.txtPlatform.Text =
                dgvGames.SelectedRows[0]
                .Cells["Platform"]
                .Value
                .ToString();

            f.numYear.Value =
                Convert.ToDecimal(
                    dgvGames.SelectedRows[0]
                    .Cells["ReleaseYear"]
                    .Value
                );

            f.numPrice.Value =
                Convert.ToDecimal(
                    dgvGames.SelectedRows[0]
                    .Cells["RentalPrice"]
                    .Value
                );

            f.numStock.Value =
                Convert.ToDecimal(
                    dgvGames.SelectedRows[0]
                    .Cells["StockQuantity"]
                    .Value
                );

            f.cboStatus.Text =
                dgvGames.SelectedRows[0]
                .Cells["Status"]
                .Value
                .ToString();

            f.cboCategory.SelectedValue =
                dgvGames.SelectedRows[0]
                .Cells["CategoryID"]
                .Value;

            f.ShowDialog();

            LoadGames();

            LoadStatistics();
        }

        // =========================
        // DELETE GAME
        // =========================
        private void btnDelete_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn game!"
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa game này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                try
                {
                    int gameID =
                        Convert.ToInt32(
                            dgvGames.SelectedRows[0]
                            .Cells["GameID"]
                            .Value
                        );

                    GameBUS bus =
                        new GameBUS();

                    bus.DeleteGame(
                        gameID
                    );

                    MessageBox.Show(
                        "Xóa game thành công!"
                    );

                    LoadGames();

                    LoadStatistics();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message
                    );
                }
            }
        }

        // =========================
        // SEARCH GAME
        // =========================
        private void btnSearch_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                GameBUS bus =
                    new GameBUS();

                dgvGames.DataSource =
                    bus.SearchGames(
                        txtSearch.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        private void btnRefresh_Click_1(
            object sender,
            EventArgs e
        )
        {
            txtSearch.Text = "";

            LoadGames();

            LoadStatistics();
        }

        // =========================
        // LOGOUT
        // =========================
        private void btnLogout_Click(
            object sender,
            EventArgs e
        )
        {
            frmLogin f =
                new frmLogin();

            f.Show();

            this.Hide();
        }

        // =========================
        // SIDEBAR - GAMES
        // =========================
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

        // =========================
        // SIDEBAR - RENT
        // =========================
        private void btnRent_Click(
            object sender,
            EventArgs e
        )
        {
            frmRentGame f =
                new frmRentGame();

            f.Show();

            this.Hide();
        }

        // =========================
        // SIDEBAR - CUSTOMERS
        // =========================
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

        private void pictureBox1_Click(
            object sender,
            EventArgs e
        )
        {

        }

        private void panelLeft_Paint(
            object sender,
            PaintEventArgs e
        )
        {

        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e
        )
        {

        }

        private void lblTotalGames_Click(
            object sender,
            EventArgs e
        )
        {

        }

        private void lblTotalRentals_Click(object sender, EventArgs e)
        {

        }
    }
}