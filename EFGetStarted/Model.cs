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
            modelBuilder.Entity<CERT_Student>().HasKey(c => c.StudentId);//设置student主键
            modelBuilder.Entity<CERT_Student>().Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();//设置name类型
            modelBuilder.Entity<CERT_Student>().Property(teachers => teachers.Sex).HasColumnType("varchar(25)").IsRequired();//设置性别类型

            modelBuilder.Entity<CERT_teacher>().HasKey(c => c.TeacherId);//设置teacher主键
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Age).HasColumnType("vinyint").IsRequired();
            modelBuilder.Entity<CERT_teacher>().Property(t => t.Sex).HasColumnType("varchar(25)").IsRequired();

            modelBuilder.Entity<CERT_course>().HasKey(c => c.id );
            modelBuilder.Entity<CERT_course>().Property(t => t.courseday).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_course>().Property(t => t.coursename).HasColumnType("varchar(25)").IsRequired();
            modelBuilder.Entity<CERT_course>().Property(t => t.coursepoint).HasColumnType("vinyint").IsRequired();

            modelBuilder.Entity<CERT_courselist>().HasKey(p=>p.courseid);
            modelBuilder.Entity<CERT_courselist>().HasOne<CERT_course>().WithOne().HasForeignKey<CERT_course>(d => d.id);//设置外键

            modelBuilder.Entity<CERT_studentlist>().HasOne<CERT_Student>().WithOne().HasForeignKey<CERT_Student>(d=>d.StudentId);
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
        public CERT_courselist courselist{get;set;}
    }
    [Table("CERT_teacher", Schema = "11nstz")]
    public class CERT_teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public CERT_courselist courselist
        { set;get;}
    }
    [Table("CERT_courselist", Schema = "11nstz")]
    public class CERT_courselist//个人课程表
    {
        public int courseid {get;set;}//课程标号
        public string coursename { get;set;}//课程名
        public string courseday { get;set;}//星期几
        public int coursepoint { get;set;}//第几节
    }
    [Table("CERT_course", Schema = "11nstz")]
    public class CERT_course//课程库
    {
        public int id { get; set; }
        public string courseday//星期几
        {
            get { return courseday; }
            set
            {
                courseday = day.GetName(typeof(day), value);
            }

        }
        public int coursepoint { get; set; }//第几节
        public string coursename { get; set; }//课程名
        public int TeacherId{get;set;}
        public CERT_studentlist studentlist{get;set;}
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
    [Table("CERT_course_studentlist",Schema="11nstz")]
    public class CERT_studentlist
    {
        public int Id{get;set;}
        public string studentname{get;set;}
        public string sex{get;set;}
    }
}