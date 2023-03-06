using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Repositories;

public interface ISignatoryRightsRepository
{
    Task<SignatoryRightsResponse?> LoadAsync(string userId, string businessId, CancellationToken cancellationToken);

    Task<SignatoryRightsResponse> SaveAsync(string userId, string businessId, SignatoryRightsWriteRequest details,
        CancellationToken cancellationToken);
}
