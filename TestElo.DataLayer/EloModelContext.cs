using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestElo.Model;

namespace TestElo.DataLayer
{
    public class EloModelContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
