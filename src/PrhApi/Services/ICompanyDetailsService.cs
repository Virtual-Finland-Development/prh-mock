using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Services;

public interface ICompanyDetailsService
{
    Task<EstablishmentResponse?> LoadCompany(string businessId);
    Task<string> CreateCompany(string userId, EstablishmentResponse details);
    Task<string> SaveOrUpdateCompany(string userId, string businessId, EstablishmentResponse details);
    Task<List<UserCompany>> GetUserCompanies(string userId);
    Task<List<MinimalCompanyDetails>> LoadCompanies();
    Task<BasicInformationResponse?> LoadCompanyBasicInformation(string businessId);
    Task DeleteCompany(string userId, string businessId);
}
