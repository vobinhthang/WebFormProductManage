using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormProductManage.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Price { get; set; }
        public int Amount { get; set; }

    }
}