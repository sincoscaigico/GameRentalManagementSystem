using System;
using System.Data;
using System.Data.SqlClient;
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
        }

        private void frmDashboard_Load(
            object sender,
            EventArgs e
        )
        {
            LoadStatistics();
            LoadGames();
        }

        // =========================
        // LOAD STATISTICS
        // =========================
        private void LoadStatistics()
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                // TOTAL GAMES
                SqlCommand cmdGames =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Games",
                        conn
                    );

                lblTotalGames.Text =
                    cmdGames.ExecuteScalar().ToString();

                // TOTAL CUSTOMERS
                SqlCommand cmdCustomers =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Customers",
                        conn
                    );

                lblTotalCustomers.Text =
                    cmdCustomers.ExecuteScalar().ToString();

                // TOTAL RENTALS
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

        // =========================
        // LOAD GAMES
        // =========================
        private void LoadGames()
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                string query = @"
SELECT TOP 10
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

        // =========================
        // GAMES
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
    }
}