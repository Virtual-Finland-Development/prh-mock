using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Services;

public interface ICompanyDetailsService
{
    Task<EstablishmentResponse?> LoadCompany(string businessId);
    Task<string?> CreateCompany(Guid userId, EstablishmentResponse details);
    Task<string?> SaveOrUpdateCompany(Guid userId, string businessId, EstablishmentResponse details);
    Task<List<EstablishmentResponse>> GetUserCompanies(Guid userId);
    Task<List<MinimalCompanyDetails>> LoadCompanies();
    Task DeleteCompany(Guid userId, string businessId);
}
