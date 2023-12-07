using BRS.Core.Entity;
using BRS.Core.Interfaces.Services;
using Inventory.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationHistoryController : ControllerBase
    {
        private readonly IReservationHistoryService _reservationHistoryService;
        public ReservationHistoryController(IReservationHistoryService reservationHistoryService)
        {
            _reservationHistoryService = reservationHistoryService;
        }
        [HttpGet("Get/{bookId}")]
        public async Task<IActionResult> GetReservationHistoryByBookId(string bookId)
        {
            try
            {
                var historyList = await _reservationHistoryService.GetReservationHistoryByBookId(new Guid(bookId));
                return Ok(historyList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
