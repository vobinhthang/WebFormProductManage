using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormProductManage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string TotalMoney { get; set; }

    }
}