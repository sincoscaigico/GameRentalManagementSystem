using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameRentalSystem.BUS;

namespace GameRentalSystem
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmCustomer_Load(
            object sender,
            EventArgs e
        )
        {
            ApplyModernUI();

            LoadCustomers();

            LoadCustomerSummary();
        }

        // =========================
        // MODERN UI
        // =========================
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

            // BUTTONS
            StyleMenuButton(btnDashboard);
            StyleMenuButton(btnGames);
            StyleMenuButton(btnRentalManagement);
            StyleMenuButton(btnLogout);

            StyleActionButton(btnAddCustomer);
            StyleActionButton(btnEditCustomer);
            StyleActionButton(btnDeleteCustomer);
            StyleActionButton(btnRefreshCustomer);
            StyleActionButton(btnSearchCustomer);

            // SEARCH BOX
            txtSearchCustomer.BackColor =
                Color.FromArgb(25, 25, 50);

            txtSearchCustomer.ForeColor =
                Color.White;

            txtSearchCustomer.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearchCustomer.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Regular
                );

            // GRID
            StyleGrid(dgvCustomers);

            StyleGrid(dgvCustomerSummary);

            // LABELS
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor =
                        Color.White;

                    c.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Bold
                        );
                }
            }
        }

        // =========================
        // GRID STYLE
        // =========================
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

            dgv.DefaultCellStyle.BackColor =
                Color.FromArgb(25, 25, 50);

            dgv.DefaultCellStyle.ForeColor =
                Color.White;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(139, 92, 246);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgv.RowHeadersVisible = false;

            dgv.GridColor =
                Color.FromArgb(45, 45, 75);

            dgv.RowTemplate.Height =
                35;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================
        // MENU BUTTON
        // =========================
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

            btn.Height = 50;

            btn.Cursor =
                Cursors.Hand;
        }

        // =========================
        // ACTION BUTTON
        // =========================
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

        // =========================
        // LOAD CUSTOMER
        // =========================
        private void LoadCustomers()
        {
            try
            {
                CustomerBUS bus =
                    new CustomerBUS();

                dgvCustomers.DataSource =
                    bus.GetCustomers();

                dgvCustomers.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvCustomers.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvCustomers.MultiSelect =
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
        // LOAD CUSTOMER SUMMARY
        // =========================
        private void LoadCustomerSummary()
        {
            try
            {
                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                string query =
                    "SELECT * FROM vw_CustomerRentalSummary";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        conn
                    );

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvCustomerSummary.DataSource =
                    dt;

                conn.Close();

                dgvCustomerSummary.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvCustomerSummary.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvCustomerSummary.MultiSelect =
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
        // ADD CUSTOMER
        // =========================
        private void btnAddCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            frmAddCustomer f =
                new frmAddCustomer();

            f.IsEdit = false;

            f.ShowDialog();

            LoadCustomers();

            LoadCustomerSummary();
        }

        // =========================
        // EDIT CUSTOMER
        // =========================
        private void btnEditCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (
                    dgvCustomers.SelectedRows.Count == 0
                )
                {
                    MessageBox.Show(
                        "Vui lòng chọn khách hàng!"
                    );

                    return;
                }

                frmAddCustomer f =
                    new frmAddCustomer();

                f.IsEdit = true;

                f.CustomerID =
                    Convert.ToInt32(
                        dgvCustomers.SelectedRows[0]
                        .Cells["CustomerID"]
                        .Value
                    );

                f.txtFullName.Text =
                    dgvCustomers.SelectedRows[0]
                    .Cells["FullName"]
                    .Value.ToString();

                f.txtPhone.Text =
                    dgvCustomers.SelectedRows[0]
                    .Cells["Phone"]
                    .Value.ToString();

                f.txtEmail.Text =
                    dgvCustomers.SelectedRows[0]
                    .Cells["Email"]
                    .Value.ToString();

                f.txtAddress.Text =
                    dgvCustomers.SelectedRows[0]
                    .Cells["Address"]
                    .Value.ToString();

                f.ShowDialog();

                LoadCustomers();

                LoadCustomerSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // DELETE CUSTOMER
        // =========================
        private void btnDeleteCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (
                    dgvCustomers.SelectedRows.Count == 0
                )
                {
                    MessageBox.Show(
                        "Vui lòng chọn khách hàng!"
                    );

                    return;
                }

                int customerID =
                    Convert.ToInt32(
                        dgvCustomers.SelectedRows[0]
                        .Cells["CustomerID"]
                        .Value
                    );

                DialogResult result =
                    MessageBox.Show(
                        "Bạn có muốn xóa?",
                        "Confirm",
                        MessageBoxButtons.YesNo
                    );

                if (
                    result == DialogResult.No
                )
                {
                    return;
                }

                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                SqlCommand cmd =
                    new SqlCommand(
                        "sp_DeleteCustomer",
                        conn
                    );

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@CustomerID",
                    customerID
                );

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show(
                    "Xóa thành công!"
                );

                LoadCustomers();

                LoadCustomerSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // SEARCH CUSTOMER
        // =========================
        private void btnSearchCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                string query =
                    "SELECT CustomerID, FullName, Phone, Email, Address FROM Customers";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        conn
                    );

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                conn.Close();

                var filtered =
                    dt.AsEnumerable()
                    .Where(x =>
                        x["FullName"]
                        .ToString()
                        .ToLower()
                        .Contains(
                            txtSearchCustomer.Text
                            .ToLower()
                        )
                    );

                if (filtered.Any())
                {
                    dgvCustomers.DataSource =
                        filtered.CopyToDataTable();
                }
                else
                {
                    dgvCustomers.DataSource =
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

        // =========================
        // REFRESH
        // =========================
        private void btnRefreshCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            txtSearchCustomer.Clear();

            LoadCustomers();

            LoadCustomerSummary();
        }

        // =========================
        // DASHBOARD
        // =========================
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
        // RENT GAME
        // =========================
        private void btnRentalManagement_Click(
            object sender,
            EventArgs e
        )
        {
            frmRentalManagement f =
                new frmRentalManagement();

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

        // =========================
        // EMPTY EVENTS
        // =========================
        private void dgvCustomers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }

        private void dgvCustomerSummary_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {

        }
    }
}