using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interface;
using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.IServices
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDBContext context;

        public UserRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool EmailAvail(string email)
        {
            var model = context.users.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (model != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Create(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
        }

        public User Login(string username,string password)
        {
            return context.users.Where(x => x.Email.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
        }
    }
}
