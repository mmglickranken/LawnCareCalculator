using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace HOT2_LawnCareGUI
{
    public partial class frmLawncareGUI : Form
    {
        public frmLawncareGUI()
        {
            InitializeComponent();
        }

        // Declare and intialize program constants.
        const decimal SZNLENGTH   = 20m;
        const decimal MORESIXFEE  = 50m;
        const decimal MOREFOURFEE = 35m;
        const decimal LESSFOURFEE = 25m;


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ValidateLength();
        }

        private void ValidateLength()
        {
            // Declare and intialize program variables.
            bool    result = true;
            decimal length;

            // Check for nothing entered into the length grade textbox.
            if (txtLength.Text.Trim() == "")
            {
                ShowErrorMessage("Length textbox cannot be left empty!",
                                 "Length Textbox Input Empty");

                txtLength.Focus();
                return;
            }

            // Verify that the length is numeric & positive.
            result = Decimal.TryParse(txtLength.Text, out length);

            if (!result || (length <= 0))
            {
                ShowErrorMessage("Length textbox must be numeric and > 0!",
                                 "Length Textbox Input Invalid");

                txtLength.Text = "";
                txtLength.Focus();
                return;
            }

            // If length input is positive & numeric, calculate and display.
            else
            {
                ValidateWidth(length);
            }
        }

        private void ValidateWidth(decimal length)
        {
            // Declare and intialize program variables.
            bool    result = true;
            decimal width;

            // Check for nothing entered into the width grade textbox.
            if (txtWidth.Text.Trim() == "")
            {
                ShowErrorMessage("Width textbox cannot be left empty!",
                                 "Width Textbox Input Empty");

                txtWidth.Focus();
                return;
            }

            // Verify that the width is numeric & positive.
            result = Decimal.TryParse(txtWidth.Text, out width);

            if (!result || (width <= 0))
            {
                ShowErrorMessage("Width textbox must be numeric and > 0!",
                                 "Width Textbox Input Invalid");

                txtWidth.Text = "";
                txtWidth.Focus();
                return;
            }

            // If width input is positive & numeric, calculate and display.
            else
            {
                CalculateAndDisplay(length, width);
            }
        }

        private void CalculateAndDisplay(decimal length, decimal width)
        {
            decimal area      = length * width;
            decimal weeklyFee = 0m;

            if (area >= 600)
            {
                weeklyFee = MORESIXFEE;
            }

            else if (area < 600 && area >= 400)
            {
                weeklyFee = MOREFOURFEE;
            }

            else if (area < 400)
            {
                weeklyFee = LESSFOURFEE;
            }

            decimal total = weeklyFee * SZNLENGTH;

            txtCalculation.Text = $"Area:\t\t{area} square feet\n" +
                                   $"Weekly Fee:\t{weeklyFee:C}\n" +
                                   $"Season Length:\t{SZNLENGTH} weeks\n" +
                                   $"Total:\t\t{total:C}";
        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtLength.Text       = "";
            txtWidth.Text        = "";
            txtCalculation.Text  = "";

            txtLength.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want To Exit The Program?",
                                                  "Exit Now?",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
