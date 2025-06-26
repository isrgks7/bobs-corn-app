using System.Threading.Tasks;

namespace BobCorn.Domain.Interfaces
{
    public interface IPurchaseService
    {
        Task<bool> TryPurchaseAsync(string clientId);
    }
}
