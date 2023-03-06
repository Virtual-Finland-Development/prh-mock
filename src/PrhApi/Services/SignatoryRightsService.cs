using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

internal class SignatoryRightsService : ISignatoryRightsService
{
    private readonly ISignatoryRightsRepository _repository;

    public SignatoryRightsService(ISignatoryRightsRepository repository)
    {
        _repository = repository;
    }

    public async Task<SignatoryRightsResponse?> Load(
        string userId, 
        string businessId, 
        CancellationToken cancellationToken)
    {
        return await _repository.LoadAsync(userId, businessId, cancellationToken);
    }

    public async Task<SignatoryRightsResponse> SaveOrUpdate(
        string userId, 
        string businessId, 
        SignatoryRightsWriteRequest details, 
        CancellationToken cancellationToken)
    {
        return await _repository.SaveAsync(userId, businessId, details, cancellationToken);
    }
}
