using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseManagementSystem.Data;
using CaseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseComment> CaseComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CaseManagementSystem;Trusted_Connection=True;Encrypt=False;");

        }
    }




}