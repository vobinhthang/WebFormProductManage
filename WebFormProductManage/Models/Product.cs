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
        public string Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Hot { get; set; }
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }

        public int Amount { get; set; }
        public string TotalPrice { get; set; }
    }
}