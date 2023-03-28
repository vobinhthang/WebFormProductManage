using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class ProductService
    {
        
        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price, [tbl__Product].Description,[tbl__Product].Hot,[tbl__Product].Color,[tbl__Producer].Fullname
                            from [tbl__Product]
                            inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID 
                            order by NEWID()";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                    
                    Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Hot = Convert.ToString(sqlDataReader["Hot"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),
                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),
                };
                
              
                if (product.Hot.Equals("True"))
                    product.Hot = "Có";
                else
                {
                    product.Hot = "Không";
                }

                
                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;


        }
        public static List<Product> Get6Product()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "SELECT TOP 6 ID,Thumbnail,Name,Price FROM [tbl__Product] order by NEWID()";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),

                };

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;


        }
        public static List<Product> Get5Product()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "SELECT TOP 5 ID,Thumbnail,Name,Price FROM [tbl__Product] order by NEWID()";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),

                };

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;


        }
        public static List<Product> Get10ProductHot()
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "SELECT TOP 10 ID,Thumbnail,Name,Price FROM [tbl__Product] where Hot=1 order by NEWID()";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),

                };

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;


        }
        public static List<Product> Get5ProductByProducer(int _id)
        {
            List<Product> products = new List<Product>();
            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = $@"select top 5 [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price,[tbl__Product].Description,[tbl__Product].Color,[tbl__Producer].Fullname
                            from [tbl__Product] inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID where [tbl__Product].ProducerID={_id} order by NEWID()";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                    Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),

                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),

                };

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;
        }
        public static List<Product> GetAllProductByProducer(int _id)
        {
            List<Product> products = new List<Product>();
            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = $@"select [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price,[tbl__Product].Description,[tbl__Product].Color,[tbl__Producer].Fullname
                            from [tbl__Product] inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID where [tbl__Product].ProducerID={_id}";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),
                    
                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),

                };

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;
        }
        public static bool CreateOrUpdate(Product product)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (product.Id != 0)
            {
                sql = "update [tbl__Product] set Name=@name,Price=@price,ProducerID=@producerID,Description=@description,Hot=@hot,Color=@color where Id=@id";
            }
            else
            {
                sql = "insert into [tbl__Product](Name,Thumbnail,Price,ProducerID,Description,Hot,Color) values(@name,@thumbnail,@price,@producerID,@description,@hot,@color)";
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", product.Id);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@thumbnail", product.Thumbnail);
            sqlCommand.Parameters.AddWithValue("@price", product.Price);
            sqlCommand.Parameters.AddWithValue("@producerID", product.ProducerID);
            sqlCommand.Parameters.AddWithValue("@description", product.Description);
            sqlCommand.Parameters.AddWithValue("@hot", product.Hot);
            sqlCommand.Parameters.AddWithValue("@color", product.Color);

            int rs = sqlCommand.ExecuteNonQuery();
            if (rs > 0)
            {
                conn.Close();
                conn.Dispose();
                return true;
            }
            conn.Close();
            conn.Dispose();
            return false;
        }
        public static bool UpdateImage(Product product)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            
                string sql = "update [tbl__Product] set Thumbnail=@thumbnail where Id=@id";
            
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", product.Id);
            sqlCommand.Parameters.AddWithValue("@thumbnail", product.Thumbnail);


            int rs = sqlCommand.ExecuteNonQuery();
            if (rs > 0)
            {
                conn.Close();
                conn.Dispose();
                return true;
            }
            conn.Close();
            conn.Dispose();
            return false;
        }
        public static Product GetProductById(int _id)
        {
            Product product = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price,[tbl__Product].Description,[tbl__Product].Color,[tbl__Product].Hot, [tbl__Producer].Fullname, [tbl__Product].ProducerID
                            from [tbl__Product] inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID where [tbl__Product].ID=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                    Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),
                    Hot = Convert.ToString(sqlDataReader["Hot"]),
                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),
                    ProducerID= Convert.ToInt32(sqlDataReader["ProducerID"]),
                };
                if (product.Hot.Equals("True"))
                {
                    product.Hot = "Có";
                }
                else
                {
                    product.Hot = "Không";
                }
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return product;
        }
        public static List<Product> ListProductById(int _id)
        {
            List<Product> products = new List<Product>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price,[tbl__Product].Description,[tbl__Product].Color,[tbl__Product].Hot, [tbl__Producer].Fullname
                            from [tbl__Product] inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID where [tbl__Product].ID=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    //Price = Convert.ToInt32(string.Format("{0:#,##0.00}", sqlDataReader["Price"])),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),
                    Hot = Convert.ToString(sqlDataReader["Hot"]),
                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),

                };
                if (product.Hot.Equals("True"))
                {
                    product.Hot = "Có";
                }
                else
                {
                    product.Hot = "Không";
                }

                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;
        }
        public static bool Delete(Product product)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__Product] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", product.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }
        public static List<Product> Search(string _search)
        {
            List<Product> products = new List<Product>();
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = @"select [tbl__Product].ID, [tbl__Product].Name,  [tbl__Product].Thumbnail , 
                                [tbl__Product].Price, [tbl__Product].Description,[tbl__Product].Hot,[tbl__Product].Color,[tbl__Producer].Fullname
                            from [tbl__Product] inner join [tbl__Producer] 
                            on [tbl__Product].ProducerID=[tbl__Producer].ID
                            where( [tbl__Product].Name like '%" + _search + "%' or  [tbl__Producer].Fullname like '%" + _search + "%')";
 

            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            while (sqlDataReader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                     Price = Convert.ToDouble(sqlDataReader["Price"]).ToString("###,###", cul.NumberFormat),
                    Description = Convert.ToString(sqlDataReader["Description"]),
                    Hot = Convert.ToString(sqlDataReader["Hot"]),
                    Color = Convert.ToString(sqlDataReader["Color"]),
                    ProducerName = Convert.ToString(sqlDataReader["Fullname"]),
                };
                if (product.Hot.Equals("True"))
                {
                    product.Hot = "Có";
                }
                else
                {
                    product.Hot = "Không";
                }
                products.Add(product);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return products;

        }
    }
}