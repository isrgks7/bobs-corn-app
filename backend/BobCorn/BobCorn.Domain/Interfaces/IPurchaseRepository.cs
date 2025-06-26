using System;
using System.Threading.Tasks;

namespace BobCorn.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<DateTime?> GetLastPurchaseAsync(string clientId);
        Task AddPurchaseAsync(string clientId, DateTime time);
    }
}
