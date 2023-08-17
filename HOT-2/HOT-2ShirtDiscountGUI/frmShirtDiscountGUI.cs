using System;
using System.Windows.Forms;

namespace HOT_2ShirtDiscountGUI
{
    public partial class frmShirtDiscountGUI : Form
    {
        public frmShirtDiscountGUI()
        {
            InitializeComponent();
        }

        // Declare and intialize program constants.
        const decimal THIRTYOFF  =   0.3m;
        const decimal TWENTYOFF  =   0.2m;
        const decimal TENOFF     =   0.1m;
        const decimal SHIRTPRICE = 13.75m;
        const decimal TAXRATE    =  0.08m;

        private void btnOrder_Click(object sender, EventArgs e)
        {
            AttemptToOrder();
        }

        private void AttemptToOrder()
        {
            bool result;
            int qty     = 0;
            string code = txtCode.Text;

            // Check for nothing entered into the quantity textbox.
            if (txtQuantity.Text.Trim() == "")
            {
                ShowErrorMessage("You must enter a quantity!",
                                 "No Quantity Inputed");

                txtQuantity.Focus();
                return;
            }

            // There was a value in the quantity textbox. Verify that the quantity was numeric & that the quantity
            // was positive.
            result = Int32.TryParse(txtQuantity.Text, out qty);

            if (!result || qty <= 0)                                         // Non-numeric, 0, or negative input.
            {
                ShowErrorMessage("You must enter a positive numeric quantity!",
                                 "Non-Numeric, Zero, Or Negative Quantity Inputted");

                txtQuantity.Text = "";
                txtQuantity.Focus();
                return;
            }

            // A positive number was inputted into quantity textbox
            decimal discount = CheckDiscountCode(code);

            ShowInvoice(qty, discount);
        }

        private decimal CheckDiscountCode(string code)
        {
            decimal discount;

            switch (code)
            {
                case "8264":
                    discount = 0.3m;
                    break;

                case "5679":
                    discount = 0.2m;
                    break;

                case "6483":
                    discount = 0.1m;
                    break;

                default:
                    discount = 0m;
                    break;
            }

            return discount;
        }

        private void ShowInvoice(int qty, decimal discount)
        {
            decimal shirtCost  = (discount == 0m) ? SHIRTPRICE
                                                  : SHIRTPRICE - (SHIRTPRICE * discount);

            decimal subTotal   = qty      * shirtCost;
            decimal taxTotal   = subTotal * TAXRATE;
            decimal finalTotal = subTotal + taxTotal;

            string outputStr = "";
            outputStr += qty.ToString() +
                         "T-Shirts @ "       + shirtCost.ToString("c") + " each\r\n";
            outputStr += "---------------------------------------------";
            outputStr += "\r\nSubtotal:\t\t" + subTotal.ToString("c");
            outputStr += "\r\nTax:\t\t"      + taxTotal.ToString("c");
            outputStr += "\r\nTotal:\t\t"    + finalTotal.ToString("c");

            txtReceipt.Text = outputStr;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit the program?",
                                                  "Exit Now?",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtQuantity.Text = "";
            txtCode.Text     = "";
            txtReceipt.Text  = "";

            txtQuantity.Focus();
        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
