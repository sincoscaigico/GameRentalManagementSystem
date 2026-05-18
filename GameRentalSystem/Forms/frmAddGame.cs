using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameRentalSystem
{
    public partial class frmAddGame : Form
    {
        public int GameID = 0;

        public frmAddGame()
        {
            InitializeComponent();
        }

        private void frmAddGame_Load(object sender, EventArgs e)
        {
            cboStatus.Items.Add("Available");
            cboStatus.Items.Add("Out Of Stock");

            cboStatus.SelectedIndex = 0;

            SqlConnection conn = Database.GetConnection();

            conn.Open();

            string query = "SELECT * FROM Categories";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            cboCategory.DataSource = dt;

            cboCategory.DisplayMember = "CategoryName";

            cboCategory.ValueMember = "CategoryID";

            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // kiểm tra rỗng
            if (txtGameName.Text == "" ||
                txtGenre.Text == "" ||
                txtPlatform.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");

                return;
            }

            try
            {
                SqlConnection conn = Database.GetConnection();

                conn.Open();

                // kiểm tra trùng tên game
                string checkQuery = "";

                if (GameID == 0)
                {
                    checkQuery =
                    "SELECT COUNT(*) FROM Games WHERE GameName=@name";
                }
                else
                {
                    checkQuery =
                    "SELECT COUNT(*) FROM Games WHERE GameName=@name AND GameID != @id";
                }

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue("@name", txtGameName.Text);
                checkCmd.Parameters.AddWithValue("@id", GameID);

                int exist = (int)checkCmd.ExecuteScalar();

                if (exist > 0)
                {
                    MessageBox.Show("Tên game đã tồn tại!");

                    conn.Close();

                    return;
                }

                // add hoặc update
                string query = "";

                if (GameID == 0)
                {
                    query =
                    "INSERT INTO Games(GameName, Genre, Platform, ReleaseYear, RentalPrice, StockQuantity, Status, CategoryID) " +
                    "VALUES(@name, @genre, @platform, @year, @price, @stock, @status, @category)";
                }
                else
                {
                    query =
                    "UPDATE Games SET " +
                    "GameName=@name, " +
                    "Genre=@genre, " +
                    "Platform=@platform, " +
                    "ReleaseYear=@year, " +
                    "RentalPrice=@price, " +
                    "StockQuantity=@stock, " +
                    "Status=@status, " +
                    "CategoryID=@category " +
                    "WHERE GameID=@id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", txtGameName.Text);
                cmd.Parameters.AddWithValue("@genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("@platform", txtPlatform.Text);
                cmd.Parameters.AddWithValue("@year", numYear.Value);
                cmd.Parameters.AddWithValue("@price", numPrice.Value);
                cmd.Parameters.AddWithValue("@stock", numStock.Value);
                cmd.Parameters.AddWithValue("@status", cboStatus.Text);
                cmd.Parameters.AddWithValue("@category", cboCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@id", GameID);

                cmd.ExecuteNonQuery();

                if (GameID == 0)
                {
                    MessageBox.Show("Thêm game thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật game thành công!");
                }

                conn.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}