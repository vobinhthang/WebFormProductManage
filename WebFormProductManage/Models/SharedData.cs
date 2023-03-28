using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormProductManage.Models
{
    public static class SharedData
    {
        public static List<Product> cart { get; set; } = new List<Product>();

        public static List<Product> searchproduct { get; set; } = new List<Product>();

        public static int AmountProduct { get; set; } = 1;
        public static string TotalPrice { get; set; }
        public static string Price { get; set; }
        public static int IndexItem { get; set; }
        public static string TotalPriceAdmin { get; set; }
        public static int OrderId { get; set; }
    }
}