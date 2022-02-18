using System.Collections.Generic;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.UseCase.Interfaces
{
    public interface IGetAllUseCase
    {
        public Task<List<WorkflowResponse>> ExecuteAsync();
    }
}
