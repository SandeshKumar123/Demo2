using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exellenece.Models
{
    [Table("tbl_Score")]
    public class UserScore
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalAttendQuestion { get; set; }
        public int TotalRightAnswer { get; set; }
        public int TotalWrongAnswer { get; set; }
        public DateTime Score_Date { get; set; }
    }
}