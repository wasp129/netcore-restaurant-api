using System.Collections.Generic;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Data.User
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(string id);
        void CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
    }
}