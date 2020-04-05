using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCodingToDoTask.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string username { get; set; }

        public ICollection<ToDo> ToDo { get; set; }
    }
}
