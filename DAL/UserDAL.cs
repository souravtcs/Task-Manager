using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {        
        public UserModel GetUser(LoginModel user)
        {
            UserModel loggedinuser = new UserModel();
            try
            {
                using (var userentity = new twittercloneEntities1())
                {
                    loggedinuser = userentity.People
                        .Where(s => s.UserName.ToUpper().Trim() == user.UserName.ToUpper().Trim()
                                && s.Password.Trim().ToUpper() == user.Password.Trim().ToUpper() && s.isActive == true)
                                .Select(s=> new UserModel
                                {
                                    UserId = s.UserId,
                                    UserName = s.UserName,
                                    Password = s.Password,
                                    FullName = s.FullName,
                                    DOB = s.DOB,
                                    Email = s.Email,
                                    isActive = s.isActive,
                                    JoinedOn  = s.JoinedOn
                                }).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {

            }
            return loggedinuser;
        }
        public bool RegisterUser(UserModel user)
        {
            bool res = false;
            try
            {
                Person p = new Person
                                    {
                                        UserName = user.UserName,
                                        Password = user.Password,
                                        FullName = user.FullName,
                                        Email = user.Email,
                                        DOB = user.DOB,
                                        isActive = user.isActive,
                                        JoinedOn = user.JoinedOn
                                    };
                using (var userentity = new twittercloneEntities1())
                {
                    userentity.People.Add(p);
                    res = userentity.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public bool UpdateUser(UserModel user)
        {
            bool res = false;
            try
            {
                using (var userentity = new twittercloneEntities1())
                {
                    var us = userentity.People.Find(user.UserId);
                    us.Password = user.Password;
                    us.FullName = user.FullName;
                    us.Email = user.Email;
                    us.DOB = user.DOB;
                    //us.JoinedOn = user.JoinedOn;
                    userentity.Entry(us).State = EntityState.Modified;
                    res = userentity.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public List<UserModel> GetAllUser()
        {
            List<UserModel> data = new List<UserModel>();
            try
            {
                using (var userentity = new twittercloneEntities1())
                {
                    data = userentity.People
                        .Where(s => s.isActive == true)
                                .Select(s => new UserModel
                                {
                                    UserId = s.UserId,
                                    UserName = s.UserName,
                                    Password = s.Password,
                                    FullName = s.FullName,
                                    DOB = s.DOB,
                                    Email = s.Email,
                                    isActive = s.isActive,
                                    JoinedOn = s.JoinedOn
                                }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }

    }
}
