using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.DataAccess.Repositories
{
    public class SupplierRepository : Repository<Supplier>
    {
        private readonly string _connectionString;

        public SupplierRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public override IEnumerable<Supplier> GetAll()
        {
            var suppliers = new List<Supplier>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetAllSuppliers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var supplier = new Supplier
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                                ContactName = reader.GetString(reader.GetOrdinal("ContactName"))
                            };
                            suppliers.Add(supplier);
                        }
                    }
                }
            }

            return suppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("InsertSupplier", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", supplier.Id);
                    command.Parameters.AddWithValue("@Name", supplier.CompanyName);
                    command.Parameters.AddWithValue("@Contact", supplier.ContactName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    using (var command = new SqlCommand("UpdateSupplier", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@Id", supplier.Id);
            //        command.Parameters.AddWithValue("@Name", supplier.CompanyName);
            //        command.Parameters.AddWithValue("@Contact", supplier.ContactName);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
        }

        public void DeleteSupplier(int id)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    using (var command = new SqlCommand("DeleteSupplier", connection))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@Id", id);

            //        connection.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
        }
        public Supplier GetSupplierById(int id)
        {
            Supplier entity = default(Supplier);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Supplier WHERE Id = @Id";
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


