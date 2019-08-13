using SMS.Data;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly SMSContext db;

        public UserService(SMSContext db)
        {
            this.db = db;
        }

        public User CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
                Cart = new Cart(),
            };

            user.Cart.UserId = user.Id;
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user;
        }

        public User GetUserOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var user = this.db.Users.FirstOrDefault(
                x => x.Username == username
                && x.Password == passwordHash);
            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
