namespace PrhApi.Repositories;
using PrhApi.Models.CodeGen.Model;

public interface IDummyDataRepository
{
    public bool IsDummyBusinessId(string businessId);
    public EstablishmentResponse? ReadEstablishment(string businessId);
    public BeneficialOwnersResponse? ReadBeneficialOwners(string businessId);
    public SignatoryRightsResponse? ReadSignatoryRights(string businessId);
    public string ResolveLegalForm(string businessId);
    public string ResolveAdminUnitLevel(string businessId);
}
