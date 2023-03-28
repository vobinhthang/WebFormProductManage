using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class OrderService
    {
        public static List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "select Id,FullName,PhoneNumber,Address,OrderDate,TotalMoney from [tbl__Order]";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Order order = new Order
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    FullName = Convert.ToString(sqlDataReader["FullName"]),
                    PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]),
                    Address = Convert.ToString(sqlDataReader["Address"]),
                    OrderDate = Convert.ToDateTime(sqlDataReader["OrderDate"]),
                    TotalMoney =Convert.ToString(sqlDataReader["TotalMoney"]),
                };
               
                orders.Add(order);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return orders;


        }
        public static bool Delete(Order order)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__Order] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", order.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }

        public static Order GetOrderById(int _id)
        {
            Order order = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select Id,FullName,PhoneNumber,Address,OrderDate,TotalMoney from [tbl__Order] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                order = new Order
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    FullName = Convert.ToString(sqlDataReader["FullName"]),
                    PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]),
                    Address = Convert.ToString(sqlDataReader["Address"]),
                    OrderDate = Convert.ToDateTime(sqlDataReader["OrderDate"]),
                    TotalMoney = Convert.ToString(sqlDataReader["TotalMoney"]),
                };
         
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return order;
        }
        public static bool CreateOrUpdate(Order order)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (order.Id != 0)
            {
                sql = "update [tbl__Order] set FullName=@fullname,PhoneNumber=@phonenumber,Address=@address,OrderDate=@orderdate,TotalMoney=@totalmoney where Id=@id";
            }
            else
            {
                sql = "insert into [tbl__Order](FullName,PhoneNumber,Address,OrderDate,TotalMoney) values(@fullname,@phonenumber,@address,@orderdate,@totalmoney)";
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", order.Id);
            sqlCommand.Parameters.AddWithValue("@fullname", order.FullName);
            sqlCommand.Parameters.AddWithValue("@phonenumber", order.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@address", order.Address);
            sqlCommand.Parameters.AddWithValue("@orderdate", order.OrderDate);
            sqlCommand.Parameters.AddWithValue("@totalmoney", order.TotalMoney);

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