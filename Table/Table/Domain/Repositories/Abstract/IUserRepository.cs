using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Table.Domain.Entities;

namespace Table.Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        void AddUser(User user);
        void DeleteUser(string userId);
        void BlockUser(string userId);
    }
}
