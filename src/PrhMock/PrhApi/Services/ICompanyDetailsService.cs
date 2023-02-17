namespace company_establishment_api.Controllers;

public interface ICompanyDetailsService
{
    Task<CompanyDetails?> LoadCompany(string businessId);
    Task<string?> CreateCompany(Guid userId, CompanyDetails details);
    Task<string?> SaveOrUpdateCompany(Guid userId, string businessId, CompanyDetails details);
    Task<List<CompanyDetails>> GetUserCompanies(Guid userId);
}
