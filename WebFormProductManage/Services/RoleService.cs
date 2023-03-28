using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class RoleService
    {
        public static List<Role> GetAll()
        {
            List<Role> roles = new List<Role>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "select Id,Name from [tbl__Role]";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Role role = new Role
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                  
                };
                roles.Add(role);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return roles;


        }
        public static bool Delete(Role role)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__Role] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", role.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }

        public static Role GetUserById(int _id)
        {
            Role role = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select Id,Name from [tbl__Role] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                role = new Role
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Name = Convert.ToString(sqlDataReader["Name"]),
                    
                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return role;
        }
        public static bool CreateOrUpdate(Role role)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (role.Id != 0)
            {
                sql = "update [tbl__Role] set Name=@name where Id=@id";
            }
            else
            {
                sql = "insert into [tbl__Role](Name) values(@name)";
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", role.Id);
            sqlCommand.Parameters.AddWithValue("@name", role.Name);
       

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