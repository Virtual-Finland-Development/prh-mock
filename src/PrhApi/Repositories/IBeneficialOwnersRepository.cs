using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

public interface IBeneficialOwnersRepository
{
    Task<BeneficialOwnersResponse?> LoadAsync(string userId, string businessId, CancellationToken cancellationToken);
    Task<BeneficialOwnersResponse> SaveAsync(string userId, string businessId, BeneficialOwnersWriteRequest details,
        CancellationToken cancellationToken);
}
