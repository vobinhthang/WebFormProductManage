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
        public static User GetOne(User user)
        {
            SqlConnection conn = ConnectionDb.GetConnection();
            string sql = "select Username,Password from [tbl__User] where Username=@username ";
        }
    }
}