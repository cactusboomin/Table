using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Table.Domain;
using Table.Domain.Entities;

namespace Table.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(DataManager manager)
        {
            this.Users = manager.Users.GetUsers().ToList();
        }

        public List<User> Users { get; set; }
    }
}
