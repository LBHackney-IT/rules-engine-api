using RulesEngineApi.V1.Boundary.Request;
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

        public static WorkflowResponse ToResponse(this WorkflowData domain)
        {
            return new WorkflowResponse
            {
                Id = domain.Id,
                WorkflowName = domain.WorkflowName,
                Rules = domain.Rules,
                GlobalParams = domain.GlobalParams,
                CreatedAt = domain.CreatedAt
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
                Seq = workflow.Seq,
                CreatedAt = workflow.CreatedAt
            };
        }
    }
}
