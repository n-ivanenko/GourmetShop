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

namespace GourmetShop.Winforms
{
    public partial class MainForm : Form

    {
        private readonly ProductRepository _productRepository;

        public MainForm()
        {
            InitializeComponent();
            _productRepository = new ProductRepository("Data Source = localhost; Initial Catalog = GourmetShop; Integrated Security = True; Encrypt = False");

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gourmetShopDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
            // TODO: This line of code loads data into the 'gourmetShopDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            //var newProduct = new Product
            //{
            //    ProductName = txtProductName.Text,
            //    UnitPrice = decimal.Parse(txtProductPrice.Text),
            //    S
            //};

            //_productRepository.AddProduct(newProduct);
            //MessageBox.Show("Product added successfully.");
            //RefreshProducts();
        }

        private void RefreshProducts()
        {
            //var products = _productRepository.GetAllProducts();
            //dgvProducts.DataSource = products.ToList();
        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //private void RefreshProducts()
        //{
        //    var products = _productRepository.GetAllProducts();
        //    dgvProducts.DataSource = products.ToList();
        //}
        

        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var products = _productRepository.GetAllProducts();
            //dgvProducts.DataSource = products.ToList();
        }

        private void dvgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dvgSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
