using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

internal class SignatoryRightsService : ISignatoryRightsService
{
    private readonly ISignatoryRightsRepository _repository;
    private readonly IDummyDataRepository _dummyDataRepository;

    public SignatoryRightsService(ISignatoryRightsRepository repository, IDummyDataRepository dummyDataRepository)
    {
        _repository = repository;
        _dummyDataRepository = dummyDataRepository;
    }

    public async Task<SignatoryRightsResponse?> Load(
        string userId,
        string businessId,
        CancellationToken cancellationToken)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            return _dummyDataRepository.ReadSignatoryRights(businessId);
        }
        return await _repository.LoadAsync(userId, businessId, cancellationToken);
    }

    public async Task<SignatoryRightsResponse> SaveOrUpdate(
        string userId,
        string businessId,
        SignatoryRightsWriteRequest details,
        CancellationToken cancellationToken)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            throw new ArgumentException($"Business id {businessId} is reserved for dummy data");
        }
        return await _repository.SaveAsync(userId, businessId, details, cancellationToken);
    }
}
