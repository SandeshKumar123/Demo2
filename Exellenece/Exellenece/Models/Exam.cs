using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("Tbl_Exam")]
    public class Exam
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select board")]
        public int Board_Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Please select subject")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "Please select chapter")]
        public int Chapter_Id { get; set; } 

        [Required(ErrorMessage = "Please enter question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_A { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_B { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_C { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_D { get; set; }

        [Required(ErrorMessage = "Please select right answer")]
        public string Right_Answer{ get; set; }

        public string Answer_Description { get; set; }
        

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
    }

    public class Exam1 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select board")]
        public int Board_Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Please select subject")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "Please select chapter")]
        public int Chapter_Id { get; set; }

        [Required(ErrorMessage = "Please enter question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_A { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_B { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_C { get; set; }

        public string Combo_Type { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Answer_D { get; set; }

        [Required(ErrorMessage = "Please select right answer")]
        public string Right_Answer { get; set; }

        public string Answer_Description { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }


        public string Class_Name { get; set; }

        public string Subject_Name { get; set; }
         
        public string Board_Name { get; set; }

        public string Chapter_Heading  { get; set; }

        public double Price { get; set; }
        public double Discount_Price { get; set; }

        public List<Board> BoardList { get; set; }

        public List<Subject> SubjectList { get; set; }

        public List<AddClass> ClassList { get; set; } 

        public List<Chapter> ChapterList { get; set; }

        public List<ComboPackage1> FullData { get; set; }


        public List<SinglePackage> SinglePackageList { get; set; }

        public List<ComboPackage> ComboPackageList { get; set; }


        public List<Chapter1> ChapterList1 { get; set; }


        public List<Exam> ExamList  { get; set; }
        public PagedList.IPagedList<Exam1> ExamList1 { get; set; }
    } 
}