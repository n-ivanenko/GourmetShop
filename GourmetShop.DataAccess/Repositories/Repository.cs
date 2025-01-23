using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly string _connectionString;
       // string connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var entities = new List<T>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {typeof(T).Name}s";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    entities.Add(MapToEntity(reader));
                }
            }

            return entities;
            throw new NotImplementedException();
            
        }

        public T MapToEntity(SqlDataReader reader)
        {
            if (typeof(T) == typeof(Product))
            {
                return (T)(object)new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"))
                };
            }

            if (typeof(T) == typeof(Supplier))
            {
                return (T)(object)new Supplier
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    CompanyName = reader.GetString(reader.GetOrdinal("Name")),
                    ContactName = reader.GetString(reader.GetOrdinal("Contact"))
                };
            }

            throw new NotImplementedException("Mapping for this type is not implemented.");
        }


        public T GetById(int id)
        {
            T entity = default(T);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
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


        public void Add(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {typeof(T).Name}s ({GetColumns(entity)}) VALUES ({GetValues(entity)})";
                command.ExecuteNonQuery();
            }
            throw new NotImplementedException();
            
        }


        public void Update(T entity)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    var command = connection.CreateCommand();
            //    command.CommandText = $"UPDATE {typeof(T).Name}s SET {GetUpdateValues(entity)} WHERE Id = @Id";
            //    command.Parameters.AddWithValue("@Id", GetEntityId(entity));
            //    command.ExecuteNonQuery();
            //}
            throw new NotImplementedException();
            
        }


        public void Delete(int id)
        {
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    var command = connection.CreateCommand();
            //    command.CommandText = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
            //    command.Parameters.AddWithValue("@Id", id);
            //    command.ExecuteNonQuery();
            //}
            throw new NotImplementedException();
          
        }
        private string GetColumns(T entity)
        {
            if (typeof(T) == typeof(Product))
            {
                return "ProductName, UnitPrice"; 
            }

            if (typeof(T) == typeof(Supplier))
            {
                return "CompanyName, ContactName"; 
            }

            throw new NotImplementedException("GetColumns not implemented for this entity.");
        }

        private string GetValues(T entity)
        {
            if (typeof(T) == typeof(Product))
            {
                var product = (Product)(object)entity;
                return $"@ProductName, @UnitPrice";
            }

            if (typeof(T) == typeof(Supplier))
            {
                var supplier = (Supplier)(object)entity;
                return $"@CompanyName, @ContactName";
            }

            throw new NotImplementedException("GetValues not implemented for this entity.");
        }

        //private string GetUpdateValues(T entity)
        //{
        //    if (typeof(T) == typeof(Product))
        //    {
        //        var product = (Product)(object)entity;
        //        return $"Name = @Name, Price = @Price";
        //    }

        //    if (typeof(T) == typeof(Supplier))
        //    {
        //        var supplier = (Supplier)(object)entity;
        //        return $"Name = @Name, Contact = @Contact";
        //    }

        //    throw new NotImplementedException("GetUpdateValues not implemented for this entity.");
        //}

        //private int GetEntityId(T entity)
        //{
        //    if (typeof(T) == typeof(Product))
        //    {
        //        var product = (Product)(object)entity;
        //        return product.Id;
        //    }

        //    if (typeof(T) == typeof(Supplier))
        //    {
        //        var supplier = (Supplier)(object)entity;
        //        return supplier.Id;
        //    }

        //    throw new NotImplementedException("GetEntityId not implemented for this entity.");
        //}
    }
}

