using GameRentalSystem.BUS;
using System;
using System.Windows.Forms;

namespace GameRentalSystem
{
    public partial class frmRentGame : Form
    {
        // =========================
        // DATA FROM frmGames
        // =========================
        public int GameID = 0;

        public string GameName = "";

        public string Genre = "";

        public decimal Price = 0;

        public int Stock = 0;

        // =========================
        // CONSTRUCTOR
        // =========================
        public frmRentGame()
        {
            InitializeComponent();
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmRentGame_Load(
            object sender,
            EventArgs e
        )
        {
            // GAME INFO
            lblGameName.Text =
                GameName;

            lblGenre.Text =
                "Genre: " + Genre;

            lblPrice.Text =
                "$" + Price + " / day";

            // STOCK
            lblStock.Text =
                "Stock: " + Stock;

            // DEFAULT
            rdo3Days.Checked = true;

            UpdateSummary();
        }

        // =========================
        // UPDATE SUMMARY
        // =========================
        private void UpdateSummary()
        {
            int days =
                GetSelectedDays();

            decimal total =
                Price * days;

            lblSummaryGame.Text =
                "Game: " + GameName;

            lblSummaryDuration.Text =
                "Duration: " + days + " Days";

            lblSummaryPrice.Text =
                "Price/day: $" + Price;

            lblTotal.Text =
                "TOTAL: $" + total;
        }

        // =========================
        // GET SELECTED DAYS
        // =========================
        private int GetSelectedDays()
        {
            if (rdo7Days.Checked)
            {
                return 7;
            }

            if (rdo10Days.Checked)
            {
                return 10;
            }

            if (rdo30Days.Checked)
            {
                return 30;
            }

            return 3;
        }

        // =========================
        // RADIO EVENTS
        // =========================
        private void rdo3Days_CheckedChanged(
            object sender,
            EventArgs e
        )
        {
            UpdateSummary();
        }

        private void rdo7Days_CheckedChanged(
            object sender,
            EventArgs e
        )
        {
            UpdateSummary();
        }

        private void rdo10Days_CheckedChanged(
            object sender,
            EventArgs e
        )
        {
            UpdateSummary();
        }

        private void rdo30Days_CheckedChanged(
            object sender,
            EventArgs e
        )
        {
            UpdateSummary();
        }

        // =========================
        // CONFIRM RENT
        // =========================
        private void btnConfirmRent_Click(
            object sender,
            EventArgs e
        )
        {
            try
            {
                // CHECK STOCK
                if (Stock <= 0)
                {
                    MessageBox.Show(
                        "Game hết hàng!"
                    );

                    return;
                }

                int days =
                    GetSelectedDays();

                decimal total =
                    Price * days;

                // BUS
                RentalBUS bus =
                    new RentalBUS();

                // RENT
                bus.RentGame(
                    GameID,
                    total,
                    days
                );

                MessageBox.Show(
                    "Thuê game thành công!"
                );

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
        private void btnCancelRent_Click(
            object sender,
            EventArgs e
        )
        {
            this.Close();
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
    }
}