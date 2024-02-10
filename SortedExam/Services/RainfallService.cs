namespace SortedExam
{
    public class RainfallService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RainfallService> _logger;

        public RainfallService(IHttpClientFactory httpClientFactory, ILogger<RainfallService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> GetRainfallReadings(string stationId)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("RainfallApi");

                return await client.GetAsync($"id/stations/{stationId}/readings");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get rainfall data");
                return null;
            }
        }
    }
}