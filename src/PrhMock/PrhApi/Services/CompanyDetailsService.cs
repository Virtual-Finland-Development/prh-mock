namespace company_establishment_api.Controllers;

public class CompanyDetailsService : ICompanyDetailsService
{
    private readonly ILogger<CompanyDetailsService> _logger;
    private readonly ICompanyDetailsRepository _repository;

    public CompanyDetailsService(ICompanyDetailsRepository repository, ILogger<CompanyDetailsService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CompanyDetails?> LoadCompany(string businessId)
    {
        var details = await _repository.LoadWithBusinessId(businessId);
        return details;
    }

    public async Task<string?> CreateCompany(Guid userId, CompanyDetails details)
    {
        if (details.BusinessId is null) return null;

        var companyExists = await _repository.LoadWithBusinessId(details.BusinessId);
        if (companyExists is not null)
            throw new InvalidOperationException($"Company {details.BusinessId} already exists");

        var result = await _repository.Save(userId, details);
        return result;
    }

    public async Task<string?> SaveOrUpdateCompany(Guid userId, string businessId, CompanyDetails details)
    {
        var existingCompany = await _repository.LoadWithBusinessId(businessId);
        if (existingCompany is not null)
        {
            existingCompany.UpdateValues(details);
            var updateResult = await _repository.Save(userId, existingCompany);
            if (updateResult is null)
            {
                _logger.LogError("Could not update existing company with businessId {BusinessId}", details.BusinessId);
                throw new InvalidOperationException("Could not update company");
            }

            return updateResult;
        }

        _logger.LogInformation("Could not find existing company, try to create new one with businessId {BusinessId}",
            details.BusinessId);

        var createResult = await _repository.Save(userId, details);
        if (createResult is null)
        {
            _logger.LogError("Could not create new company with businessId {BusinessId}", details.BusinessId);
            throw new InvalidOperationException("Could not create new company");
        }

        return createResult;
    }

    public Task<List<CompanyDetails>> GetUserCompanies(Guid userId)
    {
        return _repository.LoadUserCompanies(userId);
    }
}
