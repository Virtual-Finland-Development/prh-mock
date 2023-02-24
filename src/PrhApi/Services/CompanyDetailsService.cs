using PrhApi.Domain;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

public class CompanyDetailsService : ICompanyDetailsService
{
    private readonly ILogger<CompanyDetailsService> _logger;
    private readonly ICompanyEstablishmentRepository _repository;

    public CompanyDetailsService(ICompanyEstablishmentRepository repository, ILogger<CompanyDetailsService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<EstablishmentResponse?> LoadCompany(string businessId)
    {
        var details = await _repository.LoadWithBusinessId(businessId);
        return details;
    }

    public async Task<string?> CreateCompany(Guid userId, EstablishmentResponse details)
    {
        var businessId = FinnishBusinessId.Generate();
        while (await _repository.LoadWithBusinessId(businessId) is not null) businessId = FinnishBusinessId.Generate();

        var result = await _repository.Save(userId, businessId, details);
        return result;
    }

    public async Task<string?> SaveOrUpdateCompany(Guid userId, string businessId, EstablishmentResponse details)
    {
        var existingCompany = await _repository.LoadWithBusinessId(businessId);
        if (existingCompany is not null)
        {
            UpdateValues(existingCompany, details);

            var updateResult = await _repository.Save(userId, businessId, existingCompany);
            if (updateResult is null)
            {
                _logger.LogError("Could not update existing company with businessId {BusinessId}", businessId);
                throw new InvalidOperationException("Could not update company");
            }

            return updateResult;
        }

        _logger.LogInformation("Could not find existing company, try to create new one with businessId {BusinessId}",
            businessId);

        var createResult = await _repository.Save(userId, businessId, details);
        if (createResult is null)
        {
            _logger.LogError("Could not create new company with businessId {BusinessId}", businessId);
            throw new InvalidOperationException("Could not create new company");
        }

        return createResult;
    }

    public Task<List<EstablishmentResponse>> GetUserCompanies(Guid userId)
    {
        return _repository.LoadUserCompanies(userId);
    }

    public async Task DeleteCompany(Guid userId, string businessId)
    {
        await _repository.Delete(userId, businessId);
    }

    public async Task<List<MinimalCompanyDetails>> LoadCompanies()
    {
        var companies = await _repository.LoadAll();
        //TODO: Do minimal mapping here
        return companies;
    }

    private void UpdateValues(EstablishmentResponse existingCompany, EstablishmentResponse details)
    {
        existingCompany.Registrant.GivenName = details.Registrant.GivenName;
        existingCompany.Registrant.LastName = details.Registrant.LastName;
        existingCompany.Registrant.Email = details.Registrant.Email;
        existingCompany.Registrant.PhoneNumber = details.Registrant.PhoneNumber;

        existingCompany.CompanyDetails.Name = details.CompanyDetails.Name;
        existingCompany.CompanyDetails.AlternativeName = details.CompanyDetails.AlternativeName;
        existingCompany.CompanyDetails.FoundingDate = details.CompanyDetails.FoundingDate;
        existingCompany.CompanyDetails.IndustrySector = details.CompanyDetails.IndustrySector;
        existingCompany.CompanyDetails.ShareCapital = details.CompanyDetails.ShareCapital;
        existingCompany.CompanyDetails.SettlementDeposit = details.CompanyDetails.SettlementDeposit;
        existingCompany.CompanyDetails.SettlementDate = details.CompanyDetails.SettlementDate;
        existingCompany.CompanyDetails.CountryOfResidence = details.CompanyDetails.CountryOfResidence;

        existingCompany.ShareSeries = details.ShareSeries;

        existingCompany.CompanyAddress.FullAddress = details.CompanyAddress.FullAddress;
        existingCompany.CompanyAddress.Thoroughfare = details.CompanyAddress.Thoroughfare;
        existingCompany.CompanyAddress.LocatorDesignator = details.CompanyAddress.LocatorDesignator;
        existingCompany.CompanyAddress.LocatorName = details.CompanyAddress.LocatorName;
        existingCompany.CompanyAddress.AddressArea = details.CompanyAddress.AddressArea;
        existingCompany.CompanyAddress.PostCode = details.CompanyAddress.PostCode;
        existingCompany.CompanyAddress.PostName = details.CompanyAddress.PostName;
        existingCompany.CompanyAddress.PoBox = details.CompanyAddress.PoBox;
        existingCompany.CompanyAddress.AdminUnitLevel1 = details.CompanyAddress.AdminUnitLevel1;
        existingCompany.CompanyAddress.AdminUnitLevel2 = details.CompanyAddress.AdminUnitLevel2;

        existingCompany.ManagingDirectors = details.ManagingDirectors;

        existingCompany.BoardMembers = details.BoardMembers;

        existingCompany.Auditor.CompanyName = details.Auditor.CompanyName;
        existingCompany.Auditor.NationalIdentifier = details.Auditor.NationalIdentifier;
    }
}
