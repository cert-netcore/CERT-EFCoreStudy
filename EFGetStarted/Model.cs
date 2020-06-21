using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFGetStarted
{
    public class CERTContext : DbContext
    {
        public DbSet<CERT_Student> students { get; set; }
        public DbSet<CERT_teacher> teachers { get; set; }
        public DbSet<CERT_course> courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
        }

    }
    [Table("CERT_Student", Schema = "11nstz")]
    public class CERT_Student
    {
        [Key, Required]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
    [Table("CERT_teacher", Schema = "11nstz")]
    public class CERT_teacher
    {
        [Key, Required]
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

    }
    [Table("CERT_course", Schema = "11nstz")]
    public class CERT_course
    {

        [Required, Key]
        
        public string courseday
        {
            get { return courseday; }
            set
            {
                courseday = day.GetName(typeof(day), value);
            }

        }//第几天
        public int coursenumber { get; set; }//标注在第几节课
        public string coursename { get; set; }
        public enum day
        {
            Monday = 1,
            Tuestday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

    }
}