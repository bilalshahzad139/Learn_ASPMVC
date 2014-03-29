using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcApplication2.Models
{
    public static class MyDAL
    {
        static MyDAL()
        {
            Database.SetInitializer<MyContext>(null);
            //Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
        public static int SaveStudent(Student stdObj)
        {
            using (MyContext context = new MyContext())
            {
                if (stdObj.StudentID > 0)
                {
                    var std = context.Students.Where(p => p.StudentID == stdObj.StudentID).FirstOrDefault();
                    std.Name = stdObj.Name;
                    std.Address = stdObj.Address;
                    std.Age = stdObj.Age;

                }
                else
                {
                    context.Students.Add(stdObj);
                }
                context.SaveChanges();
            }

            return stdObj.StudentID;
        }

        public static List<Student> GetAllStudents()
        {
            using (MyContext context = new MyContext())
            {
                var query = from p in context.Students
                            orderby p.StudentID descending
                            select p;

                return query.ToList();

            }

        }
        public static Student GetStudentByID(int sid)
        {
            using (MyContext context = new MyContext())
            {
                var query = from p in context.Students
                            where p.StudentID == sid
                            select p;

                return query.FirstOrDefault();

            }

        }

        public static void DeleteStudentByID(int sid)
        {
            using (MyContext context = new MyContext())
            {
                var query = from p in context.Students
                            where p.StudentID == sid
                            select p;

                var std = query.FirstOrDefault();

                context.Students.Remove(std);
                context.SaveChanges();

            }

        }
    }
}