using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Model;

namespace User.Infrastructure.Persistence
{
    public partial class UserContext: DbContext
    {
        public UserContext() { }
        public  UserContext(DbContextOptions<UserContext> options):base(options) 
        {
        }

        public virtual DbSet<UserModel> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

       partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
