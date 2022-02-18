using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Boundary.Response;

namespace RulesEngineApi.V1.UseCase.Interfaces
{
    public interface IExecuteAllRulesUseCase
    {
        public Task<List<RuleResultTreeResponse>> ExecuteAsync(string workflowName, List<InputRuleRequest> inputRules);
    }
}
