using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDT621_SectionC_Question1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string make = txtMake.Text;
            int quantity = 0;

            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(make))
            {
                lblOutput.Text = "Please enter both code and/or make";
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                lblOutput.Text = "Please enter a valid quantity";
                return;
            }

            if(tblMobilePhones.RowCount == 1)
            {
                tblMobilePhones.Controls.Add(new Label { Text = "Code" }, 0, 0);
                tblMobilePhones.Controls.Add(new Label { Text = "Make" }, 1, 0);
                tblMobilePhones.Controls.Add(new Label { Text = "Quantity" }, 2, 0);
            }

            int rowIndex = tblMobilePhones.RowCount++;
            tblMobilePhones.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMobilePhones.Controls.Add(new Label { Text = code }, 0, rowIndex);
            tblMobilePhones.Controls.Add(new Label { Text = make }, 1, rowIndex);
            tblMobilePhones.Controls.Add(new Label { Text = quantity.ToString() }, 2, rowIndex);

            lblOutput.Text = "Record Added";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;

            if (string.IsNullOrWhiteSpace(code))
            {
                lblOutput.Text = "Please enter the code to delete";
                return;
            }

            if(code == "Code")
            {
                lblOutput.Text = "Invalid code given";
                return;
            }

            for(int i = 1; i < tblMobilePhones.RowCount; i++)
            {
                Label lblCodeSearch = tblMobilePhones.GetControlFromPosition(0, i) as Label;
                if (lblCodeSearch != null && lblCodeSearch.Text == code)
                {
                    for (int j = 0; j < tblMobilePhones.ColumnCount; j++)
                    {
                        Control control = tblMobilePhones.GetControlFromPosition(j, i);
                        if (control != null)
                        {
                            tblMobilePhones.Controls.Remove(control);
                        }
                    }
                    lblOutput.Text = "Record Deleted";
                    return;
                }
            }

            lblOutput.Text = "Can not find that code";
        }
    }
}
