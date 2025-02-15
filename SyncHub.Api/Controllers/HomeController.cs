using Microsoft.AspNetCore.Mvc;
using SyncHub.Application.Applications.Interfaces;
using SyncHub.Domain.Entities;
using SyncHub.Domain.Models;


namespace SyncHub.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ICardApplication _cardApplication;
        public HomeController(ICardApplication cardApplication) 
        {
            _cardApplication = cardApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Card> result = await _cardApplication.GetAllCards();
                return Ok(result);
            }
            catch (Exception ex)    
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> Get([FromQuery] CardFilter filter)
        {
            try
            {
                List<Card> result = await _cardApplication.GetCardsByFilter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
