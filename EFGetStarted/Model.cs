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
        public DbSet<CERT_courselist> courselists{get;set;}
        public DbSet<CERT_studentlist> studentlists{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CERT_Student>(
            eb =>   {
                eb.HasKey(c => c.StudentId);//设置student主键
                eb.Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();//设置name类型
                eb.Property(teachers => teachers.Sex).HasColumnType("varchar(25)").IsRequired();//设置性别类型
                    });
                    
            modelBuilder.Entity<CERT_teacher>(
            eb =>   {
                    eb.HasKey(c => c.TeacherId);//设置teacher主键
                    eb.Property(t => t.Name).HasColumnType("varchar(25)").IsRequired();
                    eb.Property(t => t.Sex).HasColumnType("varchar(25)").IsRequired();
                    });

            modelBuilder.Entity<CERT_course>(
            eb =>   {
                    eb.HasKey(p => p.Id);
                    eb.Property(t => t.courseday).HasColumnType("varchar(25)").IsRequired();
                    eb.Property(t => t.coursename).HasColumnType("varchar(25)").IsRequired();
                    eb.Property(t => t.coursepoint).HasColumnType("vinyint").IsRequired();
                    eb.HasOne<CERT_teacher>().WithMany().HasForeignKey(p => p.TeacherId);
                    eb.HasIndex(p => new {p.courseday,p.coursename,p.coursepoint}).IsUnique();//使这几个列不能完全重复
                    });

            modelBuilder.Entity<CERT_courselist>(
            eb =>   {
                    eb.HasKey(p=>p.courseid);
                    eb.HasOne<CERT_course>().WithMany().HasForeignKey(p => p.courseid);//设置外键
                    eb.HasIndex(p => new {p.courseday,p.coursename,p.coursepoint}).IsUnique();
            });
            

            modelBuilder.Entity<CERT_studentlist>(
            eb =>   {
                    eb.HasOne<CERT_Student>().WithMany().HasForeignKey(d=>d.Id);
                    eb.HasKey(p => p.Id);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
        }

    }
    [Table("CERT_Student_all", Schema = "11nstz")]
    public class CERT_Student//学生库
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public CERT_courselist courselist{get;set;}
    }
    [Table("CERT_teacher_all", Schema = "11nstz")]
    public class CERT_teacher//老师库
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public CERT_courselist courselist{set;get;}
    }
    [Table("CERT_course_privatelist", Schema = "11nstz")]
    public class CERT_courselist//个人课程表
    {
        public int courseid {get;set;}//课程标号
        public string coursename { get;set;}//课程名
        public string courseday { get;set;}//星期几
        public int coursepoint { get;set;}//第几节
        public int TeacherId{get;set;}
        public CERT_studentlist studentIdlist{get;set;}
    }
    [Table("CERT_course_all", Schema = "11nstz")]
    public class CERT_course//课程库
    {
        public int Id { get; set; }
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
    public class CERT_studentlist//课程学生列表
    {
        public int Id{get;set;}
        public string studentname{get;set;}
        public string sex{get;set;}
    }
}