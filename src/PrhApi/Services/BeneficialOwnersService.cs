using PrhApi.Models.CodeGen.Model;
using PrhApi.Repositories;

namespace PrhApi.Services;

internal class BeneficialOwnersService : IBeneficialOwnersService
{
    private readonly IBeneficialOwnersRepository _repository;
    private readonly IDummyDataRepository _dummyDataRepository;

    public BeneficialOwnersService(IBeneficialOwnersRepository repository, IDummyDataRepository dummyDataRepository)
    {
        _repository = repository;
        _dummyDataRepository = dummyDataRepository;
    }

    public async Task<BeneficialOwnersResponse?> Load(
        string userId,
        string businessId,
        CancellationToken cancellationToken)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            return _dummyDataRepository.ReadBeneficialOwners(businessId);
        }
        return await _repository.LoadAsync(userId, businessId, cancellationToken);
    }

    public async Task<BeneficialOwnersResponse> SaveOrUpdate(
        string userId,
        string businessId,
        BeneficialOwnersWriteRequest data,
        CancellationToken cancellationToken)
    {
        if (_dummyDataRepository.IsDummyBusinessId(businessId))
        {
            throw new Exception("Cannot save dummy data");
        }
        return await _repository.SaveAsync(userId, businessId, data, cancellationToken);
    }
}
