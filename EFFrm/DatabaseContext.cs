using EFFrm.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Department> Department { get; set; }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //base.OnConfiguring(builder);
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-HEQ5CMC\\SQLEXPRESS2014;Database=EFTraining;User Id=sa; Password=P@ssw0rd;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().ToTable("Tbl_Department")
                .HasKey(d => d.id);

            modelBuilder.Entity<Student>().ToTable("Student").HasKey(s => s.id);

            // Define foreign key relationship between Student and Department
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)          // Student has one Department
                .WithMany()                        // Department can have many Students
                .HasForeignKey(s => s.departmentId); // Define the foreign key property
                                                     // Optionally, you can specify the navigation property on the Department class
            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.Students)          // Department can have many Students
            //    .WithOne(s => s.Department)        // Student belongs to one Department
            //    .HasForeignKey(s => s.departmentId); // Define the foreign key property
        }
    }
}
