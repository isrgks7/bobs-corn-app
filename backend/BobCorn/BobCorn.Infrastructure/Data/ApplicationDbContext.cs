using Microsoft.EntityFrameworkCore;
using BobCorn.Domain.Entities;
using System.Collections.Generic;

namespace BobCorn.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CornPurchase> CornPurchases { get; set; }
    }
}
