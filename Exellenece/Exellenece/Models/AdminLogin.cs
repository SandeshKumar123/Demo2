using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Exellenece.Models
{
    [Table("Tbl_Admin")]
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Required")]
        public string Admin_Id { get; set; }
        [Required(ErrorMessage = " Required")]
        public string Admin_password { get; set; }
    }
    public class Admin1
    {
        [Required(ErrorMessage = "Enter ID")]
        public string Admin_Id { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression(@"^(?:.{6,}|)$", ErrorMessage = "Minimum 6 Characters")]
        public string Admin_Pasword { get; set; }
        [Required(ErrorMessage = "Confirm Password  Required")]
        [Compare("Admin_Pasword", ErrorMessage = "The Confirm Password do not match")]
        public string Confirm_password { get; set; }
        [Required(ErrorMessage = "Enter Current Password")]
        public string Current_Pass { get; set; }
    }
}   