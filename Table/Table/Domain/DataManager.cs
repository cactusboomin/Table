using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Table.Domain.Repositories.Abstract;

namespace Table.Domain
{
    public class DataManager
    {
        public IUserRepository Users { get; set; }

        public DataManager(IUserRepository users)
        {
            this.Users = users;
        }
    }
}
