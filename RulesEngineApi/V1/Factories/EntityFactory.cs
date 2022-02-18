using System.Collections.Generic;
using System.Linq;
using RulesEngine.Models;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Infrastructure;

namespace RulesEngineApi.V1.Factories
{
    public static class EntityFactory
    {
        public static WorkflowDomain ToDomain(this WorkflowRequest request)
        {
            return new WorkflowDomain
            {
                WorkflowName = request.WorkflowName,
                Rules = request.Rules?.ToDomainList()
            };
        }

        public static WorkflowDomain ToDomain(this RulesEngineDbEntity databaseEntity)
        {
            return new WorkflowDomain
            {
                Id = databaseEntity.Id,
                WorkflowName = databaseEntity.WorkflowName,
                Rules = databaseEntity.Rules,
                GlobalParams = databaseEntity.GlobalParams,
                CreatedAt = databaseEntity.CreatedAt,
                LastUpdatedAt = databaseEntity.LastUpdatedAt
            };
        }

        public static WorkflowDomain ToDomain(this WorkflowResponse response)
        {
            return new WorkflowDomain
            {
                Id = response.Id,
                WorkflowName = response.WorkflowName,
                Rules = response.Rules?.ToDomainList(),
                CreatedAt = response.CreatedAt
            };
        }

        public static Rule ToDomain(this RuleRequest request)
        {
            return new Rule()
            {
                Rules = request.Rules?.ToDomainList(),
                Enabled = request.Enabled,
                ErrorMessage = request.ErrorMessage,
                Expression = request.Expression,
                Operator = request.Operator,
                RuleName = request.RuleName,
                RuleExpressionType = (RuleExpressionType) request.RuleExpressionType,
                SuccessEvent = request.SuccessEvent
            };
        }

        public static Rule ToDomain(this RuleResponse response)
        {
            return new Rule()
            {
                Rules = response.Rules?.ToDomainList(),
                Enabled = response.Enabled,
                ErrorMessage = response.ErrorMessage,
                Expression = response.Expression,
                Operator = response.Operator,
                RuleName = response.RuleName,
                RuleExpressionType = (RuleExpressionType) response.RuleExpressionType,
                SuccessEvent = response.SuccessEvent
            };
        }

        public static RulesEngineDbEntity ToDatabase(this WorkflowDomain workflow)
        {
            return new RulesEngineDbEntity
            {
                Id = workflow.Id,
                WorkflowName = workflow.WorkflowName,
                Rules = workflow.Rules,
                GlobalParams = workflow.GlobalParams,
                CreatedAt = workflow.CreatedAt,
                LastUpdatedAt = workflow.LastUpdatedAt
            };
        }

        public static List<Rule> ToDomainList(this IEnumerable<RuleRequest> requestList)
        {
            return requestList.Select(request => request.ToDomain()).ToList();
        }

        public static List<Rule> ToDomainList(this IEnumerable<RuleResponse> responseList)
        {
            return responseList.Select(request => request.ToDomain()).ToList();
        }

    }
}
