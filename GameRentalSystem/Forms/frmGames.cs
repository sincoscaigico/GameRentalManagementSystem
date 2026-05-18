using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using GameRentalSystem.BUS;

namespace GameRentalSystem
{
    public partial class frmGames : Form
    {
        // USER HIỆN TẠI
        public static string CurrentUsername = "";

        public frmGames()
        {
            InitializeComponent();
        }

        // =========================
        // LOAD ALL GAMES
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

                dgvGames.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvGames.MultiSelect =
                    false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // LOAD TOP RENTED
        // =========================
        private void LoadTopGames()
        {
            try
            {
                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                string query =
                    "SELECT * FROM vw_TopRentedGames";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvTopGames.DataSource =
                    dt;

                conn.Close();

                dgvTopGames.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvTopGames.MultiSelect =
                    false;

                dgvTopGames.AutoSizeColumnsMode =
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
        // LOAD WISHLIST
        // =========================
        private void LoadWishlist()
        {
            try
            {
                cboWishlist.Items.Clear();

                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                string query =
                    "SELECT GameName FROM Wishlist " +
                    "WHERE Username=@username";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@username",
                    CurrentUsername
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboWishlist.Items.Add(
                        reader["GameName"]
                        .ToString()
                    );
                }

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
        private void frmGames_Load(
            object sender,
            EventArgs e
        )
        {
            LoadGames();

            LoadTopGames();

            LoadWishlist();

            cboWishlist.Visible =
                false;

            cboWishlist.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        // =========================
        // SEARCH (LINQ)
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

        // =========================
        // REFRESH
        // =========================
        private void btnRefresh_Click(
            object sender,
            EventArgs e
        )
        {
            txtSearch.Clear();

            LoadGames();

            LoadTopGames();
        }

        // =========================
        // ADD WISHLIST
        // =========================
        private void btnAddWishlist_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvGames.SelectedRows.Count == 0
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn game!"
                );

                return;
            }

            string gameName =
                dgvGames.SelectedRows[0]
                .Cells["GameName"]
                .Value
                .ToString();

            try
            {
                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                string checkQuery =
                    "SELECT COUNT(*) FROM Wishlist " +
                    "WHERE Username=@username " +
                    "AND GameName=@game";

                SqlCommand checkCmd =
                    new SqlCommand(
                        checkQuery,
                        conn
                    );

                checkCmd.Parameters.AddWithValue(
                    "@username",
                    CurrentUsername
                );

                checkCmd.Parameters.AddWithValue(
                    "@game",
                    gameName
                );

                int exist =
                    Convert.ToInt32(
                        checkCmd.ExecuteScalar()
                    );

                if (exist > 0)
                {
                    MessageBox.Show(
                        "Game đã có trong wishlist!"
                    );

                    conn.Close();

                    return;
                }

                string query =
                    "INSERT INTO Wishlist " +
                    "(Username, GameName) " +
                    "VALUES (@username, @game)";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@username",
                    CurrentUsername
                );

                cmd.Parameters.AddWithValue(
                    "@game",
                    gameName
                );

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show(
                    "Đã thêm vào wishlist!"
                );

                LoadWishlist();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // VIEW WISHLIST
        // =========================
        private void btnViewWishlist_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                cboWishlist.Items.Count == 0
            )
            {
                MessageBox.Show(
                    "Wishlist đang trống!"
                );

                return;
            }

            cboWishlist.Visible =
                true;

            cboWishlist.DroppedDown =
                true;
        }

        // =========================
        // SELECT WISHLIST
        // =========================
        private void cboWishlist_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            cboWishlist.Visible =
                false;
        }

        // =========================
        // RENT GAME
        // =========================
        private void btnRentNow_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                dgvGames.SelectedRows.Count == 0
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn game!"
                );

                return;
            }

            string gameName =
                dgvGames.SelectedRows[0]
                .Cells["GameName"]
                .Value
                .ToString();

            string status =
                dgvGames.SelectedRows[0]
                .Cells["Status"]
                .Value
                .ToString();

            if (status == "Out Of Stock")
            {
                MessageBox.Show(
                    "Game hiện tại đang hết hàng!"
                );

                return;
            }

            frmRentGame f =
                new frmRentGame();

            string genre =
                dgvGames.SelectedRows[0]
                .Cells["Genre"]
                .Value
                .ToString();

            decimal price =
                Convert.ToDecimal(
                    dgvGames.SelectedRows[0]
                    .Cells["RentalPrice"]
                    .Value
                );

            f.GameName =
                gameName;

            f.Genre =
                genre;

            f.Price =
                price;

            f.ShowDialog();

            LoadGames();
        }

        // =========================
        // LOGOUT
        // =========================
        private void btnLogout_Click(
            object sender,
            EventArgs e
        )
        {
            DialogResult result =
                MessageBox.Show(
                    "Bạn có muốn đăng xuất?",
                    "Logout",
                    MessageBoxButtons.YesNo
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

        // =========================
        // DASHBOARD
        // =========================
        private void btnDashboard_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                Session.Role != "Admin"
            )
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập!"
                );

                return;
            }

            frmDashboard f =
                new frmDashboard();

            f.Show();

            this.Hide();
        }

        // =========================
        // RENT TAB
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
        // CUSTOMERS
        // =========================
        private void btnCustomers_Click(
            object sender,
            EventArgs e
        )
        {
            if (
                Session.Role != "Admin"
            )
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập!"
                );

                return;
            }

            frmCustomer f =
                new frmCustomer();

            f.Show();

            this.Hide();
        }

        private void dgvGames_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }
    }
}