using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Services;

public interface ISignatoryRightsService
{
    Task<SignatoryRightsResponse?> Load(string userId, string businessId, CancellationToken cancellationToken);

    Task<SignatoryRightsResponse> SaveOrUpdate(string userId, string businessId, SignatoryRightsWriteRequest details,
        CancellationToken cancellationToken);
}
