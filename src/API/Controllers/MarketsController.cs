using dummyApi.src.Application.DTOs;
using dummyApi.src.Application.Services.MarketService;
using dummyApi.src.Domain.Entities;using Microsoft.AspNetCore.Mvc;

namespace dummyApi.src.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MarketsController : Controller
    {
        private readonly IMarketService _marketService;

        public MarketsController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Market>> Get(int id)
        {
            var market = await _marketService.GetByIdAsync(id);

            if (market is null)
            {
                return NotFound($"Market with ID {id} not found");
            }

            return Ok(market);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Market>>> GetAll()
        {
            var markets = await _marketService.GetAllAsync();

            if (markets is null)
            {
                return NotFound("No markets found");
            }

            return Ok(markets);
        }

        [HttpPost]
        public async Task<ActionResult<Market>> Post([FromBody] Market market)
        {
            if (market is null)
            {
                return BadRequest("Market is null");
            }
            var createdMarket = await _marketService.AddAsync(market);
            return CreatedAtAction(nameof(Get), new { id = createdMarket.Id }, createdMarket);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Market>> Put(int id, [FromBody] Market market)
        {
            if (market is null) return BadRequest("Market is null or ID mismatch");

            try
            {
                var updatedMarket = await _marketService.PutUpdateAsync(id, market);
                return Ok(updatedMarket);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Market>> Patch(int id, [FromBody] MarketDto market)
        {
            if (market is null) return BadRequest("Market is null or ID mismatch");
            try
            {
                var updatedMarket = await _marketService.PatchUpdateAsync(id, market);
                return Ok(updatedMarket);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _marketService.Delete(id);
                return Ok("Market deleted");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
