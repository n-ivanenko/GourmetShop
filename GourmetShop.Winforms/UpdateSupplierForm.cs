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

namespace GourmetShop.Winforms
{
    public partial class UpdateSuppliersForm : Form
    {
        private string _connectionString;

        public UpdateSuppliersForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            LoadSuppliers();
        }

        // Load Products into the dropdown
        private void LoadSuppliers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, CompanyName FROM Supplier";
                using (var command = new SqlCommand(query, connection))
                {
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    comboBoxSuppliers.DataSource = dataTable;
                    comboBoxSuppliers.DisplayMember = "CompanyName";
                    comboBoxSuppliers.ValueMember = "Id";
                }
            }
        }

        // Event: Save Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSuppliers.SelectedValue == null)
            {
                MessageBox.Show("Please select a supplier.");
                return;
            }

            int supplierId = (int)comboBoxSuppliers.SelectedValue;
            string updatedCompanyName = txtCompanyName.Text;
            string updatedContactName = txtContactName.Text;

            UpdateSupplier(supplierId, updatedCompanyName, updatedContactName);
        }
        private void UpdateSupplier(int supplierId, string updatedCompanyName, string updatedContactName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                UPDATE Supplier 
                SET CompanyName = @Name, ContactName = @Contact 
                WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", supplierId);
                    command.Parameters.AddWithValue("@Name", updatedCompanyName);
                    command.Parameters.AddWithValue("@Contact", updatedContactName);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Supplier updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Ensure the supplier exists.");
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
