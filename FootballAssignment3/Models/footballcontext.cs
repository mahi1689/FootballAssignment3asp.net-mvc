using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FootballAssignment3.Models
{
    public class footballcontext: DbContext
    {
        public footballcontext(): base("conn")
        { }
        public DbSet<Football>   football { get; set; } 
          
    }
}