using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Table.Domain.Entities;
using Table.Domain.Repositories.Abstract;

namespace Table.Domain.Repositories.EntityFramework
{
    public class EFUserRepository : IUserRepository
    {
        private readonly TableDbContext context;

        public EFUserRepository(TableDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            this.context.CustomUsers.Add(user);
            this.context.SaveChanges();
        }

        public void BlockUser(string userId)
        {
            var user = this.context.CustomUsers.Find(new object[] { userId });

            if (user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(200);
                this.context.CustomUsers.Update(user);
                this.context.SaveChanges();
            }
        }

        public void DeleteUser(string userId)
        {
            var user = this.context.CustomUsers.Find(new object[] { userId });

            if (user != null)
            {
                this.context.CustomUsers.Remove(user);
                this.context.SaveChanges();
            }
        }

        public IQueryable<User> GetUsers()
        {
            return this.context.CustomUsers.AsQueryable();
        }
    }
}
