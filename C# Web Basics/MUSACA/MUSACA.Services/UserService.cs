using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUSACA.Data;
using MUSACA.Models;

namespace MUSACA.Services
{
    public class UserService : IUserService
    {
        private readonly MUSACADbContext context;

        public UserService(MUSACADbContext runesDbContext)
        {
            this.context = runesDbContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username || user.Email == username)
                                                              && user.Password == password);
        }

        //TODO: Check if works
        public IQueryable<Order> GetUserReceipt(string username)
        {
            return this.context.Orders.Where(o =>
                o.Status == Status.Active && o.Cashier.Username.Equals(username));
        }
    }
}
