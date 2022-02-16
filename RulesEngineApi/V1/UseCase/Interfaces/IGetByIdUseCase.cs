using RulesEngineApi.V1.Boundary.Response;

namespace RulesEngineApi.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
