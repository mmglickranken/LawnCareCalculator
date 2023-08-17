using System;
using System.Windows.Forms;

namespace HOT2_GPA2LetterGradeGUI
{
    public partial class frmLetterGradesGUI : Form
    {
        public frmLetterGradesGUI()
        {
            InitializeComponent();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtNumericGrade.Text = "";
            txtCalculation.Text  = "";

            txtNumericGrade.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            AttemptToCalculate();
        }

        private void AttemptToCalculate()
        {
            bool result = false;
            decimal gpa = 0m;
            string letterGrade = txtCalculation.Text;

            // Check for nothing entered into the numeric grade textbox.
            if (txtNumericGrade.Text.Trim() == "")
            {
                ShowErrorMessage("Numeric Grade cannot be empty!",
                                 "Empty Numeric Grade Input");

                txtNumericGrade.Focus();
                return;
            }

            // There was a value in the numeric grade textbox. Verify that the quantity was numeric, positive &
            // within range.
            result = Decimal.TryParse(txtNumericGrade.Text, out gpa);

            if (!result || (gpa < 0) || (gpa > 4))
            {
                ShowErrorMessage("Numeric grade must be a positive numeric that is within range! (0 - 4)",
                                 "Non-Numeric, Negative Numeric Grade Input Or Empty Input");

                txtNumericGrade.Text = "";
                txtCalculation.Text = "";
                txtNumericGrade.Focus();
                return;
            }

            if (gpa < 1)
            {
                result      = true;
                letterGrade = "F";

                txtCalculation.Text = "Your letter grade is: " + letterGrade;
            }

            if (gpa > 0 && gpa <= 1.5m)
            {
                result      = true;
                letterGrade = "D";

                txtCalculation.Text = "Your letter grade is: " + letterGrade;
            }

            else if (gpa > 1.5m && gpa <= 2.5m)
            {
                result      = true;
                letterGrade = "C";

                txtCalculation.Text = "Your letter grade is: " + letterGrade;
            }

            else if (gpa > 2.5m && gpa <= 3.2m)
            {
                result      = true;
                letterGrade = "B";

                txtCalculation.Text = "Your letter grade is: " + letterGrade;
            }

            else if (gpa > 3.2m)
            {
                result      = true;
                letterGrade = "A";

                txtCalculation.Text = "Your letter grade is: " + letterGrade;
                return;
            }
        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
