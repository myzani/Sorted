using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SortedExam
{
    public class ApiBase : ControllerBase
    {
        protected virtual async Task<ActionResult<RainfallReadingResponse>> ParseResponse(HttpResponseMessage response)
        {
            if(response == null)
            {
                return default;
            }

            RainfallReadingResponse rainfallResponses = new();

            string responseString = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                rainfallResponses = JsonSerializer.Deserialize<RainfallReadingResponse>(responseString);

                if(!rainfallResponses.RainfallReading.Any())
                {
                    rainfallResponses.ErrorResponse.Message = responseString ?? "No rainfall readings data";

                    return NotFound(rainfallResponses);
                }
                return Ok(rainfallResponses);
            }

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                rainfallResponses.ErrorResponse.Message = responseString;
                
                return NotFound(rainfallResponses);
            }

            return BadRequest();
        }
    }
}