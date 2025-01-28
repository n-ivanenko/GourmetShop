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
using GourmetShop.DataAccess.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GourmetShop.Winforms
{
    public partial class MainForm : Form

    {
        private readonly ProductRepository _productRepository;
        private readonly SupplierRepository _supplierRepository;

        public MainForm()
        {
            InitializeComponent();
            _productRepository = new ProductRepository("Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False");
            _supplierRepository = new SupplierRepository("Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False");

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gourmetShopDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
            // TODO: This line of code loads data into the 'gourmetShopDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);

        }
        // Add Product button
        private void button1_Click(object sender, EventArgs e)
        {
            using (var addProductForm = new AddProductForm())
            {
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    var newProduct = addProductForm.NewProduct;

                    _productRepository.AddProduct(newProduct);

                    this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
                }
            }
        }

        // Edit Product Button
        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False";
            var updateForm = new UpdateProductForm(connectionString);
            updateForm.ShowDialog();
        }
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            
        }

        // Add Supplier button
        private void button4_Click(object sender, EventArgs e)
        {
            using (var addSupplierForm = new AddSupplierForm())
            {
                if (addSupplierForm.ShowDialog() == DialogResult.OK)
                {
                    var newSupplier = addSupplierForm.NewSupplier;

                    _supplierRepository.AddSupplier(newSupplier);

                    this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
                }
            }
        }

        // Edit Supplier Button
        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False";
            var updateForm = new UpdateSuppliersForm(connectionString);
            updateForm.ShowDialog();
        }

        // Menu Methods
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
        }
        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
        }
        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var products = _productRepository.GetAll();  

            dvgProducts.DataSource = products.ToList();  
        }

        private void viewSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var suppliers = _supplierRepository.GetAll();

            dvgSupplier.DataSource = suppliers.ToList();
        }

        private void dvgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dvgSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tctSupplierName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            
        }
    }
}
