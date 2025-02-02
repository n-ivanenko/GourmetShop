using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;

namespace GourmetShop.Winforms
{
    public partial class DeleteProductForm : Form
    {
        private string _connectionString;
        private readonly ProductRepository _productRepository;
        public DeleteProductForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _productRepository = new ProductRepository("Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False");
            LoadProducts();
        }
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

                    comboboxProducts.DataSource = dataTable;
                    comboboxProducts.DisplayMember = "ProductName";
                    comboboxProducts.ValueMember = "Id";
                }
            }
        }
        private void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboboxProducts.SelectedValue != null)
            {
                int selectedProductId = Convert.ToInt32(comboboxProducts.SelectedValue);
                string selectedProductName = comboboxProducts.Text;

                var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedProductName}?",
                                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        _productRepository.DeleteProduct(selectedProductId);
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
