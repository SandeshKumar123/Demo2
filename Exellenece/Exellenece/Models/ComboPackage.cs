using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("tbl_Combo_Package")]
    public class ComboPackage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Enter package heading")]
        public string Package_Heading { get; set; }

        [Required(ErrorMessage = "Enter package sub heading")]
        public string Package_Sub_Heading { get; set; }


        [Required(ErrorMessage = "Enter package price")]
        public double Package_Price { get; set; }

        [Required(ErrorMessage = "Enter package discount price")]
        public double Package_Discount_Price { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
        public string Combo_Type { get; set; }

        
    }
    public class ComboPackage1
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Enter package heading")]
        public string Package_Heading { get; set; }

        [Required(ErrorMessage = "Enter package sub heading")]
        public string Package_Sub_Heading { get; set; }


        [Required(ErrorMessage = "Enter package price")]
        public double Package_Price { get; set; }

        [Required(ErrorMessage = "Enter package discount price")]
        public double Package_Discount_Price { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }

        public string Combo_Type { get; set; }

        public string Class_Name { get; set; }

        public string Session_Date { get; set; }

        public List<AddClass> ClassList { get; set; }
         
        public List<ComboPackage1> FullData { get; set; }

        public PagedList.IPagedList<ComboPackage1> ComboPackageList1 { get; set; } 
    }
}