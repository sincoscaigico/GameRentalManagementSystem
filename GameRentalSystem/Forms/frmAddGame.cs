using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GameRentalSystem
{
    public partial class frmAddGame : Form
    {
        // =========================
        // CONNECTION
        // =========================
        string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // =========================
        // GAME ID
        // =========================
        public int GameID = 0;

        // =========================
        // CONSTRUCTOR
        // =========================
        public frmAddGame()
        {
            InitializeComponent();

            SetupModernUI();
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmAddGame_Load(
            object sender,
            EventArgs e
        )
        {
            LoadCategories();

            LoadStatus();

            // =========================
            // EDIT MODE
            // =========================
            if (GameID != 0)
            {
                LoadGameData();
            }
        }

        // =========================
        // MODERN UI
        // =========================
        private void SetupModernUI()
        {
            this.BackColor =
                Color.FromArgb(15, 15, 35);

            panel1.BackColor =
                Color.FromArgb(20, 20, 45);

            StyleButton(
                btnSave,
                Color.FromArgb(110, 70, 255)
            );

            StyleButton(
                btnCancel,
                Color.FromArgb(255, 70, 70)
            );
        }

        // =========================
        // BUTTON STYLE
        // =========================
        private void StyleButton(
            Button btn,
            Color color
        )
        {
            btn.BackColor = color;

            btn.ForeColor =
                Color.White;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );
        }

        // =========================
        // LOAD STATUS
        // =========================
        private void LoadStatus()
        {
            cboStatus.Items.Clear();

            cboStatus.Items.Add(
                "Available"
            );

            cboStatus.Items.Add(
                "Out Of Stock"
            );

            cboStatus.SelectedIndex = 0;
        }

        // =========================
        // LOAD CATEGORY
        // =========================
        private void LoadCategories()
        {
            try
            {
                SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                string query =
                    "SELECT * FROM Categories";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        conn
                    );

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                cboCategory.DataSource =
                    dt;

                cboCategory.DisplayMember =
                    "CategoryName";

                cboCategory.ValueMember =
                    "CategoryID";

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
        // LOAD GAME DATA
        // =========================
        private void LoadGameData()
        {
            try
            {
                SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                string query = @"
SELECT *
FROM Games
WHERE GameID=@id";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@id",
                    GameID
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtGameName.Text =
                        reader["GameName"]
                        .ToString();

                    txtGenre.Text =
                        reader["Genre"]
                        .ToString();

                    txtPlatform.Text =
                        reader["Platform"]
                        .ToString();

                    numYear.Value =
                        Convert.ToDecimal(
                            reader["ReleaseYear"]
                        );

                    numPrice.Value =
                        Convert.ToDecimal(
                            reader["RentalPrice"]
                        );

                    numStock.Value =
                        Convert.ToDecimal(
                            reader["StockQuantity"]
                        );

                    cboStatus.Text =
                        reader["Status"]
                        .ToString();

                    cboCategory.SelectedValue =
                        reader["CategoryID"];
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
        // SAVE GAME
        // =========================
        private void btnSave_Click(
            object sender,
            EventArgs e
        )
        {
            // =========================
            // VALIDATION
            // =========================
            if (
                txtGameName.Text == "" ||
                txtGenre.Text == "" ||
                txtPlatform.Text == ""
            )
            {
                MessageBox.Show(
                    "Please enter all information!"
                );

                return;
            }

            try
            {
                SqlConnection conn =
                    new SqlConnection(
                        connectionString
                    );

                conn.Open();

                // =========================
                // CHECK DUPLICATE
                // =========================
                string checkQuery = "";

                if (GameID == 0)
                {
                    checkQuery = @"
SELECT COUNT(*)
FROM Games
WHERE GameName=@name";
                }
                else
                {
                    checkQuery = @"
SELECT COUNT(*)
FROM Games
WHERE GameName=@name
AND GameID != @id";
                }

                SqlCommand checkCmd =
                    new SqlCommand(
                        checkQuery,
                        conn
                    );

                checkCmd.Parameters.AddWithValue(
                    "@name",
                    txtGameName.Text
                );

                checkCmd.Parameters.AddWithValue(
                    "@id",
                    GameID
                );

                int exist =
                    Convert.ToInt32(
                        checkCmd.ExecuteScalar()
                    );

                if (exist > 0)
                {
                    MessageBox.Show(
                        "Game name already exists!"
                    );

                    conn.Close();

                    return;
                }

                // =========================
                // INSERT / UPDATE
                // =========================
                string query = "";

                if (GameID == 0)
                {
                    query = @"
INSERT INTO Games
(
    GameName,
    Genre,
    Platform,
    ReleaseYear,
    RentalPrice,
    StockQuantity,
    Status,
    CategoryID
)
VALUES
(
    @name,
    @genre,
    @platform,
    @year,
    @price,
    @stock,
    @status,
    @category
)";
                }
                else
                {
                    query = @"
UPDATE Games
SET
    GameName=@name,
    Genre=@genre,
    Platform=@platform,
    ReleaseYear=@year,
    RentalPrice=@price,
    StockQuantity=@stock,
    Status=@status,
    CategoryID=@category
WHERE GameID=@id";
                }

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@name",
                    txtGameName.Text
                );

                cmd.Parameters.AddWithValue(
                    "@genre",
                    txtGenre.Text
                );

                cmd.Parameters.AddWithValue(
                    "@platform",
                    txtPlatform.Text
                );

                cmd.Parameters.AddWithValue(
                    "@year",
                    numYear.Value
                );

                cmd.Parameters.AddWithValue(
                    "@price",
                    numPrice.Value
                );

                cmd.Parameters.AddWithValue(
                    "@stock",
                    numStock.Value
                );

                cmd.Parameters.AddWithValue(
                    "@status",
                    cboStatus.Text
                );

                cmd.Parameters.AddWithValue(
                    "@category",
                    cboCategory.SelectedValue
                );

                cmd.Parameters.AddWithValue(
                    "@id",
                    GameID
                );

                cmd.ExecuteNonQuery();

                conn.Close();

                // =========================
                // SUCCESS MESSAGE
                // =========================
                if (GameID == 0)
                {
                    MessageBox.Show(
                        "Add game successfully!"
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Update game successfully!"
                    );
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // CANCEL
        // =========================
        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            this.Close();
        }
        private void panel1_Paint(
    object sender,
    PaintEventArgs e
)
        {

        }

        private void label10_Click(
            object sender,
            EventArgs e
        )
        {

        }
    }
}