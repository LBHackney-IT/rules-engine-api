using System.Collections.Generic;
using System.Linq;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Factories
{
    public static class ResponseFactory
    {
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
    }
}
