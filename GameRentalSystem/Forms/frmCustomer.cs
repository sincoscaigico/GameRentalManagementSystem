using System;
using System.Data;
using System.Data.SqlClient;
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
                MessageBox.Show(ex.Message);
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
                    new SqlDataAdapter(query, conn);

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
        // FORM LOAD
        // =========================
        private void frmCustomer_Load(
            object sender,
            EventArgs e
        )
        {
            LoadCustomers();

            LoadCustomerSummary();
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
        // SEARCH CUSTOMER (LINQ)
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
                    "SELECT " +
                    "CustomerID, " +
                    "FullName, " +
                    "Phone, " +
                    "Email, " +
                    "Address " +
                    "FROM Customers";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                conn.Close();

                // LINQ SEARCH
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
        // RENTAL MANAGEMENT
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