using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

internal class BeneficialOwnersService : IBeneficialOwnersService
{
    private readonly IBeneficialOwnersRepository _repository;

    public BeneficialOwnersService(IBeneficialOwnersRepository repository)
    {
        _repository = repository;
    }

    public async Task<BeneficialOwnersResponse?> Load(
        string userId,
        string businessId,
        CancellationToken cancellationToken)
    {
        return await _repository.LoadAsync(userId, businessId, cancellationToken);
    }

    public async Task<BeneficialOwnersResponse> SaveOrUpdate(
        string userId,
        string businessId,
        BeneficialOwnersWriteRequest data,
        CancellationToken cancellationToken)
    {
        return await _repository.SaveAsync(userId, businessId, data, cancellationToken);
    }
}
