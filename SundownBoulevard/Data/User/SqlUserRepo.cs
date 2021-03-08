using System;
using System.Collections.Generic;
using System.Linq;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Data.User
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly SundownBoulevardContext _context;
        
        public SqlUserRepo(SundownBoulevardContext context)
        {
            _context = context;
        }
        
        public IEnumerable<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }
        
        public UserModel GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }
        
        public void CreateUser(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                _context.Add(user);
            }
        }

        public void UpdateUser(UserModel user) { }

        public void DeleteUser(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                _context.Users.Remove(user);
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}