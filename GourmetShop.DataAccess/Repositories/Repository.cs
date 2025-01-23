using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace GourmetShop.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly string _connectionString;
        string connectionString = ConfigurationManager.ConnectionStrings["prod"].ConnectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
            //var items = new List<T>();

            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT * FROM " + typeof(T).Name;

            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var item = MapToEntity(reader);
            //                items.Add(item);
            //            }
            //        }
            //    }
            //}

            //return items;
        }

        private T MapToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }


        public T GetById(int id)
        {
            throw new NotImplementedException();
            //T entity = default(T);

            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id";

            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Id", id);

            //        using (var reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                entity = MapToEntity(reader);
            //            }
            //        }
            //    }
            //}

            //return entity;
        }


        public void Add(T entity)
        {
            throw new NotImplementedException();
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    string query = "INSERT INTO " + typeof(T).Name + " (Column1, Column2, ...) VALUES (@Value1, @Value2, ...)";

            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Value1", entity.Property1);
            //        command.Parameters.AddWithValue("@Value2", entity.Property2);

            //        command.ExecuteNonQuery();
            //    }
            //}
        }


        public void Update(T entity)
        {
            throw new NotImplementedException();
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    string query = "UPDATE " + typeof(T).Name + " SET Column1 = @Value1, Column2 = @Value2 WHERE Id = @Id";

            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Value1", entity.Property1);
            //        command.Parameters.AddWithValue("@Value2", entity.Property2);
            //        command.Parameters.AddWithValue("@Id", entity.Id); 

            //        command.ExecuteNonQuery();
            //    }
            //}
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
            //    using (var connection = new SqlConnection(_connectionString))
            //    {
            //        connection.Open();
            //        string query = "DELETE FROM " + typeof(T).Name + " WHERE Id = @Id";

            //        using (var command = new SqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Id", id);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}

        }
    }
}

