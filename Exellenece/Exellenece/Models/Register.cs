using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("tbl_Users")]
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid e-mail")]
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        [RegularExpression(@"^(?:.{6,}|)$", ErrorMessage = "Minimum 6 characters")]
        public string Password { get; set; }

        [Range(100000, 999999, ErrorMessage = "Please enter valid pincode")]
        [Required(ErrorMessage = "Please enter pincode")]
        public string Pin_Code { get; set; }

        [Required(ErrorMessage = "Please enter valid Mobile no")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid Mobile no")]
        [Range(1000000000, 9999999999, ErrorMessage = "Please enter valid Mobile no")]
        public string Mobile_No { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Board_Id { get; set; }
  
        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }


        [Required(ErrorMessage = "Please select type")]
        public string Type { get; set; }
         
    }

    public class Register1
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }


        [Range(100000, 999999, ErrorMessage = "Please enter valid pincode")]
        [Required(ErrorMessage = "Please enter pincode")]
        public string Pin_Code { get; set; }

        [Required(ErrorMessage = "Please enter valid Mobile no")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid Mobile no")]
        [Range(1000000000, 9999999999, ErrorMessage = "Please enter valid Mobile no")]
        public string Mobile_No { get; set; }


        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid e-mail")]
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter the password")]
        [RegularExpression(@"^(?:.{6,}|)$", ErrorMessage = "Minimum 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        public string Current_Password { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public int Board_Id { get; set; }

        [Required(ErrorMessage = "Confirm Password  Required")]
        [Compare("Password", ErrorMessage = "The confirm password do not match")]
        [NotMapped]
        public string Confirm_password { get; set;}

        public List<Board> BoardList { get; set; } 

        public List<AddClass> ClassList { get; set; }


        [Required(ErrorMessage = "Please select type")]
        public string Type { get; set; }

        public string Class_Name { get; set; }

        public string Board_Name{ get; set; } 


        public PagedList.IPagedList<Register1> RegisterList1 { get; set; }
    }
}