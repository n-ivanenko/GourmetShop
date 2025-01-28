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
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"))
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void AddProduct(Product product)
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

        public void UpdateProduct(Product product)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    using (var command = new SqlCommand("UpdateProduct", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@Id", product.Id);
            //        command.Parameters.AddWithValue("@Name", product.ProductName);
            //        command.Parameters.AddWithValue("@Price", product.UnitPrice);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
        }

        public void DeleteProduct(int id)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    using (var command = new SqlCommand("DeleteProduct", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@Id", id);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
        }
        public Product GetProductById(int id)
        {
            Product entity = default(Product);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Product WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entity = MapToEntity(reader);
                }
            }

            return entity;

            throw new NotImplementedException();
        }

        public object GetAllProducts(int id)
        {
            Product entity = default(Product);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Product WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entity = MapToEntity(reader);
                }
            }

            return entity;
            throw new NotImplementedException();
        }
    }
}

