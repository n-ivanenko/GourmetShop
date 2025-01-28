using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.Winforms
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class UpdateProductForm : Form
    {
        private string _connectionString;

        public UpdateProductForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            LoadProducts();
        }

        // Load Products into the dropdown
        private void LoadProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, ProductName FROM Product";
                using (var command = new SqlCommand(query, connection))
                {
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    comboBoxProducts.DataSource = dataTable;
                    comboBoxProducts.DisplayMember = "ProductName";
                    comboBoxProducts.ValueMember = "Id";
                }
            }
        }

        // Event: Save Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int productId = (int)comboBoxProducts.SelectedValue;
            string updatedName = txtProductName.Text;
            decimal updatedPrice;
            string updatedSupplierId = txtSupplierId.Text;

            if (!decimal.TryParse(txtUnitPrice.Text, out updatedPrice))
            {
                MessageBox.Show("Invalid price value.");
                return;
            }

            UpdateProduct(productId, updatedName, updatedPrice, updatedSupplierId);
        }
        private void UpdateProduct(int productId, string updatedName, decimal updatedPrice, string updatedSupplierId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                UPDATE Product 
                SET SupplierId = @SupplierId, ProductName = @Name, UnitPrice = @Price 
                WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", productId);
                    command.Parameters.AddWithValue("@SupplierId", updatedSupplierId);
                    command.Parameters.AddWithValue("@Name", updatedName);
                    command.Parameters.AddWithValue("@Price", updatedPrice);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Ensure the product exists.");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
