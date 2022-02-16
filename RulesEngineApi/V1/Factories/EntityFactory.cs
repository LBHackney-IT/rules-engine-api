using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Infrastructure;

namespace RulesEngineApi.V1.Factories
{
    public static class EntityFactory
    {
        public static WorkflowData ToDomain(this WorkflowRequest request)
        {
            return new WorkflowData
            {
                WorkflowName = request.WorkflowName,
                Rules = request.Rules,
                GlobalParams = request.GlobalParams
            };
        }

        public static RulesEngineDbEntity ToDatabase(this WorkflowData workflow)
        {
            return new RulesEngineDbEntity
            {
                Id = workflow.Id,
                WorkflowName = workflow.WorkflowName,
                Rules = workflow.Rules,
                GlobalParams = workflow.GlobalParams,
                CreatedAt = workflow.CreatedAt
            };
        }
    }
}
