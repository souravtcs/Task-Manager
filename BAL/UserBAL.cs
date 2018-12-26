using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UserBAL
    {
        UserDAL u;
        public UserModel GetUser(LoginModel user)
        {
            UserModel loggedinUser = new UserModel();
            try
            {
                u = new UserDAL();
                loggedinUser = u.GetUser(user);
            }
            catch (Exception ex)
            {

            }
            return loggedinUser;
        }
        public bool AddUser(UserModel user)
        {
            bool res = false;
            try
            {
                u = new UserDAL();
                res = u.RegisterUser(user);
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
                u = new UserDAL();
                res = u.UpdateUser(user);
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
                u = new UserDAL();
                data = u.GetAllUser();
            }
            catch (Exception ex)
            {

            }
            return data;
        }

    }
}
