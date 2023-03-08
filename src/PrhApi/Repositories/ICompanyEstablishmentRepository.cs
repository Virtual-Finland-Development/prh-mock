using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

public interface ICompanyEstablishmentRepository
{
    Task<EstablishmentResponse?> LoadWithKey(string key);
    Task<EstablishmentResponse?> LoadWithBusinessId(string businessId);
    Task<string> Save(string userId, string businessId, EstablishmentResponse details);
    Task<List<UserCompany>> LoadUserCompanies(string userId);
    Task<List<MinimalCompanyDetails>> LoadAll();
    Task<Task> Delete(string userId, string businessId);
}
