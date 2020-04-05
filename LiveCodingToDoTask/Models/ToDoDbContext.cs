using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCodingToDoTask.Models
{
    public class ToDoDbContext : DbContext
    {
        public virtual DbSet<ToDo> ToDo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        public ToDoDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= IAOC-N019\\SQLEXPRESS; Database= ToDo; Trusted_Connection=true; User=sa; Password= Password1!");
            }
        }
    }
}
