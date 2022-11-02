using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebFormProductManage.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public byte Hot { get; set; }
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
    }
}