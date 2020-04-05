using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCodingToDoTask.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int userID { get; set; }
        public virtual Users Users { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        public DateTime expiredDate { get; set; }
        public int percentage { get; set; }
        public string status { get; set; }
    }
}
