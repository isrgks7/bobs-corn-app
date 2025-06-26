using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BobCorn.Domain.Entities;
using BobCorn.Domain.Interfaces;
using BobCorn.Infrastructure.Data;

namespace BobCorn.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DateTime?> GetLastPurchaseAsync(string clientId)
        {
            return await _context.CornPurchases
                .Where(p => p.ClientId == clientId)
                .OrderByDescending(p => p.PurchaseTime)
                .Select(p => (DateTime?)p.PurchaseTime)
                .FirstOrDefaultAsync();
        }

        public async Task AddPurchaseAsync(string clientId, DateTime time)
        {
            var purchase = new CornPurchase
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                PurchaseTime = time
            };

            _context.CornPurchases.Add(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
