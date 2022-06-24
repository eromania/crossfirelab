using CFL.Application.Queries.GetAssetPriceByDate;
using CFL.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CFL.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ApiController
{
    private readonly ILogger<ExchangeRateController> _logger;

    public ExchangeRateController(ILogger<ExchangeRateController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "exchangerate/{days}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetAssetPriceByDateQueryViewModel>>> Get(int days)
    {
        var response = await Mediator.Send(new GetAssetPriceByDateQuery()
        {
            Days = days
        });

        return Ok(response);
    }
}