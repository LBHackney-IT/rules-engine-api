using System.Collections.Generic;
using System.Linq;
using RulesEngine.Models;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Domain.Enums;

namespace RulesEngineApi.V1.Factories
{
    public static class ResponseFactory
    {
        public static WorkflowResponse ToResponse(this WorkflowDomain domain)
        {
            return new WorkflowResponse
            {
                Id = domain.Id,
                WorkflowName = domain.WorkflowName,
                Rules = domain.Rules?.ToResponseList(),
                CreatedAt = domain.CreatedAt,
                LastUpdatedAt = domain.LastUpdatedAt
            };
        }

        public static List<WorkflowResponse> ToResponse(this IEnumerable<WorkflowDomain> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }

        public static RuleResponse ToResponse(this Rule domain)
        {
            return new RuleResponse
            {
                Rules = domain.Rules?.ToResponseList(),
                Enabled = domain.Enabled,
                ErrorMessage = domain.ErrorMessage,
                Expression = domain.Expression,
                Operator = domain.Operator,
                RuleExpressionType = (RuleExpressionTypeEnum) domain.RuleExpressionType,
                RuleName = domain.RuleName,
                SuccessEvent = domain.SuccessEvent
            };
        }

        public static List<RuleResponse> ToResponseList(this IEnumerable<Rule> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
