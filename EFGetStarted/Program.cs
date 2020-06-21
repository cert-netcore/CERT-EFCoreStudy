using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new CERTContext())
            {
              
                Console.WriteLine("Inserting a new student");
                db.Add(new CERT_Student { Name = "张三" , StudentId=2 , Sex="男"});
                db.SaveChanges();
                Console.WriteLine("Querying for a student");
                var blog = db.students
                    .OrderBy(b => b.Name)
                    .First();
                 Console.WriteLine(blog.ToString());
              
            }
        }
    }
}