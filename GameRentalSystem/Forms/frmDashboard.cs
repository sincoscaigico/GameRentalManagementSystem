using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GameRentalSystem
{
    public partial class frmDashboard : Form
    {
        string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public frmDashboard()
        {
            InitializeComponent();

            SetupModernUI();
        }

        // =====================================
        // FORM LOAD
        // =====================================
        private void frmDashboard_Load(
            object sender,
            EventArgs e
        )
        {
            LoadStatistics();
            LoadGames();
        }

        // =====================================
        // MODERN UI
        // =====================================
        private void SetupModernUI()
        {
            this.WindowState =
                FormWindowState.Maximized;

            this.BackColor =
                Color.FromArgb(10, 10, 25);

            panelLeft.BackColor =
                Color.FromArgb(15, 15, 35);

            panel1.BackColor =
                Color.FromArgb(12, 12, 30);

            dgvGames.BackgroundColor =
                Color.FromArgb(20, 20, 40);

            dgvGames.BorderStyle =
                BorderStyle.None;

            dgvGames.EnableHeadersVisualStyles =
                false;

            dgvGames.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(110, 70, 255);

            dgvGames.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvGames.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            dgvGames.ColumnHeadersHeight = 40;

            dgvGames.DefaultCellStyle.BackColor =
                Color.FromArgb(30, 30, 50);

            dgvGames.DefaultCellStyle.ForeColor =
                Color.White;

            dgvGames.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(140, 90, 255);

            dgvGames.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvGames.RowHeadersVisible =
                false;

            dgvGames.GridColor =
                Color.FromArgb(50, 50, 70);

            dgvGames.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvGames.RowTemplate.Height = 35;

            // SEARCH BOX
            txtSearch.BackColor =
                Color.FromArgb(30, 30, 50);

            txtSearch.ForeColor =
                Color.White;

            txtSearch.Font =
                new Font("Segoe UI", 11);

            // BUTTON STYLE
            StyleButton(btnAddGame,
                Color.FromArgb(110, 70, 255));

            StyleButton(btnEdit,
                Color.FromArgb(0, 170, 255));

            StyleButton(btnDelete,
                Color.FromArgb(255, 70, 70));

            StyleButton(btnRefresh,
                Color.FromArgb(50, 200, 120));

            StyleButton(btnSearch,
                Color.FromArgb(255, 170, 0));
        }

        // =====================================
        // STYLE BUTTON
        // =====================================
        private void StyleButton(
            Button btn,
            Color color
        )
        {
            btn.BackColor = color;

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );
        }

        // =====================================
        // LOAD STATISTICS
        // =====================================
        private void LoadStatistics()
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                SqlCommand cmdGames =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Games",
                        conn
                    );

                lblTotalGames.Text =
                    cmdGames.ExecuteScalar().ToString();

                SqlCommand cmdCustomers =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Customers",
                        conn
                    );

                lblTotalCustomers.Text =
                    cmdCustomers.ExecuteScalar().ToString();

                SqlCommand cmdRentals =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Rentals",
                        conn
                    );

                lblTotalRentals.Text =
                    cmdRentals.ExecuteScalar().ToString();

                conn.Close();
            }
        }

        // =====================================
        // LOAD GAMES
        // =====================================
        private void LoadGames()
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                string query = @"
SELECT
    GameID,
    GameName,
    Genre,
    RentalPrice,
    StockQuantity
FROM Games";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        conn
                    );

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvGames.DataSource =
                    dt;

                conn.Close();
            }
        }

        // =====================================
        // SEARCH GAME
        // =====================================
        private void btnSearch_Click(
            object sender,
            EventArgs e
        )
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                string query = @"
SELECT
    GameID,
    GameName,
    Genre,
    RentalPrice,
    StockQuantity
FROM Games
WHERE GameName LIKE @keyword";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@keyword",
                    "%" + txtSearch.Text + "%"
                );

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvGames.DataSource =
                    dt;

                conn.Close();
            }
        }

        // =====================================
        // ADD GAME
        // =====================================
        private void btnAddGame_Click(
            object sender,
            EventArgs e
        )
        {
            frmAddGame f =
                new frmAddGame();

            f.ShowDialog();

            LoadGames();
        }

        // =====================================
        // EDIT GAME
        // =====================================
        private void btnEdit_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvGames.SelectedRows.Count <= 0
            )
            {
                MessageBox.Show(
                    "Please select a game!"
                );

                return;
            }

            int gameID =
                Convert.ToInt32(
                    dgvGames.SelectedRows[0]
                    .Cells["GameID"].Value
                );

            frmAddGame f =
                new frmAddGame();

            // truyền id qua form addgame
            f.Tag = gameID;

            f.ShowDialog();

            LoadGames();
        }

        // =====================================
        // DELETE GAME
        // =====================================
        private void btnDelete_Click(
    object sender,
    EventArgs e
)
        {
            if (dgvGames.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a game!");
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Delete this game?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                int gameID =
                    Convert.ToInt32(
                        dgvGames.SelectedRows[0]
                        .Cells["GameID"].Value
                    );

                using (
                    SqlConnection conn =
                    new SqlConnection(connectionString)
                )
                {
                    conn.Open();

                    // CHECK RENTAL DETAILS
                    string checkQuery = @"
SELECT COUNT(*)
FROM RentalDetails
WHERE GameID=@GameID";

                    SqlCommand checkCmd =
                        new SqlCommand(
                            checkQuery,
                            conn
                        );

                    checkCmd.Parameters.AddWithValue(
                        "@GameID",
                        gameID
                    );

                    int count =
                        Convert.ToInt32(
                            checkCmd.ExecuteScalar()
                        );

                    if (count > 0)
                    {
                        MessageBox.Show(
                            "Cannot delete this game because it already exists in rental history!",
                            "Delete Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    // DELETE GAME
                    string deleteQuery =
                        "DELETE FROM Games WHERE GameID=@GameID";

                    SqlCommand deleteCmd =
                        new SqlCommand(
                            deleteQuery,
                            conn
                        );

                    deleteCmd.Parameters.AddWithValue(
                        "@GameID",
                        gameID
                    );

                    deleteCmd.ExecuteNonQuery();

                    conn.Close();
                }

                MessageBox.Show(
                    "Deleted successfully!"
                );

                LoadGames();
            }
        }

        // =====================================
        // REFRESH
        // =====================================
        private void btnRefresh_Click(
            object sender,
            EventArgs e
        )
        {
            txtSearch.Clear();

            LoadGames();
        }

        // =====================================
        // OPEN GAMES FORM
        // =====================================
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

        // =====================================
        // OPEN CUSTOMER FORM
        // =====================================
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

        // =====================================
        // OPEN RENT FORM
        // =====================================
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

        // =====================================
        // LOGOUT
        // =====================================
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
        // =====================================
        // DASHBOARD
        // =====================================
        private void btnDashboard_Click(
            object sender,
            EventArgs e
        )
        {
            LoadStatistics();
            LoadGames();
        }
    }
}