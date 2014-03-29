using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{
    public class StudentDAL
    {
        public bool SaveStudent(StudentDTO dto)
        {
            using (var ctx = new SMSContext())
            {
                if (dto.StudentID > 0)
                {
                    //Update 
                    var query = from p in ctx.Students
                                where p.StudentID == dto.StudentID
                                select p;

                    //Now query will be executed on DB and will return result
                    var result = query.FirstOrDefault();

                    if (result != null)
                    {
                        result.StudentName = dto.StudentName;
                        result.FatherName = dto.FatherName;
                    }

                }
                else
                {
                    ctx.Students.Add(dto);
                }

                ctx.SaveChanges();
            }
            return true;
        }

        public List<StudentDTO> GetAll()
        {
            using (var ctx = new SMSContext())
            {

                //ToList()
                //First()
                //FirstOrDefault();
                //Single()
                //SignleOrDefualt();

                return ctx.Students.ToList();
            }
        }
        public StudentDTO GetById(int id)
        {
            using (var ctx = new SMSContext())
            {
                return ctx.Students.Where(p => p.StudentID == id).FirstOrDefault();
            }
        }
        public void RemoveById(int id)
        {
            using (var ctx = new SMSContext())
            {
                var result = ctx.Students.Where(p => p.StudentID == id).FirstOrDefault();
                if (result != null)
                {
                    ctx.Students.Remove(result);
                    ctx.SaveChanges();
                }
            }
        }


    }
}