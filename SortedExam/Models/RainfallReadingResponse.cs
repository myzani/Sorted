using System.Text.Json.Serialization;

namespace SortedExam;

/// <summary>
/// Rainfall reading response
/// </summary>
public class RainfallReadingResponse
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    [JsonPropertyName("items")]
    public List<RainfallReading> RainfallReading { get; set; }


    public ErrorResponse ErrorResponse { get; set; } = new ErrorResponse();
}