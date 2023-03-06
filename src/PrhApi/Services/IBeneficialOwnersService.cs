using PrhApi.Models.CodeGen.Model;

namespace PrhApi.Services;

internal interface IBeneficialOwnersService
{
    Task<BeneficialOwnersResponse?> Load(string userId, string businessId, CancellationToken cancellationToken);

    Task<BeneficialOwnersResponse> SaveOrUpdate(string userId, string businessId, BeneficialOwnersWriteRequest data,
        CancellationToken cancellationToken);
}
