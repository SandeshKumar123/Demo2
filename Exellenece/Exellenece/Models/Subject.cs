using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("Tbl_Subject")]
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter subject name")] 
        public string Subject_Name { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
    }
    public class Subject1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter subject name")]
        public string Subject_Name { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }

        public List<Subject> SubjectList { get; set; }

        public PagedList.IPagedList<Subject> SubjectList1 { get; set; }
    }
}