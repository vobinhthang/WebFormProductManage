using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormProductManage.DB
{
    public class ConnectionDb
    {
        public static SqlConnection GetConnection()
        {
            string sql = ConfigurationManager.ConnectionStrings["QuanLySanPham"].ConnectionString;
            SqlConnection conn = new SqlConnection(sql);
            if (conn != null) return conn;
            return null;
        }

    }
}