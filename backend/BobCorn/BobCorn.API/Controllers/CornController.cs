using Microsoft.AspNetCore.Mvc;
using BobCorn.Domain.Interfaces;

namespace BobCorn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CornController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public CornController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("{clientId}")]
        public async Task<IActionResult> BuyCorn(string clientId)
        {
            var result = await _purchaseService.TryPurchaseAsync(clientId);
            if (!result)
                return StatusCode(429, "🌽 Too many requests");

            return Ok("🌽 Corn purchased!");
        }
    }
}
