using System;
using System.Threading.Tasks;
using BobCorn.Domain.Interfaces;

namespace BobCorn.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseService(IPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> TryPurchaseAsync(string clientId)
        {
            var now = DateTime.UtcNow;
            var lastPurchase = await _repository.GetLastPurchaseAsync(clientId);

            if (lastPurchase != null && (now - lastPurchase.Value).TotalSeconds < 60)
                return false;

            await _repository.AddPurchaseAsync(clientId, now);
            return true;
        }
    }
}
