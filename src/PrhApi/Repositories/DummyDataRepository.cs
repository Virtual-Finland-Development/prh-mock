using System.Text.Json;
using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

internal class DummyDataRepository : IDummyDataRepository
{
    private readonly List<string> _dummyBusinessIds;
    private readonly ILogger<DummyDataRepository> _logger;

    public DummyDataRepository(ILogger<DummyDataRepository> logger)
    {
        _logger = logger;
        _dummyBusinessIds = new List<string> { "0522908-2", "921902433", "5590379409" };
    }

    public bool IsDummyBusinessId(string businessId)
    {
        return _dummyBusinessIds.Contains(FormatBusinessIdInput(businessId));
    }

    public EstablishmentResponse? ReadEstablishment(string businessId)
    {
        using var reader = new StreamReader($"Data/establishment/{FormatBusinessIdInput(businessId)}.json");
        var contents = reader.ReadToEnd();

        var responseObject = JsonSerializer.Deserialize<EstablishmentResponse>(contents);
        return responseObject;
    }

    public BeneficialOwnersResponse? ReadBeneficialOwners(string businessId)
    {
        using var reader = new StreamReader($"Data/beneficial-owners/{FormatBusinessIdInput(businessId)}.json");
        var contents = reader.ReadToEnd();

        var responseObject = JsonSerializer.Deserialize<BeneficialOwnersResponse>(contents);
        return responseObject;
    }

    public SignatoryRightsResponse? ReadSignatoryRights(string businessId)
    {
        using var reader = new StreamReader($"Data/signatory-rights/{FormatBusinessIdInput(businessId)}.json");
        var contents = reader.ReadToEnd();

        var responseObject = JsonSerializer.Deserialize<SignatoryRightsResponse>(contents);
        return responseObject;
    }

    public string ResolveLegalForm(string businessId)
    {
        switch (FormatBusinessIdInput(businessId))
        {
            case "0522908-2":
                return "FI_OY";
            case "921902433":
                return "NO_AS";
            case "5590379409":
                return "SE_AB";
            default:
                return "FI_OY";
        }
    }

    public string ResolveAdminUnitLevel(string businessId)
    {
        switch (FormatBusinessIdInput(businessId))
        {
            case "0522908-2":
                return "FIN";
            case "921902433":
                return "NOR";
            case "5590379409":
                return "SWE";
            default:
                return "FIN";
        }
    }

    private string FormatBusinessIdInput(string businessId)
    {
        return businessId.Replace(" ", "");
    }
}
