#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Genevill_MVC_Portfolio.Models;

namespace Genevill_MVC_Portfolio.Data
{
    public class Genevill_MVC_PortfolioContext : DbContext
    {
        public Genevill_MVC_PortfolioContext (DbContextOptions<Genevill_MVC_PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Genevill_MVC_Portfolio.Models.BugTracker> BugTracker { get; set; }

        public DbSet<Genevill_MVC_Portfolio.Models.Blog> Blog { get; set; }

        public DbSet<Genevill_MVC_Portfolio.Models.FinancialPortal> FinancialPortal { get; set; }
    }
}
