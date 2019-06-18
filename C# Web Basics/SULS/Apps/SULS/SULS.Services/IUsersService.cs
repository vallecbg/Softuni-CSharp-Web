using System;
using System.Collections.Generic;
using System.Text;
using SULS.Models;

namespace SULS.Services
{
    public interface IUsersService
    {
        User CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        User GetById(string id);
    }
}
