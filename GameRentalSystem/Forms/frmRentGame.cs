using GameRentalSystem.BUS;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GameRentalSystem
{
    public partial class frmRentGame : Form
    {
        // DATA NHẬN TỪ frmGames
        public string GameName = "";

        public string Genre = "";

        public decimal Price = 0;

        public frmRentGame()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void frmRentGame_Load(
            object sender,
            EventArgs e
        )
        {
            // GAME INFO
            lblGameName.Text = GameName;

            lblGenre.Text =
                "Genre: " + Genre;

            lblPrice.Text =
                "$" + Price + " / day";

            // DEFAULT
            rdo3Days.Checked = true;

            UpdateSummary();
        }

        // UPDATE SUMMARY
        private void UpdateSummary()
        {
            int days = 3;

            // CHECK RADIO
            if (rdo7Days.Checked)
            {
                days = 7;
            }
            else if (rdo10Days.Checked)
            {
                days = 10;
            }
            else if (rdo30Days.Checked)
            {
                days = 30;
            }

            decimal total =
                Price * days;

            // SUMMARY
            lblSummaryGame.Text =
                "Game: " + GameName;

            lblSummaryDuration.Text =
                "Duration: " + days + " Days";

            lblSummaryPrice.Text =
                "Price/day: $" + Price;

            lblTotal.Text =
                "TOTAL: $" + total;
        }

        // RADIO CHANGED
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

        // CONFIRM RENT
        private void btnConfirmRent_Click(
     object sender,
     EventArgs e
 )
        {
            try
            {
                decimal total = 0;

                // DAYS
                if (rdo3Days.Checked)
                {
                    total = Price * 3;
                }
                else if (rdo7Days.Checked)
                {
                    total = Price * 7;
                }
                else if (rdo10Days.Checked)
                {
                    total = Price * 10;
                }
                else if (rdo30Days.Checked)
                {
                    total = Price * 30;
                }

                RentalBUS bus =
                    new RentalBUS();

                bus.RentGame(
                    GameName,
                    total
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

        private void btnCancelRent_Click(
    object sender,
    EventArgs e
)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin f =
        new frmLogin();

            f.Show();

            this.Hide();
        }
    }
}