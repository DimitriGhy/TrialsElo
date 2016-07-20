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
        public IDbSet<Account> Accounts { get; set; }
        public IDbSet<Character> Characters { get; set; }
        public IDbSet<Activity> Activities { get; set; }
    }
}
