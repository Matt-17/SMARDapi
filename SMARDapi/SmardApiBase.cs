namespace SMARDapi;

public abstract class SmardApiBase
{
    private readonly string _baseUrl = "https://www.smard.de/app/";
    private readonly HttpClient _httpClient;

    protected SmardApiBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<string> SendHttpGetRequest(string endpoint)
    {
        var url = _baseUrl + endpoint;
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}