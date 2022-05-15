using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program_Menber.Models
{
    public class CMember
    {
        public int mid { get; set; }
        public string mname { get; set; }
        public string mbirth { get; set; }
        public string mgender { get; set; }
        public string memail { get; set; }
        public string mphone { get; set; }
        public string mpw { get; set; }
        public string mcity { get; set; }
        public string mpic { get; set; }

        public HttpPostedFileBase mphoto { get; set; }
    }
}