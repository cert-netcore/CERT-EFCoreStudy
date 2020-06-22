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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CERT_Student>().HasKey(c => new { c.StudentId });//设置student主键
            modelBuilder.Entity<CERT_Student>().Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();//设置name类型
            modelBuilder.Entity<CERT_Student>().Property(teachers => teachers.Sex).HasColumnType("varchar(25)").IsRequired();//设置性别类型

            modelBuilder.Entity<CERT_teacher>().HasKey(c => new { c.TeacherId });//设置teacher主键
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Age).HasColumnType("vinyint").IsRequired();
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Sex).HasColumnType("varchar(25)").IsRequired();

            modelBuilder.Entity<CERT_course>().HasKey(c => new { c.ID });
            modelBuilder.Entity<CERT_course>().Property(t=>t.courseday).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_course>().Property(t=>t.coursename).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_course>().Property(t=>t.coursepoint).HasColumnType("vinyint").IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
        }

    }
    [Table("CERT_Student", Schema = "11nstz")]
    public class CERT_Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
    [Table("CERT_teacher", Schema = "11nstz")]
    public class CERT_teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
    [Table("CERT_course", Schema = "11nstz")]
    public class CERT_course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }//标记数量
        public string courseday
        {
            get { return courseday; }
            set
            {
                courseday = day.GetName(typeof(day), value);
            }

        }//第几天
        public int coursepoint { get; set; }//标注在第几节课
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