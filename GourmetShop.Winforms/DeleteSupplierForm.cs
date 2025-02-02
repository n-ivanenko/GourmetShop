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
using GourmetShop.DataAccess.Repositories;

namespace GourmetShop.Winforms
{
    public partial class DeleteSupplierForm : Form
    {
        private string _connectionString;
        private readonly SupplierRepository _supplierRepository;
        public DeleteSupplierForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _supplierRepository = new SupplierRepository("Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False");
            LoadSupplier();
        }
        private void LoadSupplier()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, CompanyName FROM Supplier";
                using (var command = new SqlCommand(query, connection))
                {
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    comboboxSuppliers.DataSource = dataTable;
                    comboboxSuppliers.DisplayMember = "CompanyName";
                    comboboxSuppliers.ValueMember = "Id";
                }
            }
        }
        private void DeleteSupplier(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DeleteSupplier", connection))
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
            if (comboboxSuppliers.SelectedValue != null)
            {
                int selectedSupplierId = Convert.ToInt32(comboboxSuppliers.SelectedValue);
                string selectedCompanyName = comboboxSuppliers.Text;

                var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedCompanyName}?",
                                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        _supplierRepository.DeleteSupplier(selectedSupplierId);
                        MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadSupplier();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
