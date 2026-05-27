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
                lblOutput.Text = "Please enter both code and make.";
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                lblOutput.Text = "Please enter a valid quantity.";
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
        }
    }
}
