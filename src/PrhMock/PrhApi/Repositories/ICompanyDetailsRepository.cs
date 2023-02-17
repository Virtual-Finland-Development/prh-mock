namespace company_establishment_api.Controllers;

public interface ICompanyDetailsRepository
{
    Task<CompanyDetails?> LoadWithKey(string key);
    Task<CompanyDetails?> LoadWithBusinessId(string businessId);
    Task<string?> Save(Guid userId, CompanyDetails details);
    Task<List<CompanyDetails>> LoadUserCompanies(Guid userId);
}
