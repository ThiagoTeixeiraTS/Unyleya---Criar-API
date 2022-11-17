using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnyleyaAtividade3.Model;

namespace UnyleyaAtividade3.Context
{
    public class CompanyContext :DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Companies> Companies { get; set; }
    }
}
