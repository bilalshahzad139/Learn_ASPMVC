using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPracWithEF.Models
{
    public class UserDAL
    {
        public bool SaveUser(Users dto)
        {
            using (var ctx = new SMSContext())
            {
                if (dto.UserID > 0)
                {
                    //Update 
                    var query = from p in ctx.Users
                                where p.UserID == dto.UserID 
                                select p;

                    //Now query will be executed on DB and will return result
                    var result = query.FirstOrDefault();

                    if (result != null)
                    {
                        result.FirstName = dto.FirstName;
                        result.LastName = dto.LastName;
                        result.Gender = dto.Gender;
                    }


                }
                else
                {
                    ctx.Users.Add(dto);
                }
                
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Users> GetAllUsers()
        {
            //Using handles the disposal by itself
            using (var ctx = new SMSContext())
            {
                //LINQ builder approach
                var list = ctx.Users.ToList();

                /*
                var query = from p in ctx.Users
                            select p;

                var list = query.ToList();
                */

                return list;
            }
        }

        public Users GetUserById(int userid)
        {
            using (var ctx = new SMSContext())
            {
                //LINQ to Entities approach
                //This is just query object in memory
                var query = from p in ctx.Users
                            where p.UserID == userid
                            select p;

                //Now query will be executed on DB and will return result
                var result = query.FirstOrDefault();


                //ctx.Users.Where(p => p.UserID == userid).FirstOrDefault();

               

                return result;
            }
        }

        public bool DeleteUserById(int userid)
        {
            using (var ctx = new SMSContext())
            {
                //LINQ to Entities approach
                //This is just query object in memory
                var query = from p in ctx.Users
                            where p.UserID == userid
                            select p;

                //Now query will be executed on DB and will return result
                var result = query.FirstOrDefault();

                if (result != null)
                {
                    ctx.Users.Remove(result);
                    ctx.SaveChanges();
                }

                return true;
            }
        }

        public bool VerifyLogin(String Login, String Password)
        {
            using (var ctx = new SMSContext())
            {
                var query = from p in ctx.Users
                            where p.Login == Login && p.Password == Password
                            select p;

                var cnt = query.Count();

                if (cnt > 0)
                    return true;
                else
                    return false;

            }
        }
    }
}