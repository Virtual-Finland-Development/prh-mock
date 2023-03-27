using System.Text.Json;
using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

internal class DummyDataRepository : IDummyDataRepository
{
    private readonly List<DummyCompany> _dummyCompanies;

    public DummyDataRepository()
    {
        _dummyCompanies = new List<DummyCompany>
        {
            new DummyCompany
            {
                BusinessId = "0522908-2",
                LegalForm = "FI_OY",
            },
            new DummyCompany
            {
                BusinessId = "921902433",
                LegalForm = "NO_AS",
            },
            new DummyCompany
            {
                BusinessId = "5590379409",
                LegalForm = "SE_AB",
            }
        };
    }

    public bool IsDummyBusinessId(string businessId)
    {
        return _dummyCompanies.Any(x => x.BusinessId == FormatBusinessIdInput(businessId));
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
        var dummyCompany = _dummyCompanies.FirstOrDefault(x => x.BusinessId == FormatBusinessIdInput(businessId));
        if (dummyCompany != null)
        {
            return dummyCompany.LegalForm;
        }
        return "FI_OY";
    }

    private string FormatBusinessIdInput(string businessId)
    {
        return businessId.Replace(" ", "");
    }

    private class DummyCompany
    {
        public string BusinessId { get; set; } = string.Empty;
        public string LegalForm { get; set; } = string.Empty;
    }
}
