using PrhApi.Domain;
using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

public class CompanyDetailsService : ICompanyDetailsService
{
    private readonly ILogger<CompanyDetailsService> _logger;
    private readonly ICompanyEstablishmentRepository _repository;
    private readonly IDummyDataRepository _dummyDataRepository;

    public CompanyDetailsService(ICompanyEstablishmentRepository repository, IDummyDataRepository dummyDataRepository, ILogger<CompanyDetailsService> logger)
    {
        _repository = repository;
        _dummyDataRepository = dummyDataRepository;
        _logger = logger;
    }

    public async Task<EstablishmentResponse?> LoadCompany(string businessId)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            return _dummyDataRepository.ReadEstablishment(businessId);
        }
        var details = await _repository.LoadWithBusinessId(businessId);
        return details;
    }

    public async Task<string> CreateCompany(string userId, EstablishmentResponse details)
    {
        var businessId = FinnishBusinessId.Generate();
        while (_dummyDataRepository.IsDummyBusinessId(businessId) || await _repository.LoadWithBusinessId(businessId) is not null) businessId = FinnishBusinessId.Generate();

        var result = await _repository.Save(userId, businessId, details);
        return result;
    }

    public async Task<string> SaveOrUpdateCompany(string userId, string businessId, EstablishmentResponse details)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            throw new ArgumentException($"Business id {businessId} is reserved for dummy data");
        }

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

    public Task<List<UserCompany>> GetUserCompanies(string userId)
    {
        return _repository.LoadUserCompanies(userId);
    }

    public async Task DeleteCompany(string userId, string businessId)
    {
        await _repository.Delete(userId, businessId);
    }

    public async Task<List<MinimalCompanyDetails>> LoadCompanies()
    {
        var companies = await _repository.LoadAll();
        //TODO: Do minimal mapping here
        return companies;
    }

    public async Task<BasicInformationResponse?> LoadCompanyBasicInformation(string businessId)
    {
        EstablishmentResponse? company;
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            company = _dummyDataRepository.ReadEstablishment(businessId);
        }
        else
        {
            company = await _repository.LoadWithBusinessId(businessId);
        }

        if (company is null) return null;

        var basicInformation = new BasicInformationResponse()
        {
            Name = company.CompanyDetails.Name,
            LegalForm = _dummyDataRepository.ResolveLegalForm(businessId), // Simulated value
            LegalStatus = "NORMAL", // Simulated value
            RegistrationDate = company.CompanyDetails.FoundingDate,
            RegisteredAddress = new RegisteredAddress()
            {
                FullAddress = company.CompanyAddress.FullAddress,
                Thoroughfare = company.CompanyAddress.Thoroughfare,
                LocatorDesignator = company.CompanyAddress.LocatorDesignator,
                LocatorName = company.CompanyAddress.LocatorName,
                AddressArea = company.CompanyAddress.AddressArea,
                PostCode = company.CompanyAddress.PostCode,
                PostName = company.CompanyAddress.PostName,
                PoBox = company.CompanyAddress.PoBox,
                AdminUnitLevel1 = company.CompanyAddress.AdminUnitLevel1,
                AdminUnitLevel2 = company.CompanyAddress.AdminUnitLevel2,
            },
        };

        return basicInformation;
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

        existingCompany.AuditorDetails.CompanyName = details.AuditorDetails.CompanyName;
        existingCompany.AuditorDetails.NationalIdentifier = details.AuditorDetails.NationalIdentifier;
        existingCompany.AuditorDetails.GivenName = details.AuditorDetails.GivenName;
        existingCompany.AuditorDetails.LastName = details.AuditorDetails.LastName;
    }
}
