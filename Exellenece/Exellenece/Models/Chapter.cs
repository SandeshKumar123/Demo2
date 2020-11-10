using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("Tbl_Chapter")]
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select board")]
        public int Board_Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Please select subject")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "Enter chapter heading")]
        public string Chapter_Heading { get; set; }
         
        public string Chapter_Video { get; set; }


        [Required(ErrorMessage = "Enter chapter content")]
        public string Chapter_Content { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
    }

    public class Chapter1
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select board")]
        public int Board_Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Please select subject")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "Enter chapter heading")]
        public string Chapter_Heading { get; set; }
         
        public string Chapter_Video { get; set; }

         
        [Required(ErrorMessage = "Enter chapter content")]
        public string Chapter_Content { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }



        public string Class_Name { get; set; }


        public string Board_Name { get; set; }


        public string Subject_Name { get; set; }

        public List<Board> BoardList { get; set; }

        public List<Subject> SubjectList { get; set; }
         
        public List<AddClass> ClassList { get; set; }


        public HttpPostedFileBase file1 { get; set; }

        public PagedList.IPagedList<Chapter1> ChapterList1 { get; set; }



    }
}