using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebProgrammingExam.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
