using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Gateways;
using RulesEngineApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using RulesEngine.Models;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.JsonConverters;

namespace RulesEngineApi.V1.UseCase
{
    public class ExecuteAllRulesUseCase : IExecuteAllRulesUseCase
    {
        private readonly IRulesEngineApiGateway _gateway;

        public ExecuteAllRulesUseCase(IRulesEngineApiGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<List<RuleResultTreeResponse>> ExecuteAsync(string workflowName, List<InputRuleRequest> inputRules)
        {
            var workflow = await _gateway.GetByWorkflowNameAsync(workflowName).ConfigureAwait(false);
            var workflows = new List<Workflow>()
            {
                new Workflow()
                {
                    WorkflowName = workflow.WorkflowName,
                    Rules = workflow.Rules,
                    GlobalParams = workflow.GlobalParams
                }
            };

            var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray(), null);

            var inputs = new List<RuleParameter>();
            foreach (var inputRule in inputRules)
            {
                var values = JsonSerializer.Deserialize<dynamic>(
                    JsonSerializer.Serialize(inputRule.Parameters), new JsonSerializerOptions
                    {
                        Converters = { new DynamicJsonConverter() }
                    });
                inputs.Add(new RuleParameter(inputRule.InputRuleName, values));
            }

            var ruleResult = await rulesEngine.ExecuteAllRulesAsync(workflowName, inputs.ToArray()).ConfigureAwait(false);

            var roleResultResponse = new List<RuleResultTreeResponse>();
            foreach (var result in ruleResult)
            {
                roleResultResponse.Add(new RuleResultTreeResponse()
                {
                    Rule = result.Rule.ToResponse(),
                    IsSuccess = result.IsSuccess,
                    ExceptionMessage = result.ExceptionMessage
                });
            }

            return roleResultResponse;
        }
    }
}
