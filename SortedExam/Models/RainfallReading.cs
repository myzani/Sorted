using System.Text.Json.Serialization;

namespace SortedExam;

/// <summary>
/// Rainfall reading
/// </summary>
public class RainfallReading
{
    private string _dateTimeMeasured;

    [JsonPropertyName("measure")]
    public string DateMeasured { get; set; }
    [JsonPropertyName("dateTime")]
    public string DateTimeMeasured
    {
        get 
        { 
            return _dateTimeMeasured;
        }
        set
        {
            _dateTimeMeasured = DateTimeHelper.FormatDateTime(value); 
        }
    }
}