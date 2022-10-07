using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormProductManage.Common.enums;

namespace WebFormProductManage.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Thumbnail { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public byte Hot { get; set; }
    }
}