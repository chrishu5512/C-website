using Program_Menber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program_Menber.ViewModel
{
    public class OrderCreate
    {
        public List<CMorder> order { get; set; }
        public List<CMember> member { get; set; }
        public List<Product> productlist { get; set; }
        
        public int mid { get; set; }
        public string mname { get; set; }
        public string product { get; set; }
        public string temp { get; set; }

    }
}