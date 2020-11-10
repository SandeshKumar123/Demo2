using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("Tbl_Board")]
    public class Board 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter board name")]
        public string Board_Name { get; set; }
         
        [Required(ErrorMessage = "Please select status")]
        public string Status { get; set; }
    }
    public class Board1
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Required")]
        public string Board_Name { get; set; }

        [Required(ErrorMessage = " Required")] 
        public string Status { get; set; }

        public List<Board> BoardList { get; set; } 

        public PagedList.IPagedList<Board> BoardList1 { get; set; }
    }
}