using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class ProducerService
    {
        public static List<Producer> GetAllProducer()
        {
            List<Producer> roles = new List<Producer>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "select ID,Fullname from [tbl__Producer]";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Producer producer = new Producer
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Fullname = Convert.ToString(sqlDataReader["Fullname"])             
                };
                roles.Add(producer);
            }
            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return roles;
        }
        public static Producer GetProducerById(int _id)
        {
            Producer producer = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "select ID,Fullname from [tbl__Producer] where ID=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                producer = new Producer
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Fullname = Convert.ToString(sqlDataReader["Fullname"]),
                  
                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return producer;
        }
        public static bool Delete(Producer producer)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__Producer] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", producer.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }
        public static bool CreateOrUpdate(Producer producer)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (producer.Id != 0)
            {
                sql = "update [tbl__Producer] set Fullname=@fullname where ID=@id";
            }
            else
            {
                sql = "insert into [tbl__Producer](Fullname) values(@fullname)";
            }

            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", producer.Id);
            sqlCommand.Parameters.AddWithValue("@fullname", producer.Fullname);

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
    }
}