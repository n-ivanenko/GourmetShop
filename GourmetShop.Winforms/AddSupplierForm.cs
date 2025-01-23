using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.Winforms
{
    public partial class AddSupplierForm : Form
    {
        public AddSupplierForm()
        {
            InitializeComponent();
        }
            public Supplier NewSupplier { get; private set; }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text) || string.IsNullOrEmpty(txtContactName.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                NewSupplier = new Supplier
                {
                    CompanyName = txtCompanyName.Text,
                    ContactName = txtContactName.Text,
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }
    }

