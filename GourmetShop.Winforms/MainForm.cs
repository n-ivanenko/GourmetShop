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
        // Button Methods
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
            //this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
            //this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
        }
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            
        }

        //Add Supplier button
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
        //Menu Methods
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



        
        //IGNORE COMMENTED OUT CODE//
       

        private void dvgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var productId = (int)dvgProducts.Rows[e.RowIndex].Cells[0].Value; // Assuming the ID is in the first column
            //    var product = _productRepository.GetProductById(productId);
            //    if (e.ColumnIndex == dvgProducts.Columns["Edit"].Index)
            //    {
            //        // Edit product
            //        using (var editProductForm = new EditProductForm(product))
            //        {
            //            if (editProductForm.ShowDialog() == DialogResult.OK)
            //            {
            //                var updatedProduct = editProductForm.UpdatedProduct;
            //                _productRepository.UpdateProduct(updatedProduct);
            //                this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
            //            }
            //        }
            //    }
            //    else if (e.ColumnIndex == dvgProducts.Columns["Delete"].Index)
            //    {
            //        // Delete product
            //        var result = MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.Yes)
            //        {
            //            _productRepository.DeleteProduct(productId);
            //            this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
            //        }
            //    }
            //}
        }

        private void dvgSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var supplierId = (int)dvgSupplier.Rows[e.RowIndex].Cells[0].Value; // Assuming the ID is in the first column
            //    var supplier = _productRepository.GetSupplierById(supplierId);
            //    if (e.ColumnIndex == dvgSupplier.Columns["Edit"].Index)
            //    {
            //        // Edit supplier
            //        using (var editSupplierForm = new EditSupplierForm(supplier))
            //        {
            //            if (editSupplierForm.ShowDialog() == DialogResult.OK)
            //            {
            //                var updatedSupplier = editSupplierForm.UpdatedSupplier;
            //                _productRepository.UpdateSupplier(updatedSupplier);
            //                this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
            //            }
            //        }
            //    }
            //    else if (e.ColumnIndex == dvgSupplier.Columns["Delete"].Index)
            //    {
            //        // Delete supplier
            //        var result = MessageBox.Show("Are you sure you want to delete this supplier?", "Delete Supplier", MessageBoxButtons.YesNo);
            //        if (result == DialogResult.Yes)
            //        {
            //            _productRepository.DeleteSupplier(supplierId);
            //            this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
            //        }
            //    }
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //string searchText = textBox2.Text.ToLower();
            //var filteredProducts = _productRepository.GetAllProducts()
            //    .Where(p => p.Name.ToLower().Contains(searchText)).ToList();
            //this.productBindingSource.DataSource = filteredProducts;
        }

        private void tctSupplierName_TextChanged(object sender, EventArgs e)
        {
            //string searchText = tctSupplierName.Text.ToLower();
            //var filteredSuppliers = _productRepository.GetAllSuppliers()
            //    .Where(s => s.Name.ToLower().Contains(searchText)).ToList();
            //this.supplierBindingSource.DataSource = filteredSuppliers;
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            //var selectedRow = dvgProducts.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            //if (selectedRow != null)
            //{
            //    var productId = (int)selectedRow.Cells[0].Value;
            //    var product = _productRepository.GetProductById(productId);
            //    using (var editProductForm = new EditProductForm(product))
            //    {
            //        if (editProductForm.ShowDialog() == DialogResult.OK)
            //        {
            //            var updatedProduct = editProductForm.UpdatedProduct;
            //            _productRepository.UpdateProduct(updatedProduct);
            //            this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
            //        }
            //    }
            //}
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            //var selectedRow = dvgProducts.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            //if (selectedRow != null)
            //{
            //    var productId = (int)selectedRow.Cells[0].Value;
            //    var result = MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        _productRepository.DeleteProduct(productId);
            //        this.productTableAdapter.Fill(this.gourmetShopDataSet.Product);
            //    }
            //}
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            //var selectedRow = dvgSupplier.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            //if (selectedRow != null)
            //{
            //    var supplierId = (int)selectedRow.Cells[0].Value;
            //    var supplier = _productRepository.GetSupplierById(supplierId);
            //    using (var editSupplierForm = new EditSupplierForm(supplier))
            //    {
            //        if (editSupplierForm.ShowDialog() == DialogResult.OK)
            //        {
            //            var updatedSupplier = editSupplierForm.UpdatedSupplier;
            //            _productRepository.UpdateSupplier(updatedSupplier);
            //            this.supplierTableAdapter.Fill(this.gourmetShopDataSet.Supplier);
            //        }
            //    }
            //}
        }
    }
}
