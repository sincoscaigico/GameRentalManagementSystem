using System;
using System.Windows.Forms;
using GameRentalSystem.BUS;
using GameRentalSystem.DTO;

namespace GameRentalSystem
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                if (txtUsername.Text == "" ||
                    txtPassword.Text == "" ||
                    txtConfirmPassword.Text == "")
                {
                    MessageBox.Show(
                        "Please fill all required fields!"
                    );

                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show(
                        "Password does not match!"
                    );

                    return;
                }

                UserDTO user =
                    new UserDTO();

                user.Username =
                    txtUsername.Text.Trim();

                user.Password =
                    txtPassword.Text.Trim();

                user.Email =
                    txtEmail.Text.Trim();

                user.FullName =
                    txtFullName.Text.Trim();

                user.Phone =
                    txtPhone.Text.Trim();

                user.Address =
                    txtAddress.Text.Trim();

                AuthBUS bus =
                    new AuthBUS();

                bool success =
                    bus.Register(user);

                if (success)
                {
                    MessageBox.Show(
                        "Register successful!"
                    );

                    frmLogin login =
                        new frmLogin();

                    login.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Register failed!"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLogin_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e
        )
        {
            frmLogin login =
                new frmLogin();

            login.Show();

            this.Hide();
        }

        private void frmRegister_Load(
            object sender,
            EventArgs e
        )
        {

        }
    }
}