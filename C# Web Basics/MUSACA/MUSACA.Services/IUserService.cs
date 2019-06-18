using System;
using System.Collections.Generic;
using System.Text;
using MUSACA.Models;

namespace MUSACA.Services
{
    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);

        //TODO: Add method GetUserReceipt
    }
}
