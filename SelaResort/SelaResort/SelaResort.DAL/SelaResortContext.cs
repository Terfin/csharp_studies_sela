using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SelaResort.DAL
{
    internal class SelaResortContext : DbContext
    {
        public DbSet<CommonPerson> People { get; set; }
        public DbSet<CommonOrder> Orders { get; set; }
        public DbSet<CommonRoom> Rooms { get; set; }
    }
}
