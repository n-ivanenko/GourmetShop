using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public override IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetAllProducts", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ProductName = reader.GetString(reader.GetOrdinal("Name")),
                                UnitPrice = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void Add(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("InsertProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.UnitPrice);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UpdateProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.UnitPrice);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
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

        public object GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}

