using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core_DepartmanProject.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CANER\\SQLEXPRESS; database=BirimDB; integrated security=true");
        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
