using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class OrderDetailService
    {
        public static List<OrderDetail> GetAll(int _id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__OrderDetail].Id, [tbl__OrderDetail].OrderId,  [tbl__Product].Name ,  [tbl__Product].Thumbnail ,
                               [tbl__OrderDetail].Price,[tbl__OrderDetail].Amount,
							   [tbl__Order].FullName,[tbl__Order].PhoneNumber,[tbl__Order].Address
                            from [tbl__OrderDetail]
                            inner join [tbl__Product] 
                            on [tbl__Product].ID=[tbl__OrderDetail].ProductId 
							inner join [tbl__Order] 
                            on [tbl__Order].ID=[tbl__OrderDetail].OrderId 
                           where [tbl__OrderDetail].OrderId =@id
                           ";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    OrderId = Convert.ToInt32(sqlDataReader["OrderId"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    FullName = Convert.ToString(sqlDataReader["FullName"]),
                    PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]),
                    Address = Convert.ToString(sqlDataReader["Address"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),
                    Price = Convert.ToString(sqlDataReader["Price"]),
                    Amount = Convert.ToInt32(sqlDataReader["Amount"]),
                };
                orderDetails.Add(orderDetail);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return orderDetails;


        }
        public static bool DeleteAllOrder(int _id)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__OrderDetail] where OrderId=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }
        public static bool Delete(OrderDetail orderDetail)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__OrderDetail] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", orderDetail.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }

        public static OrderDetail GetOrderDetailById(int _id)
        {
            OrderDetail orderDetail = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__OrderDetail].Id, [tbl__OrderDetail].OrderId,  [tbl__Product].Name ,  [tbl__Product].Thumbnail ,
                               [tbl__OrderDetail].Price,[tbl__OrderDetail].Amount				  
                            from [tbl__OrderDetail]
                            inner join [tbl__Product] 
                            on [tbl__Product].ID=[tbl__OrderDetail].ProductId 
							
                           where [tbl__OrderDetail].Id =@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                orderDetail = new OrderDetail
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    OrderId=Convert.ToInt32(sqlDataReader["OrderId"]),
                    
                    Price = Convert.ToString(sqlDataReader["Price"]),
                    Amount = Convert.ToInt32(sqlDataReader["Amount"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    Thumbnail = Convert.ToString(sqlDataReader["Thumbnail"]),

                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return orderDetail;
        }
        public static bool CreateOrUpdate(OrderDetail orderDetail)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (orderDetail.Id != 0)
            {
                sql = "update [tbl__OrderDetail] set OrderId=@orderid,ProductId=@productid,Price=@price,Amount=@amount where Id=@id";
            }
            else
            {
                sql = "insert into [tbl__OrderDetail](OrderId,ProductId,Price,Amount) values(@orderid,@productid,@price,@amount)";
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", orderDetail.Id);
            sqlCommand.Parameters.AddWithValue("@orderid", orderDetail.OrderId);
            sqlCommand.Parameters.AddWithValue("@productid", orderDetail.ProductId);
            sqlCommand.Parameters.AddWithValue("@price", orderDetail.Price);
            sqlCommand.Parameters.AddWithValue("@amount", orderDetail.Amount);
           

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