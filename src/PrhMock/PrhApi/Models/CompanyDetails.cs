using System.Text.Json.Serialization;

namespace company_establishment_api.Controllers;

public class CompanyDetails
{
    [JsonPropertyName("businessId")]
    public string? BusinessId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    public void UpdateValues(CompanyDetails details)
    {
        Name = details.Name;
    }
}
