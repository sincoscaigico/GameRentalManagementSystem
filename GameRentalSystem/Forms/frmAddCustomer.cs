using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GameRentalSystem
{
    public partial class frmAddCustomer : Form
    {
        // CHECK ADD / EDIT
        public bool IsEdit = false;

        // CUSTOMER ID
        public int CustomerID = 0;

        public frmAddCustomer()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void frmAddCustomer_Load(
            object sender,
            EventArgs e
        )
        {

        }

        // SAVE CUSTOMER
        private void btnSaveCustomer_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                // VALIDATE
                if (
                    txtFullName.Text == "" ||
                    txtPhone.Text == "" ||
                    txtEmail.Text == "" ||
                    txtAddress.Text == ""
                )
                {
                    MessageBox.Show(
                        "Vui lòng nhập đầy đủ thông tin!"
                    );

                    return;
                }

                SqlConnection conn =
                    Database.GetConnection();

                conn.Open();

                // ======================
                // EDIT MODE
                // ======================
                if (IsEdit == true)
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_UpdateCustomer",
                            conn
                        );

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@CustomerID",
                        CustomerID
                    );

                    cmd.Parameters.AddWithValue(
                        "@FullName",
                        txtFullName.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Phone",
                        txtPhone.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Email",
                        txtEmail.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Address",
                        txtAddress.Text
                    );

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Cập nhật khách hàng thành công!"
                    );
                }

                // ======================
                // ADD MODE
                // ======================
                else
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_AddCustomer",
                            conn
                        );

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@FullName",
                        txtFullName.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Phone",
                        txtPhone.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Email",
                        txtEmail.Text
                    );

                    cmd.Parameters.AddWithValue(
                        "@Address",
                        txtAddress.Text
                    );

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Thêm khách hàng thành công!"
                    );
                }

                conn.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // CANCEL
        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            this.Close();
        }
    }
}