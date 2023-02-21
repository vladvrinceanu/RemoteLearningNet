using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.DataLayer
{
    internal class SQLiteProductRepository : IProductRepository
    {
        private readonly string connectionString;
        public SQLiteProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
            SeedData();
        }
        public void SeedData()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new SqliteCommand(
                    "CREATE TABLE IF NOT EXISTS Product (ColumnId INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Price DECIMAL, Quantity INTEGER)",connection);
                sql.ExecuteNonQuery();
            }
        }
        public void AddProduct(Product product)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var sql = new SqliteCommand("INSERT INTO Product (Name,Price,Quantity) VALUES (@Name,@Price,@Quantity)",connection);
                sql.Parameters.AddWithValue("@Name",product.Name);
                sql.Parameters.AddWithValue("@Price",product.Price);
                sql.Parameters.AddWithValue("@Quantity",product.Quantity);

                sql.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(string name)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new SqliteCommand("DELETE FROM Product WHERE Name = @Name", connection);

                sql.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new SqliteCommand("SELECT * FROM Product",connection);
                var reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ColumnId = Convert.ToInt32(reader["ColumnId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToSingle(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    });
                }
            }
            return products;
        }

        public Product GetByColumn(int columnId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new SqliteCommand(
                    "SELECT * FROM PRODUCT WHERE ColumnId = @ColumnId",connection);
                var reader = sql.ExecuteReader();

                if (reader.Read())
                {
                    return new Product
                    {
                        ColumnId = Convert.ToInt32(reader["ColumnId"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToSingle(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };
                }
                return null;
            }
        }
    }
}


