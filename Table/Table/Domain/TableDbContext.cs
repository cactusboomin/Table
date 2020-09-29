using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Table.Domain.Entities;

namespace Table.Domain
{
    public class TableDbContext : IdentityDbContext<User>
    {
        public TableDbContext(DbContextOptions<TableDbContext> options) : base(options) { }

        public DbSet<User> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
