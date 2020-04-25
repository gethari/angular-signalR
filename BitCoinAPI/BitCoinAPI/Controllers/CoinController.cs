namespace BitCoinAPI.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;
	using SignalR;

	[Route("api/coinPrice")]
	[ApiController]
	public class CoinController : ControllerBase
	{
		private readonly IHubContext<CoinHub> _hub;

		public CoinController(IHubContext<CoinHub> hub)
		{
			_hub = hub;
		}

		public IActionResult Get()
		{
			var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("getCoinPrice", CoinService.GetCoinPrice()));
			return Ok(new { Message = "Request Completed" });
		}
	}
}
