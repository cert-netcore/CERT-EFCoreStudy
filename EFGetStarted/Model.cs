using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class CERTContext : DbContext
    {
        public DbSet<CERT_Student> students { get; set; }
        public DbSet<CERT_teacher> teachers { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CERT.db");
    }
    public class CERT_Student
    {
        [Key]
        public int StudentId{get;set;}
        public string Name {get;set;}
        public string Sex {get;set;}
    }
    public class CERT_teacher
    {
        [Key]
        public int TeacherId{get;set;}
        public string Name {get;set;}
        public int Age {get;set;}

    }
   public class CERT_course
   {
       public List<string> coursename{get;set;}
        [Key]
       public List<string> coursetime{get;set;}
   }
}