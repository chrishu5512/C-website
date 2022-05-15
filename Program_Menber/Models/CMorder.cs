using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Web;

namespace Program_Menber.Models
{
    public class CMorder
    {
        [DisplayName("序號")]
       
        public int oid { get; set; }
        [DisplayName("日期")]
        [Required]
        public string odate { get; set; }
        [DisplayName("會員編號")]
        [Required]
        public int omid { get; set; }
        [DisplayName("會員姓名")]
        [Required]
        public string oname { get; set; }
        [DisplayName("產品")]
        [Required]
        public string oproduct { get; set; }
        [DisplayName("廟宇")]
        [Required]
        public string otem { get; set; }
        [DisplayName("數量")]
        [Required]
        public int ounit { get; set; }
        [DisplayName("金額")]
        [Required]
        public int opayment { get; set; }
        [DisplayName("完成訂單")]
        [Required]
        public string ofin { get; set; }
        [DisplayName("完成訂單圖片")]
        [Required]
        public string opic { get; set; }
        [DisplayName("備註")]
        [Required]
        public string odetail { get; set; }
        [DisplayName("會員信箱")]
        [Required]
        public string omemail { get; set; }

        public HttpPostedFileBase photo { get; set; }


    }
}