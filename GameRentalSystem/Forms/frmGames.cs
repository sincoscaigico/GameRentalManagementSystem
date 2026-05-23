using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using GameRentalSystem.BUS;
using System.Net.Http;
using Newtonsoft.Json;

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
        // MODERN UI
        // =========================
        private void SetupModernUI()
        {
            // FORM
            this.BackColor =
                Color.FromArgb(10, 10, 30);

            this.ForeColor =
                Color.White;

            // =========================
            // DATAGRIDVIEW GAMES
            // =========================
            dgvGames.BackgroundColor =
                Color.FromArgb(20, 20, 45);

            dgvGames.BorderStyle =
                BorderStyle.None;

            dgvGames.EnableHeadersVisualStyles =
                false;

            dgvGames.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(120, 50, 220);

            dgvGames.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvGames.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            dgvGames.DefaultCellStyle.BackColor =
                Color.FromArgb(25, 25, 50);

            dgvGames.DefaultCellStyle.ForeColor =
                Color.White;

            dgvGames.DefaultCellStyle.SelectionBackColor =
                Color.MediumPurple;

            dgvGames.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvGames.RowTemplate.Height =
                35;

            dgvGames.GridColor =
                Color.FromArgb(60, 60, 100);

            // =========================
            // TOP GAMES GRID
            // =========================
            dgvTopGames.BackgroundColor =
                Color.FromArgb(20, 20, 45);

            dgvTopGames.BorderStyle =
                BorderStyle.None;

            dgvTopGames.EnableHeadersVisualStyles =
                false;

            dgvTopGames.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(120, 50, 220);

            dgvTopGames.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvTopGames.DefaultCellStyle.BackColor =
                Color.FromArgb(25, 25, 50);

            dgvTopGames.DefaultCellStyle.ForeColor =
                Color.White;

            dgvTopGames.DefaultCellStyle.SelectionBackColor =
                Color.MediumPurple;

            dgvTopGames.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvTopGames.RowTemplate.Height =
                35;

            // =========================
            // SEARCH BOX
            // =========================
            txtSearch.BackColor =
                Color.FromArgb(30, 30, 60);

            txtSearch.ForeColor =
                Color.White;

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Font =
                new Font(
                    "Segoe UI",
                    11
                );

            // =========================
            // COMBOBOX
            // =========================
            cboWishlist.BackColor =
                Color.FromArgb(30, 30, 60);

            cboWishlist.ForeColor =
                Color.White;

            cboWishlist.FlatStyle =
                FlatStyle.Flat;

            // =========================
            // NORMAL BUTTONS
            // =========================
            StyleButton(btnSearch);
            StyleButton(btnAddWishlist);
            StyleButton(btnViewWishlist);
            StyleButton(btnRentNow);

            // =========================
            // MENU BUTTONS
            // =========================
            StyleMenuButton(btnDashboard);
            StyleMenuButton(btnGames);
            StyleMenuButton(btnCustomers);
            StyleMenuButton(btnRent);
            StyleMenuButton(btnLogout);
        }

        // =========================
        // STYLE NORMAL BUTTON
        // =========================
        private void StyleButton(Button btn)
        {
            btn.BackColor =
                Color.FromArgb(120, 50, 220);

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btn.Cursor =
                Cursors.Hand;

            btn.Height =
                40;
        }

        // =========================
        // STYLE MENU BUTTON
        // =========================
        private void StyleMenuButton(Button btn)
        {
            btn.BackColor =
                Color.FromArgb(15, 15, 35);

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btn.Cursor =
                Cursors.Hand;

            btn.Height =
                45;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor =
                    Color.FromArgb(120, 50, 220);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor =
                    Color.FromArgb(15, 15, 35);
            };
        }

        // =========================
        // LOAD ALL GAMES
        // =========================
        private async void LoadGames()
        {
            try
            {
                HttpClient client =
                    new HttpClient();

                string url =
                    "https://localhost:7080/api/Game";

                string json =
                    await client.GetStringAsync(url);

                var games =
                    JsonConvert.DeserializeObject<dynamic>(json);

                dgvGames.DataSource =
                    games;

                dgvGames.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvGames.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvGames.MultiSelect =
                    false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    new SqlDataAdapter(
                        query,
                        conn
                    );

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
                    new SqlCommand(
                        query,
                        conn
                    );

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
        private async void frmGames_Load(
            object sender,
            EventArgs e
        )
        {
            SetupModernUI();

            LoadGames();

            LoadTopGames();

            LoadWishlist();

            cboWishlist.Visible =
                false;

            cboWishlist.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        // =========================
        // SEARCH
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

            int stock =
                Convert.ToInt32(
                    dgvGames.SelectedRows[0]
                    .Cells["stockQuantity"]
                    .Value
                );

            if (stock <= 0)
            {
                MessageBox.Show(
                    "Game hết hàng!"
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
                    .Cells["pricePerDay"]
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