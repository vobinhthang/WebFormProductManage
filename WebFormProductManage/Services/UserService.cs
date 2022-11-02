using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormProductManage.Models;

namespace WebFormProductManage.Services
{
    public class UserService
    {
        public static User GetOne(string _username,string password)
        {
            User user = null;

            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "select Username,Password from [tbl__User] where Username=@username and Password=@password and RoleId=1";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@username", _username);
            sqlCommand.Parameters.AddWithValue("@password", password);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.Read())
            {
                user = new User
                {
                    Username = Convert.ToString(sqlDataReader["Username"]),
                    Password = Convert.ToString(sqlDataReader["Password"])
                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return user;
        }
        public static User GetOneClient(string _username, string password)
        {
            User user = null;

            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "select Username,Password from [tbl__User] where Username=@username and Password=@password and RoleId=2";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@username", _username);
            sqlCommand.Parameters.AddWithValue("@password", password);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.Read())
            {
                user = new User
                {
                    Username = Convert.ToString(sqlDataReader["Username"]),
                    Password = Convert.ToString(sqlDataReader["Password"])
                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return user;
        }
        public static bool Register(string _username, string _password)
        {
           
                SqlConnection conn = ConnectionDb.GetConnection();

                string sql = "insert into [tbl__User](Username,Password,RoleID) values(@Username,@Password,2)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Username", _username);
                sqlCommand.Parameters.AddWithValue("@Password", _password);

                int rs = sqlCommand.ExecuteNonQuery();
                if (rs > 0)
                {
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                return false;

           
        }
        public static List<User> GetAll()
        {
            List<User> users = new List<User>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__User].ID, [tbl__User].UserName,  [tbl__User].Password , 
                                [tbl__User].FullName, [tbl__Role].Name
                            from [tbl__User] inner join [tbl__Role] 
                            on [tbl__User].RoleID=[tbl__Role].ID";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                User user = new User
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Username = Convert.ToString(sqlDataReader["UserName"]),
                    Password = Convert.ToString(sqlDataReader["Password"]),
                    Fullname = Convert.ToString(sqlDataReader["FullName"]),
                    RoleName = Convert.ToString(sqlDataReader["Name"])
                };
                users.Add(user);
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return users;


        }

        public static bool Delete(User user)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "delete from [tbl__User] where Id=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id",user.Id);

            int rs = sqlCommand.ExecuteNonQuery();

            if (rs == 0) return false;

            conn.Close();
            conn.Dispose();
            return true;
        }
        public static List<Role> GetAllRole()
        {
            List<Role> roles = new List<Role>();

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = "select ID,Name from [tbl__Role]";

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
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                roles.Add(role);
            }
            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return roles;
        }

        public static bool CreateOrUpdate(User user)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql;
            if (user.Id != 0)
            {
                sql = "update [tbl__User] set Username=@username,Password=@password,Fullname=@fullname,RoleID=@roleid where Id=@id";
            }
            else
            {
                sql = "insert into [tbl__User](Username,Password,Fullname,RoleID) values(@username,@password,@fullname,@roleid)";
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", user.Id);
            sqlCommand.Parameters.AddWithValue("@username", user.Username);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            sqlCommand.Parameters.AddWithValue("@fullname", user.Fullname);
            sqlCommand.Parameters.AddWithValue("@roleid", user.RoleID);

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
        public static User GetUserById(int _id)
        {
            User user = null;

            SqlConnection conn = ConnectionDb.GetConnection();

            string sql = @"select [tbl__User].ID, [tbl__User].UserName,  [tbl__User].Password , 
                                [tbl__User].FullName, [tbl__Role].Name
                            from [tbl__User] inner join [tbl__Role] 
                            on [tbl__User].RoleID=[tbl__Role].ID where [tbl__User].ID=@id";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = System.Data.CommandType.Text;

            conn.Open();

            sqlCommand.Parameters.AddWithValue("@id", _id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                user = new User
                {
                    Id = Convert.ToInt32(sqlDataReader["ID"]),
                    Username = Convert.ToString(sqlDataReader["UserName"]),
                    Password = Convert.ToString(sqlDataReader["Password"]),
                    Fullname = Convert.ToString(sqlDataReader["FullName"]),
                    RoleName = Convert.ToString(sqlDataReader["Name"])
                };
            }

            sqlDataReader.Close();
            conn.Close();
            conn.Dispose();
            return user;
        }
    }
}