using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace productManagement
{
    public class ProductService : IProductRepository
    {
        private string connecttionString = "Server=127.0.0.1;Database=prodb;User=root;Password=phi";
        public void Create(Product product)
        {
            // throw new NotImplementedException();
            using (MySqlConnection conn = new MySqlConnection (connecttionString)){
                conn.Open();
                string query = "INSERT INTO products (Name, Description, Price) VALUES (@Name, @Description, @Price)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.ExecuteNonQuery();
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            // throw new NotImplementedException();

            List<Product> products = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection (connecttionString)){
                conn.Open();
                string query = "SELECT * FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader()){
                    while (reader.Read()){
                        products.Add(new Product{
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Description = reader.GetString("Description"),
                            Price = reader.GetDecimal("Price"),
                        });
                    }
                }
                return products;

            }
        }

        public Product Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}