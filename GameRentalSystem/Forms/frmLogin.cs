using System;
using System.Windows.Forms;
using GameRentalSystem.BUS;

namespace GameRentalSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(
            object sender,
            EventArgs e
        )
        {

        }

        // REGISTER
        private void linkRegister_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e
        )
        {
            frmRegister f =
                new frmRegister();

            f.Show();

            this.Hide();
        }

        // LOGIN
        private void btnLogin_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                // CHECK EMPTY
                if (
                    txtUsername.Text == "" ||
                    txtPassword.Text == ""
                )
                {
                    MessageBox.Show(
                        "Vui lòng nhập đầy đủ thông tin!"
                    );

                    return;
                }

                string username =
                    txtUsername.Text.Trim();

                string password =
                    txtPassword.Text.Trim();

                AuthBUS bus =
                    new AuthBUS();

                bool success =
                    bus.Login(
                        username,
                        password
                    );

                if (success)
                {
                    // SAVE SESSION
                    Session.Username =
                        username;

                    // SAVE CURRENT USER
                    frmGames.CurrentUsername =
                        username;

                    MessageBox.Show(
                        "Đăng nhập thành công!"
                    );

                    frmDashboard f =
                        new frmDashboard();

                    f.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Sai tài khoản hoặc mật khẩu!"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
    }
}