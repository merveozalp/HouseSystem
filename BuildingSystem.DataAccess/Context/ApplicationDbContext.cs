using BuildingSystem.Entities.Entity;
using Entites.Entitiy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Context
{
    public class ApplicationDbContext:IdentityDbContext<User , Role,string>
    {
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Messange> Messanges { get; set; }
        
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Flat>()
            .HasIndex(p => new { p.FlatNumber, p.BuildingId }).IsUnique();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
