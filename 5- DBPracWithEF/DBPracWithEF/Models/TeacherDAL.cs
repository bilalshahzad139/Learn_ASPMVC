using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{
    public class TeacherDAL
    {
        public bool SaveTeacher(TeacherDTO dto)
        {
            using (var ctx = new SMSContext())
            {
                if (dto.TID > 0)
                {
                    //Update 
                    var query = from p in ctx.Teachers
                                where p.TID == dto.TID
                                select p;

                    //Now query will be executed on DB and will return result
                    var result = query.FirstOrDefault();

                    if (result != null)
                    {
                        result.Name = dto.Name;
                        result.Subject = dto.Subject;
                    }

                }
                else
                {
                    ctx.Teachers.Add(dto);
                }

                ctx.SaveChanges();
            }
            return true;
        }

        public List<TeacherDTO> GetAll()
        {
            using (var ctx = new SMSContext())
            {

                //ToList()
                //First()
                //FirstOrDefault();
                //Single()
                //SignleOrDefualt();

                return ctx.Teachers.ToList();
            }
        }
        public TeacherDTO GetById(int id)
        {
            using (var ctx = new SMSContext())
            {
                return ctx.Teachers.Where(p => p.TID == id).FirstOrDefault();
            }
        }
        public void RemoveById(int id)
        {
            using (var ctx = new SMSContext())
            {
                var result =  ctx.Teachers.Where(p => p.TID == id).FirstOrDefault();
                if (result != null)
                {
                    ctx.Teachers.Remove(result);
                    ctx.SaveChanges();
                }
            }
        }


    }
}