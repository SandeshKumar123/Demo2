using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("tbl_Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }


        public int Combo_Id { get; set; }


        public int User_Id { get; set; }


        public string Combo_Type { get; set; }

        public double Price { get; set; }

        public double Discount_Price { get; set; }


        public string Order_Id { get; set; }
          
        public string Transaction_Id { get; set; }

        public string Status { get; set; }
         

        public string Package_Heading { get; set; }

        
    }
}