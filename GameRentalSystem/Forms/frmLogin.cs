using GameRentalSystem.BUS;
using GameRentalSystem.DAL;
using GameRentalSystem.DTO;
using System;
using System.Windows.Forms;

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

        // =========================
        // REGISTER
        // =========================
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

        // =========================
        // LOGIN
        // =========================
        private void btnLogin_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                // CHECK EMPTY
                if (
                    txtUsername.Text.Trim() == "" ||
                    txtPassword.Text.Trim() == ""
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

                // LOGIN FAIL
                if (!success)
                {
                    MessageBox.Show(
                        "Sai tài khoản hoặc mật khẩu!"
                    );

                    return;
                }

                // =========================
                // SAVE SESSION
                // =========================
                UserDAL userDAL =
                    new UserDAL();

                UserDTO user =
                    userDAL.GetUserByUsername(
                        username
                    );

                if (user != null)
                {
                    Session.UserID =
                        user.UserID;

                    Session.Username =
                        user.Username;

                    Session.Role =
                        user.Role;

                    Session.CustomerID =
                        user.CustomerID;

                    Session.FullName =
                        user.FullName;
                }

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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }
    }
}