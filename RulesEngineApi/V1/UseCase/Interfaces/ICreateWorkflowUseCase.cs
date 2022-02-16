using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.UseCase.Interfaces
{
    public interface ICreateWorkflowUseCase
    {
        public Task<WorkflowResponse> ExecuteAsync(WorkflowData workflow);
    }
}
