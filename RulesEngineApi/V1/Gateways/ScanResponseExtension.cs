using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using RulesEngine.Models;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Domain.Enums;

namespace RulesEngineApi.V1.Gateways
{
    public static class ScanResponseExtension
    {
        public static List<WorkflowDomain> ToWorkflows(this ScanResponse response)
        {
            List<WorkflowDomain> workflows = new List<WorkflowDomain>();
            foreach (Dictionary<string, AttributeValue> item in response.Items)
            {
                workflows.Add(new WorkflowDomain()
                {
                    Id = Guid.Parse(item["id"].S),
                    WorkflowName = item["workflowName"].S,
                    Rules = ToRules(item["rules"].L)
                });
            }

            return workflows;
        }

        public static Rule ToRule(this Dictionary<string, AttributeValue> item)
        {
            return new Rule()
            {
                Rules = item["rules"].L == null ? null : ToRules(item["rules"].L),
                Enabled = item["enabled"].BOOL,
                ErrorMessage = item["errorMessage"].S,
                Expression = item["expression"].S,
                Operator = item["operator"].S,
                RuleExpressionType = Enum.Parse<RuleExpressionType>(item["ruleExpressionType"].S),
                RuleName = item["ruleName"].S,
                SuccessEvent = item["successEvent"].S
            };
        }

        public static List<Rule> ToRules(this List<AttributeValue> item)
        {
            var rules = new List<Rule>();
            var rulesItems = item.Select(p => p.M);
            foreach (Dictionary<string, AttributeValue> innerItem in rulesItems)
            {
                rules.Add(ToRule(innerItem));
            }
            return rules;
        }
    }
}
