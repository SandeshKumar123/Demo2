using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{

    [Table("Tbl_Class")]
    public class AddClass
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter class name")]
        public string Class_Name { get; set; }

        [Required(ErrorMessage = "Please select date")]
        public DateTime Session_Month { get; set; }

        [Required(ErrorMessage = "Please enter no of question")]
        public int No_Of_Question { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
    }
    public class AddClass1
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter class name")]
        public string Class_Name { get; set; }
         
        public DateTime Session_Month { get; set; }

        [Required(ErrorMessage = "Please enter no of question")]
        public int No_Of_Question { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }

        public List<AddClass> ClassList { get; set; }
          

        public PagedList.IPagedList<AddClass> ClassList1 { get; set; } 
    }
} 