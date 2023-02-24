using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

public interface ICompanyEstablishmentRepository
{
    Task<EstablishmentResponse?> LoadWithKey(string key);
    Task<EstablishmentResponse?> LoadWithBusinessId(string businessId);
    Task<string?> Save(Guid userId, string businessId, EstablishmentResponse details);
    Task<List<EstablishmentResponse>> LoadUserCompanies(Guid userId);
    Task<List<MinimalCompanyDetails>> LoadAll();
    Task<Task> Delete(Guid userId, string businessId);
}
