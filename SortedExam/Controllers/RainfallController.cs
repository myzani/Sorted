using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SortedExam.Controllers;

[ApiController]
[Route("[controller]")]
public class RainfallController : ApiBase
{
    private readonly RainfallService _rainfallService;
    private readonly ILogger<RainfallController> _logger;

    public RainfallController(RainfallService rainfallService, ILogger<RainfallController> logger)
    {
        _rainfallService = rainfallService;
        _logger = logger;
    }

    /// <summary>
    /// Returns rainfall data for the specified station
    /// </summary>
    /// <param name="stationId"></param>
    /// <returns></returns>
    [Route("id/{stationId}/readings")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RainfallReadingResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public async Task<ActionResult<RainfallReadingResponse>> Get([FromRoute] string stationId) // = "52203"
    {
        if (string.IsNullOrEmpty(stationId) || (stationId.Length <= 0 && stationId.Length > 100))
        {
            return BadRequest("Invalid station id");
        }

        try
        {
            var result = await _rainfallService.GetRainfallReadings(stationId);

            return await base.ParseResponse(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal server error");

            return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to get rainfall data");
        }
    }
}
