using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IUserRepository
    {
        void Create(User user);
        User Login(string username,string password);
        bool EmailAvail(string email);
    }
}
