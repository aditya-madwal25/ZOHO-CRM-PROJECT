using System.Net.Http;
using System.Text;
using System.Text.Json;
using ZohoIntegration.Models;

namespace ZohoIntegration.Services;

public class ZohoService
{
    private readonly HttpClient _httpClient;

    public ZohoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SendLeadAsync(string accessToken, Lead lead)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

        var requestBody = new
        {
            data = new[]
            {
                new
                {
                    First_Name = lead.FirstName,
                    Last_Name = lead.LastName,
                    Email = lead.Email,
                    Phone = lead.Phone
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(
            "https://www.zohoapis.in/crm/v8/Leads",
            content);

        return await response.Content.ReadAsStringAsync();
    }
}